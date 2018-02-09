using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDI.source
{
    public class Test1
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();

        public Test2 Test2 { get; set; }

        public Test1(Test2 test2)
        {
            Test2 = test2;
        }
    }
}
