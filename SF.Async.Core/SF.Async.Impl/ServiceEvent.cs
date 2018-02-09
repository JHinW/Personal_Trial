using Microsoft.ServiceFabric.Services.Remoting;
using SF.Async.Core;
using SF.Async.Cross;
using SF.Async.Cross.Abstractions;
using System;

namespace SF.Async.Impl.Usages
{
    public class ServiceEvent : ServiceEventBase
    {
        public ServiceEvent(Action<string> loggerDelegate)
            : base(loggerDelegate)
        {
        }

    }
}
