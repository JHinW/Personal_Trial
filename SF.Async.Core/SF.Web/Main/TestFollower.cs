using SF.Async.Core.Definitions;
using SF.Async.Org.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Web.Main
{
    public class TestFollower: FollowerBase
    {

        public override Task Process(MessageDefinition messageContext)
        {

            return Next?.Invoke(messageContext);
        }

    }
}
