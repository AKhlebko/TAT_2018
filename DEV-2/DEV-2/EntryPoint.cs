using System;
using System.Text;

namespace TaskDEV2
{
    class EntryPoint
    {
        static void Main(string[] args)
        { 
            Console.Write("Input string to delete odd positions chars: ");
            string inputString;
            inputString = Console.ReadLine();
            while (inputString.Length == 0)
            {
                Console.Write("Input not empty string: ");
                inputString = Console.ReadLine();
            }
            OddIndexCharsDeleter evener = new OddIndexCharsDeleter(inputString);
            evener.PrintOnlyEvenPositionChars();
        }       
    }
}