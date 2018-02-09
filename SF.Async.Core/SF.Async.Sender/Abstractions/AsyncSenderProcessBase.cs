using SF.Async.Cross;
using SF.Async.Org;
using SF.Async.Sender.Abstractions;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.ServiceFabric.Services.Communication.AspNetCore;
using System.Threading;
using System.Collections.Concurrent;
using SF.Async.Core.Definitions;
using SF.Async.Core;

namespace SF.Async.Sender.Abstractions
{
    public abstract class AsyncSenderProcessBase: AsyncSenderBase
    {
        public AsyncSenderProcessBase(StatelessServiceContext context,
            IFollowing following,
            IServiceEvent serviceEvent): base(context, following, serviceEvent)
        {
        }

       // public abstract IWebHost WebBuild(ServiceContext context, string uri, AspNetCoreCommunicationListener listener);


        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            _memQueue = new ConcurrentQueue<MessageDefinition>();
            _memDic = new ConcurrentDictionary<string, TaskCompletionSource<object>>();

            _mre.Set();

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                _memQueue.TryDequeue(out var message);
                if(message!= null)
                {
                    var action = message.MessageStatus;
                    if(action == MessageStatus.End)
                    {
                        _memDic.TryRemove(message.UniqueID, out var awaitable);
                        awaitable.SetResult(message);
                    }
                    else
                    {
                        await _following.CatchAsync(message);
                    }
                }


                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }
    }
}
