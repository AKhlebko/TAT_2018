using System;

namespace DevTask1
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            SameSymbolSubstringFinder handler = new SameSymbolSubstringFinder(args);
            Console.WriteLine(handler.LongestSubStringSameSymbols());
        }
    }
}
