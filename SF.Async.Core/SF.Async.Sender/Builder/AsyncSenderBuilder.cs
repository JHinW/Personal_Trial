using SF.Async.Cross;
using SF.Async.EasyDI;
using SF.Async.EasyDI.Extensions;
using SF.Async.EasyDI.Usages;
using SF.Async.Org.Builder;
using SF.Async.Org.Usages;
using System;
using System.Collections.Generic;
using System.Fabric;

namespace SF.Async.Sender.Builder
{
    using EasyDIConfigureDelegate = Action<IContainer>;
    using FollowingConfigureDelegate = Action<IFollowingBuilder>;

    public class AsyncSenderBuilder: IAsyncSenderBuilder
    {
        private StatelessServiceContext _statefulServiceContext;

        private IList<EasyDIConfigureDelegate> _easyDIConfigureDelegateList = new List<EasyDIConfigureDelegate>();

        private FollowingConfigureDelegate _followingConfigureDelegate;

        public AsyncSenderBuilder(StatelessServiceContext statefulServiceContext)
        {
            _statefulServiceContext = statefulServiceContext;
        }

        public IAsyncSenderBuilder ConfigureServices(EasyDIConfigureDelegate easyDIConfigureDelegate)
        {
            _easyDIConfigureDelegateList.Add(easyDIConfigureDelegate);
            return this;
        }

        public IAsyncSenderBuilder ConfigureFollowingDelegate(FollowingConfigureDelegate followingConfigureDelegate)
        {
            _followingConfigureDelegate = followingConfigureDelegate;
            return this;
        }


        public TModel Build<TModel>()
            where TModel: ITransferer
        {
            var container = new EasyTypeContainer();
            // config service 
            foreach(var action in _easyDIConfigureDelegateList)
            {
                action(container);
            }

            // service tracker
            var tracker = container.CreateTracker();
            var builder = new FollowingBuilder(tracker);
            // middleware config
            _followingConfigureDelegate(builder);
            var following = builder.FollowingBuild<CommonFollowing>();
            var loggerService = (IServiceEvent)tracker.Track(typeof(IServiceEvent));
            var remoteService =  (TModel)Activator.CreateInstance(
                typeof(TModel), 
                _statefulServiceContext,
                following,
                loggerService
                );

            // add Transferer itself to DI container
            // so follower from anywhere can use it via constructor
            container.AddDisp<ITransferer>(remoteService);
            return remoteService;

        }
    }
}
