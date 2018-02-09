using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.FabricTransport.Runtime;
using SF.Async.Core;
using SF.Async.Core.Definitions;
using SF.Async.Cross;
using SF.Async.Impl.Abstractions;
using SF.Async.Org;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;

namespace SF.Async.Impl.Usages
{
    public class AsyncModel: AsyncModelBase
    {
        public AsyncModel(StatefulServiceContext context,
            IFollowing following,
            IServiceEvent serviceEvent): base(context, following, serviceEvent)
        {
        }

         
        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {

            yield return new ServiceReplicaListener(context =>
            {
                return new FabricTransportServiceRemotingListener(context,
                    this);
            }, "StateFulQueueFabricTransportServiceRemotingListener");
        }

        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            _reliableQueue = await this.StateManager.GetOrAddAsync<IReliableQueue<MessageDefinition>>("queue");
            mre.Set();
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                MessageDefinition content = null;
                using (var tx = this.StateManager.CreateTransaction())
                {
                    var result = await _reliableQueue.TryDequeueAsync(tx);
                    content = result.HasValue ? result.Value : null;

                    // If an exception is thrown before calling CommitAsync, the transaction aborts, all changes are 
                    // discarded, and nothing is saved to the secondary replicas.

                    await tx.CommitAsync();

                    /*ServiceEventSource.Current.ServiceMessage(this.Context, "Current Counter Value: {0}",
                        result.HasValue ? result.Value.ToString() : "Value does not exist.");
                        */
                    _serviceEvent.LogEvents($"Current Counter Value: { (result.HasValue ? result.Value.ToString() : "") } Value does not exist.");
                }

                if (content != null)
                {
                    await _following.CatchAsync(content);

                }

                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }



    }
}
