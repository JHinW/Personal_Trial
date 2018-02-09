using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDI.source
{
    public class Test
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();

        public Test1 Test1 { get; set; }

        public Test2 Test2 { get; set; }

        public Test(Test1 test1, Test2 test2)
        {
            Test1 = test1;
            Test2 = test2;

        }

    }
}
