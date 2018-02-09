using System;
using System.Collections.Generic;
using System.Text;

namespace Reguration
{
    public class FileReader
    {
        public static string ReadAll(string path)
        {

            return System.IO.File.ReadAllText(path);
        }

        public static string[] ReadLines(string path)
        {
            return System.IO.File.ReadAllLines(path);
        }
    }
}
