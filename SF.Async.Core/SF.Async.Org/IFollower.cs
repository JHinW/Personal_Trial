using SF.Async.Core.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SF.Async.Org.Delegates;

namespace SF.Async.Org
{
    public interface IFollower
    {
        MesageContextDelegate Next { get; set; }

        Task Process(MessageDefinition messageContext);
    }
}
