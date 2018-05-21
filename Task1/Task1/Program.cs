using System;
using System.Text;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!\n" +
                "And hi again!");
            var str = new StringBuilder();
            for (int i = 0; i < (new Random()).Next(45) + 5; i++)
            {
                str.Append("!");
            }
            Console.WriteLine(str);
        }
    }
}
