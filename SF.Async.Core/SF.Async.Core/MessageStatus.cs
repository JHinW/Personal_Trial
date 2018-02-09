using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Core
{
    public enum MessageStatus
    {
        Initial = 0,
        Ready = 1,
        Waiting = 2,
        End =3
    }
}
