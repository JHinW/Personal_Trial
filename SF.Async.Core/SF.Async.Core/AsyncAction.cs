using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Core
{
    public class AsyncAction: IAsyncAction
    {
        public string MiddleWareName { get; set; }

        public String BaseUri { get; set; }

        public bool IsEnd => false;
    }
}
