using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Core
{
    public class EndAsyncAction : IAsyncAction
    {
        public string MiddleWareName { get; set; }

        public string BaseUri { get; set; }

        public bool IsEnd => true;
    }
}
