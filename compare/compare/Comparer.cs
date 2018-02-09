using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace compare
{
    public class Comparer : IComparer<Pet>
    {

        public int Compare(Pet x, Pet y)
        {
            var ret=  x.Age.CompareTo(y.Age);
            Console.WriteLine($"x=>{x.Age}; y=>{y.Age}; ret: {ret}");
            return ret;
        }
    }
}
