using SF.Async.Core.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Org
{
    public interface IFollowing
    {
        Task CatchAsync(MessageDefinition message);
    }
}
