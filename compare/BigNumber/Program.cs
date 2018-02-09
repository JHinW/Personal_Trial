using System;

namespace BigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] temp = null;

            int[] inputs = {
                12, 12,
                24, 123345,
                12345, 1233
            };

            int[] input2 = {
                12, 12111115
            };


            int[] input3 = {
                12, 12131115
            };


            //temp = inputs;
            temp = input3;
            Array.Sort(temp, new Comparer());

            foreach (var num in temp)
            {
                Console.WriteLine(num);
            }
            //Console.WriteLine("::");
            Console.WriteLine("-------------------------------------");
            //Console.WriteLine("::");
            var outs = "";
            foreach (var num in temp)
            {
                outs = outs + num.ToString();
            }

            Console.WriteLine(outs);
        }
    }
}
