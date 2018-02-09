using SF.Async.Core.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Core
{
    public interface IRouteReducerGeneric<Tin, Tout> 
        where Tin: class
        where Tout : class
    {
        IAsyncAction Init(IAsyncAction originalAction, IAsyncAction destinationAction, Tin Message);

        Tout Looping(Tin oldMessage, Tout newMessage);

        IAsyncAction Redirect(IAsyncAction oldAction, Tout newMessage);

        //void End(AsyncAction newAction, MessageDefinition newMessage);
    }
}
