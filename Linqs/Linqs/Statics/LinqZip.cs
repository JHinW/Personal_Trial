using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linqs.Statics
{
    public static class LinqZip
    {
        public static void test()
        {
            int[] numbers = { 1, 2, 3, 4 };
            string[] words = { "one", "two", "three" };

            var numbersAndWords = numbers.Zip(words, (first, second) => first + " " + second);

            foreach (var item in numbersAndWords)
                Console.WriteLine(item);

            // This code produces the following output:

            // 1 one
            // 2 two
            // 3 three
        }
    }
}
