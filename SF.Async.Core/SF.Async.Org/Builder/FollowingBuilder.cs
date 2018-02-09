using SF.Async.EasyDI;
using SF.Async.Org.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SF.Async.Org.Delegates;

namespace SF.Async.Org.Builder
{
    using MesageContextDelegateComp = Func<MesageContextDelegate, MesageContextDelegate>;

    public class FollowingBuilder : IFollowingBuilder
    {
        private IList<MesageContextDelegateComp> _mesageContextDelegateCompList = new List<MesageContextDelegateComp>();


        private ITracker _tracker;

        public FollowingBuilder(ITracker tracker)
        {
            _tracker = tracker;
        }

        public Tfollowing FollowingBuild<Tfollowing>() where Tfollowing : FollowingBase
        {
            MesageContextDelegate app = context =>
            {
                return Task.CompletedTask;
            };

            foreach (var component in _mesageContextDelegateCompList.Reverse())
            {
                app = component(app);
            }

            return (Tfollowing)Activator.CreateInstance(typeof(Tfollowing), app);
        }

        public object GetService(Type type)
        {
            return _tracker.Track(type);
        }

        public IFollowingBuilder UseFollower(MesageContextDelegateComp messageDelegateComp)
        {
            _mesageContextDelegateCompList.Add(messageDelegateComp);
            return this;
        }
    }
}
