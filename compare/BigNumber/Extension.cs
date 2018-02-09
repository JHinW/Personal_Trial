using System;
using System.Collections.Generic;
using System.Text;

namespace BigNumber
{
    public static class Extension
    {
        public static int[] As5NumArray(this Int32 number)
        {
            Int32[] ret = new Int32[32];
            var tempStack = new Stack<Int32>();
            var currenNum = number;

            while(currenNum> 0)
            {
                tempStack.Push(currenNum%10);
                currenNum = (Int32)(currenNum / 10);
            }
            var arr = tempStack.ToArray();

           // Array.Reverse(arr);

            return arr;
        }
    }
}
