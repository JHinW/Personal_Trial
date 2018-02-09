using Reguration;
using System;

namespace RegularExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = FileReader.ReadAll(@"inputs.txt");

            String inputs = null;
            int ctr = 0;
            do
            {

                //Console.Clear();
                Console.WriteLine("Please input>>>>>>");
                inputs = Console.ReadLine();

                Console.WriteLine("Line {0}: {1}", ctr, inputs);
                var ret = Search.GetMatchedLine(inputs, source);
                if (ret.isMactched)
                {
                    Console.WriteLine(ret.outputs);
                }
                else
                {
                    Console.WriteLine("no result!");
                }
                

            } while (inputs != null);

           
            
        }
    }
}
