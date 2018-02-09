using SF.Async.Org.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SF.Async.Org.Delegates;

namespace SF.Async.Org.Usages
{
    public class CommonFollowing: FollowingBase
    {
        public CommonFollowing(MesageContextDelegate mesageContextDelegate) :base(mesageContextDelegate)
        {
        }
    }
}
