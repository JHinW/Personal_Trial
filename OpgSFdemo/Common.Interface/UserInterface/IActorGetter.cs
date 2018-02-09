using Microsoft.ServiceFabric.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface.UserInterface
{
    public interface IActorGetter<TActorInterface> where TActorInterface : IActor
    {
        TActorInterface GetRandomActorService();
        TActorInterface GetActorServiceById(string id);
    }
}
