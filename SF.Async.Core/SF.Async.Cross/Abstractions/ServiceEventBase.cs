using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Cross.Abstractions
{
    public class ServiceEventBase: IServiceEvent
    {
        private Action<string> _loggerDelegate;

        public ServiceEventBase(Action<string> loggerDelegate)
        {
            _loggerDelegate = loggerDelegate;
        }

        public virtual void LogEvents(string content)
        {
            _loggerDelegate(content);
        }
    }
}
