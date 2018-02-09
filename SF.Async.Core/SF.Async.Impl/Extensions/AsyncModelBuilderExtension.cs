using SF.Async.Cross;
using SF.Async.EasyDI.Extensions;
using SF.Async.Impl.Builder;
using SF.Async.Impl.Usages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Impl.Extensions
{
    public static class AsyncModelBuilderExtension
    {
        public static IAsyncModelBuilder AddLogger(this IAsyncModelBuilder builder, Action<string> loggerDelegate)
        {
            builder.ConfigureServices( container =>
            {
                container.AddDisp<IServiceEvent>(new ServiceEvent(loggerDelegate));
            });
            return builder;
        }
    }
}
