using System;

namespace DevTask1
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                SameSymbolSubstringFinder finder = new SameSymbolSubstringFinder(args[0]);
                Console.WriteLine(finder.LongestSubStringSameSymbols());
            }
            else
            {
                Console.WriteLine("Wrong arguments number.");
            }
        }
    }
}
