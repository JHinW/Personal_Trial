using Microsoft.ServiceFabric.Services.Runtime;
using SF.Async.EasyDI.Extensions;
using SF.Async.Sender.Builder;
using SF.Async.Sender.Extensions;
using SF.Web.Main;
using System;
using System.Diagnostics;
using System.Threading;
using SF.Async.Org.Extensions;

namespace SF.Web
{
    internal static class Program
    {
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            try
            {
                // The ServiceManifest.XML file defines one or more service type names.
                // Registering a service maps a service type name to a .NET type.
                // When Service Fabric creates an instance of this service type,
                // an instance of the class is created in this host process.

                ServiceRuntime.RegisterServiceAsync("SF.WebType",
                    context =>
                    {
                        var builder = new AsyncSenderBuilder(context)
                            .ConfigureServices(container =>
                            {
                                container.AddDisp<string>("hello world!");

                            }).ConfigureFollowingDelegate(followerBuilder =>
                            {
                                followerBuilder.UseFollower<TestFollower>();
                            }).AddLogger(content =>
                            {
                                ServiceEventSource.Current.ServiceMessage(context, content);
                            });

                        var service = builder.Build<AsyncSenderProcess>();

                        return service;
                    }).GetAwaiter().GetResult();

                ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(Web).Name);

                // Prevents this host process from terminating so services keeps running. 
                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
