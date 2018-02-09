using SF.Async.Cross;
using SF.Async.EasyDI.Extensions;
using SF.Async.Sender;
using SF.Async.Sender.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Sender.Extensions
{
    public static class AsyncSenderBuilderExtension
    {
        public static IAsyncSenderBuilder AddLogger(this IAsyncSenderBuilder builder, Action<string> loggerDelegate)
        {
            builder.ConfigureServices( container =>
            {
                container.AddDisp<IServiceEvent>(new SenderServiceEvent(loggerDelegate));
            });
            return builder;
        }
    }
}
