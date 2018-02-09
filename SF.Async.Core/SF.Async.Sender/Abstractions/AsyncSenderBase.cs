using Microsoft.ServiceFabric.Services.Runtime;
using SF.Async.Cross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Async.Core.Definitions;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Communication.AspNetCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;
using SF.Async.Org;
using System.Threading;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using System.Fabric;

namespace SF.Async.Sender.Abstractions
{
    public abstract class AsyncSenderBase : StatelessService, ITransferer
    {

        protected ConcurrentQueue<MessageDefinition> _memQueue;

        protected ConcurrentDictionary<string, TaskCompletionSource<Object>> _memDic;

        protected IFollowing _following;

        protected IServiceEvent _serviceEvent;

        protected ManualResetEvent _mre = new ManualResetEvent(false);

        public AsyncSenderBase(StatelessServiceContext context,
            IFollowing following,
            IServiceEvent serviceEvent) : base(context)
        {
            _following = following;
            _serviceEvent = serviceEvent;
        }

        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            yield return new ServiceInstanceListener(serviceContext =>
                    new WebListenerCommunicationListener(serviceContext, "ServiceEndpoint", (url, listener) =>
                    {
                        //  ServiceEventSource.Current.ServiceMessage(serviceContext, $"Starting WebListener on {url}");

                        return WebBuild(serviceContext, url, listener);
                    }));


            yield return new ServiceInstanceListener(context => this.CreateServiceRemotingListener(context));

        }


        public abstract IWebHost WebBuild(StatelessServiceContext context, string uri, AspNetCoreCommunicationListener listener);


        public Task DataTansfer(MessageDefinition data)
        {
            _mre.WaitOne();
            return EnqueueAsync(data);
        }


        public async Task<object> DataTansferForResultAsync(MessageDefinition data)
        {
            await DataTansfer(data);
            var id = data.UniqueID;
            var waitable = new TaskCompletionSource<Object>();
            _memDic.AddOrUpdate(id, waitable, (key, old) => waitable);
            return await waitable.Task;
        }

        public virtual async Task EnqueueAsync(MessageDefinition message)
        {
            //To ensure _reliableQueue is not null 
            _memQueue.Enqueue(message);
            await Task.CompletedTask;
        }
    }
}
