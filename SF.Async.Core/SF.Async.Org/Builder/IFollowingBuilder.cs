using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SF.Async.Org.Delegates;

namespace SF.Async.Org.Builder
{
    using MesageContextDelegateComp = Func<MesageContextDelegate, MesageContextDelegate>;
    public interface IFollowingBuilder
    {
        IFollowingBuilder UseFollower(MesageContextDelegateComp mesageContextDelegateComp);

        Object GetService(Type type);
    }
}
