using SF.Async.Cross;
using SF.Async.EasyDI;
using SF.Async.EasyDI.Usages;
using SF.Async.Org.Builder;
using SF.Async.Org.Usages;
using System;
using System.Collections.Generic;
using System.Fabric;

namespace SF.Async.Impl.Builder
{
    using EasyDIConfigureDelegate = Action<IContainer>;
    using FollowingConfigureDelegate = Action<IFollowingBuilder>;

    public class AsyncModelBuilder: IAsyncModelBuilder
    {
        private StatefulServiceContext _statefulServiceContext;

        private IList<EasyDIConfigureDelegate> _easyDIConfigureDelegateList = new List<EasyDIConfigureDelegate>();

        private FollowingConfigureDelegate _followingConfigureDelegate;

        public AsyncModelBuilder(StatefulServiceContext statefulServiceContext)
        {
            _statefulServiceContext = statefulServiceContext;
        }

        public IAsyncModelBuilder ConfigureServices(EasyDIConfigureDelegate easyDIConfigureDelegate)
        {
            _easyDIConfigureDelegateList.Add(easyDIConfigureDelegate);
            return this;
        }

        public IAsyncModelBuilder ConfigureFollowingDelegate(FollowingConfigureDelegate followingConfigureDelegate)
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
            return  (TModel)Activator.CreateInstance(
                typeof(TModel), 
                _statefulServiceContext,
                following,
                loggerService
                );
        }
    }
}
