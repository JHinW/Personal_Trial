using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Core
{
    public interface IRouteReducer
    {
        IAsyncAction Init(IAsyncAction originalAction, IAsyncAction destinationAction, IContentBox Message);

        IContentBox Looping(IContentBox oldMessage, IContentBox newMessage);

        IAsyncAction Redirect(IAsyncAction oldAction, IContentBox newMessage);

    }
}
