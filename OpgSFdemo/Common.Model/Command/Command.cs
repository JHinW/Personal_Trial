using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class Command
    {
        public int SourceOperationPara { get; set; }

        public IList<DestOperation> DestOperation { get; set; } = new List<DestOperation>();

        public DestOperation CurrentOperation { get; set; } 
    }
}
