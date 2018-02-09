using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Core
{
    public interface IContentBox
    {
        string Type { get; set; }

        string PayLoad { get; set; }
    }
}
