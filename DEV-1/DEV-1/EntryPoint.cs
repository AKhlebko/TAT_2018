using System;

namespace DevTask1
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            SameSymbolSubtringFinder handler = new SameSymbolSubtringFinder(args);
            Console.WriteLine(handler.LongestSubStringSameSymbols());
        }
    }
}
