using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Async.Core.Definitions;

namespace SF.Async.Org.Abstractions
{
    public abstract class FollowerBase : IFollower
    {

        public FollowerBase()
        {
        }

        public Delegates.MesageContextDelegate Next { get; set; }

        public virtual Task Process(MessageDefinition messageContext)
        {

            return Next?.Invoke(messageContext);
        }
    }
}
