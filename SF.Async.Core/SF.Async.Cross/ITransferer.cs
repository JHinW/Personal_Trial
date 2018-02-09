using Microsoft.ServiceFabric.Services.Remoting;
using SF.Async.Core.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Cross
{
    public interface ITransferer: IService
    {
        Task DataTansfer(MessageDefinition data);


        Task<Object> DataTansferForResultAsync(MessageDefinition data);
    }
}
