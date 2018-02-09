using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class DestOperation
    {   
        /// <summary>
        /// 0 => -
        /// 1 => +
        /// </summary>
        public int OperationType { get; set; }

        public int DestPara { get; set; }
    }
}
