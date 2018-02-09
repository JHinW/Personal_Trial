using System;
using System.Threading;

namespace JsonConfig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = ConfigureReader.CreateConfig("appsettings.json");

            Console.WriteLine($"option1 = {config["option1"]}");
            Console.WriteLine($"option2 = {config["option2"]}");
            Console.WriteLine(
                $"suboption1 = {config["subsection:suboption1"]}");
            Console.WriteLine();

            Console.WriteLine("Wizards:");
            Console.Write($"{config["wizards:0:Name"]}, ");
            Console.WriteLine($"age {config["wizards:0:Age"]}");
            Console.Write($"{config["wizards:1:Name"]}, ");
            Console.WriteLine($"age {config["wizards:1:Age"]}");
            Console.WriteLine();
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
