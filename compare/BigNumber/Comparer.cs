using System;
using System.Collections.Generic;

namespace BigNumber
{
    public class Comparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            var first = x.As5NumArray();
            var last = y.As5NumArray();
            if(first.Length < last.Length)
            {
                var loop = 0;
                var firstIndex = 0;
                while(loop < last.Length)
                {
                    //var ret=  first[firstIndex].CompareTo(last[loop]);
                    var ret = last[loop].CompareTo(first[firstIndex]);
                    if (ret != 0)
                    {
                        return ret;
                    }
                    
                    loop++;
                    firstIndex = loop % first.Length;
                }
            }
            else
            {

                var loop = 0;
                var firstIndex = 0;
                while (loop < first.Length)
                {
                    //var ret=  first[firstIndex].CompareTo(last[loop]);
                    var ret = last[firstIndex].CompareTo(first[loop]);
                    if (ret != 0)
                    {
                        return ret;
                    }
                    
                    loop++;
                    firstIndex = loop % last.Length;
                }

            }

            return 0;
        }
    }
}
