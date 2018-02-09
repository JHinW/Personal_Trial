using SF.Async.EasyDI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Org.Usages
{
    public class ForkerTrackerImpl : ITracker
    {

        private Func<Type, Object> _trackerDelegate;


        public ForkerTrackerImpl(Func<Type, Object> trackerDelegate)
        {
            _trackerDelegate = trackerDelegate;
        }

        public object Track(Type type)
        {
            return _trackerDelegate?.Invoke(type);
        }
    }
}
