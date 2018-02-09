using SF.Async.Sender.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.ServiceFabric.Services.Communication.AspNetCore;
using System.Fabric;
using SF.Async.Org;
using SF.Async.Cross;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace SF.Web.Main
{
    public class AsyncSenderProcess : AsyncSenderProcessBase
    {

        public AsyncSenderProcess(StatelessServiceContext context,
            IFollowing following,
            IServiceEvent serviceEvent) : base(context, following, serviceEvent)
        {
        }

        public override IWebHost WebBuild(StatelessServiceContext context, string url, AspNetCoreCommunicationListener listener)
        {
            return new WebHostBuilder()
                .UseWebListener()
                .ConfigureServices(
                    services =>
                    {
                        services.AddSingleton<StatelessServiceContext>(context);

                        services.AddSingleton<ITransferer>(this);

                    })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.None)
                .UseUrls(url)
                .Build();
        }
    }
}
