using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Core
{
    public interface IMiddleWareReducer<Tin, Tout> 
        where Tin: class 
        where Tout: class
    {
        Tout Porcess(Tin data);
    }
}
