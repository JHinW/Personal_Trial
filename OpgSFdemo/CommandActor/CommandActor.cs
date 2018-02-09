using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using Common.Interface.Actor;
using Common.Model;

namespace CommandActor
{
    /// <remarks>
    /// This class represents an actor.
    /// Every ActorID maps to an instance of this class.
    /// The StatePersistence attribute determines persistence and replication of actor state:
    ///  - Persisted: State is written to disk and replicated.
    ///  - Volatile: State is kept in memory only and replicated.
    ///  - None: State is kept in memory only and not replicated.
    /// </remarks>
    [StatePersistence(StatePersistence.Persisted)]
    internal class CommandActor : Actor, ICommandActor
    {
        /// <summary>
        /// Initializes a new instance of CommandActor
        /// </summary>
        /// <param name="actorService">The Microsoft.ServiceFabric.Actors.Runtime.ActorService that will host this actor instance.</param>
        /// <param name="actorId">The Microsoft.ServiceFabric.Actors.ActorId for this actor instance.</param>
        public CommandActor(ActorService actorService, ActorId actorId)
            : base(actorService, actorId)
        {
        }

        /// <summary>
        /// This method is called whenever an actor is activated.
        /// An actor is activated the first time any of its methods are invoked.
        /// </summary>
        protected override Task OnActivateAsync()
        {
            ActorEventSource.Current.ActorMessage(this, "Actor activated.");

            // The StateManager is this actor's private state store.
            // Data stored in the StateManager will be replicated for high-availability for actors that use volatile or persisted state storage.
            // Any serializable object can be saved in the StateManager.
            // For more information, see https://aka.ms/servicefabricactorsstateserialization
            this.StateManager.TryAddStateAsync("command", new Command());
            return this.StateManager.TryAddStateAsync("count", 0);
        }

        Task ICommandActor.AddScore(int score, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO: Replace with your own actor method.
        /// </summary>
        /// <returns></returns>
        Task<int> ICommandActor.GetCountAsync(CancellationToken cancellationToken)
        {
            return this.StateManager.GetStateAsync<int>("count", cancellationToken);
        }

        Task<int> ICommandActor.GetScore(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        async Task<int> ICommandActor.InputOperation(string type, int value, CancellationToken cancellationToken)
        {
            var command = await this.StateManager.GetStateAsync<Command>("command", cancellationToken);
            var current = command.CurrentOperation;
            var ret = 0;
            switch (type)
            {
                case "source":
                    command.SourceOperationPara = value;
                    command.CurrentOperation = new DestOperation
                    {
                        OperationType = -1
                    };
                    await this.StateManager.AddOrUpdateStateAsync<Command>("command", command, (key, commd) => {
                        return command;
                    }, cancellationToken);
                    break;
                case "dest":
                    if(current.OperationType == -1)
                    {
                        break;
                    }

                    current.DestPara = value;
                    command.DestOperation.Add(command.CurrentOperation);
                    command.CurrentOperation = new DestOperation
                    {
                        OperationType = -1
                    };
                    await this.StateManager.AddOrUpdateStateAsync<Command>("command", command, (key, commd) => {
                        return command;
                    }, cancellationToken);

                    break;
                case "opera":
                    current.OperationType = value;
                    await this.StateManager.AddOrUpdateStateAsync<Command>("command", command, (key, commd) => {
                        return command;
                    }, cancellationToken);
                    break;

                case "result":
                    ret = command.SourceOperationPara;
                    foreach (var opera in command.DestOperation)
                    {
                        if (opera.OperationType == 0)
                        {
                            ret -= opera.DestPara;
                        }
                        else if (opera.OperationType == 1)
                        {
                            ret += opera.DestPara;
                        }
                    }

                    break;
                case "reset":
                    await this.StateManager.AddOrUpdateStateAsync<Command>("command", command, (key, commd) => {
                        return new Command();
                    }, cancellationToken);
                    break;
            }

            return ret;
        }

        /// <summary>
        /// TODO: Replace with your own actor method.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        Task ICommandActor.SetCountAsync(int count, CancellationToken cancellationToken)
        {
            // Requests are not guaranteed to be processed in order nor at most once.
            // The update function here verifies that the incoming count is greater than the current count to preserve order.
            return this.StateManager.AddOrUpdateStateAsync("count", count, (key, value) => count > value ? count : value, cancellationToken);
        }
    }
}
