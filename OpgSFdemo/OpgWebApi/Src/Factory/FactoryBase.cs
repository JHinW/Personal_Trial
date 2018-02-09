using Common.Interface.Actor;
using Common.Interface.UserInterface;
using Microsoft.ServiceFabric.Actors;
using System;

namespace OpgWebApi.Src.Factory
{
    public abstract class FactoryBase
    {
        public static TActor GetActorService<TGetter, TActor>(Action<IActor> action = null) where TGetter : IActorGetter<TActor> where TActor : IActor
        {
            var instance = (TGetter)Activator.CreateInstance(typeof(TGetter), true);
            var actor = instance.GetRandomActorService();
            if (action != null)
            {
                action(actor);
            }

            return (TActor)actor;
        }


        public static TActor GetActorService<TGetter, TActor>(string id, Action<IActor> action = null) where TGetter : IActorGetter<TActor> where TActor : IActor
        {
            var instance = (TGetter)Activator.CreateInstance(typeof(TGetter), true);
            var actor = instance.GetActorServiceById(id);
            if(action != null)
            {
                action(actor);
            }

            return (TActor)actor;
        }
    }
}
