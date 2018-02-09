
using Common.Interface.Actor;
using Common.Interface.UserInterface;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using System;

namespace OpgWebApi.Src.Services
{
    public class CommandGetter : IActorGetter<ICommandActor>
    {
        private static string url = "fabric:/OpgSFdemo/CommandActorService";

        //private ICaculateActor CaculateActor = null;

        public CommandGetter()
        {
        }

        public ICommandActor GetActorServiceById(string id)
        {
            ActorId actorId = new ActorId(id);

            // This only creates a proxy object, it does not activate an actor or invoke any methods yet.
            return ActorProxy.Create<ICommandActor>(actorId, new Uri(url));
        }

        public ICommandActor GetRandomActorService()
        {
            ActorId actorId = ActorId.CreateRandom();

            // This only creates a proxy object, it does not activate an actor or invoke any methods yet.
            return ActorProxy.Create<ICommandActor>(actorId, new Uri(url));
        }
    }
}
