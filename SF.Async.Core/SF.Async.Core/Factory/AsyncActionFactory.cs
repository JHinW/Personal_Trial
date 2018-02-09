using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Core.Factory
{
    public class AsyncActionFactory
    {
        public static IAsyncAction CreateAsyncAction(string baseUri, string middleWareName)
        {
            var item = new AsyncAction();
            item.BaseUri = baseUri;
            item.MiddleWareName = middleWareName;
            return item;
        }

        public static IAsyncAction CreateEndAsyncAction(string baseUri, string middleWareName)
        {
            var item = new EndAsyncAction();
            item.BaseUri = baseUri;
            item.MiddleWareName = middleWareName;
            return item;
        }
    }
}
