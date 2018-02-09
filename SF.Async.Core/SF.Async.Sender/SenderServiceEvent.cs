using SF.Async.Cross.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Sender
{
    public class SenderServiceEvent: ServiceEventBase
    {
        public SenderServiceEvent(Action<string> loggerDelegate)
            : base(loggerDelegate)
        {
        }
    }
}
