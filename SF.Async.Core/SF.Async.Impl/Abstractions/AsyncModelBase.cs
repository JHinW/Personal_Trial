using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Runtime;
using SF.Async.Core.Definitions;
using SF.Async.Cross;
using SF.Async.Org;
using System;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;

namespace SF.Async.Impl.Abstractions
{
    public abstract class AsyncModelBase : StatefulService, ITransferer
    {
        protected IReliableQueue<MessageDefinition> _reliableQueue;

        protected IFollowing _following;

        protected IServiceEvent _serviceEvent;

        protected ManualResetEvent mre = new ManualResetEvent(false);

        public AsyncModelBase(StatefulServiceContext context,
            IFollowing following,
            IServiceEvent serviceEvent)
            : base(context)
        {
            _following = following;
            _serviceEvent = serviceEvent;
        }

        public virtual Task DataTansfer(MessageDefinition data)
        {
            return EnqueueAsync(data);
        }

        public virtual async Task<object> DataTansferForResultAsync(MessageDefinition data)
        {
            await DataTansfer(data);
            return null;
        }

        public virtual async Task EnqueueAsync(MessageDefinition message)
        {
            //To ensure _reliableQueue is not null
            mre.WaitOne();

            using (var tx = this.StateManager.CreateTransaction())
            {
                try
                {
                    await _reliableQueue.EnqueueAsync(tx, message);
                    await tx.CommitAsync();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
