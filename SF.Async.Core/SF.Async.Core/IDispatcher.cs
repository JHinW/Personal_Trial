using SF.Async.Core.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Core
{
    public interface IDispatcher
    {
        void DispatchBack(MessageDefinition newMessage);

        void Dispatch(MessageDefinition newMessage, IAsyncAction newAction);
    }
}
