using System;
using System.Collections.Generic;
using System.Linq;

namespace compare
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderByEx1();
            Console.WriteLine("Hello World!");
        }


        public static void OrderByEx1()
        {
            Pet[] pets = { new Pet { Name="Barley", Age=8 },
                   new Pet { Name="Boots", Age=4 },
                   new Pet { Name="Whiskers", Age=1 } };

            Array.Sort(pets, new Comparer());
            foreach(var pet in pets)
            {
                Console.WriteLine(pet.Age);
            }
        }
    }
}
