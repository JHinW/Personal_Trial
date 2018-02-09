using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Runtime;
using SF.Async.Impl.Builder;
using SF.Async.EasyDI.Extensions;
using SF.Stateful.Test.Main;
using SF.Async.Org.Extensions;
using SF.Async.Impl.Extensions;
using SF.Async.Impl.Usages;

namespace SF.Stateful.Test
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

                ServiceRuntime.RegisterServiceAsync("SF.Stateful.TestType",
                    context =>
                    {
                        var builder = new AsyncModelBuilder(context)
                        .ConfigureServices(container =>
                        {
                            container.AddDisp<string>("hello world!");

                        }).ConfigureFollowingDelegate(followerBuilder =>
                        {
                            followerBuilder.UseFollower<TestFollower>();
                        }).AddLogger( content => 
                        {
                            ServiceEventSource.Current.ServiceMessage(context, content);
                        });

                        var service = builder.Build<AsyncModel>();

                        return service;
                    }).GetAwaiter().GetResult();

                ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(Test).Name);

                // Prevents this host process from terminating so services keep running.
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
