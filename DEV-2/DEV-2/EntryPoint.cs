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
            var evener = new EvenPosCharsString(inputString);
            StringBuilder onlyEvenPosCharsBuilder =  evener.GetEvenPossStringBuilder();
            Console.WriteLine(onlyEvenPosCharsBuilder); 
        }       
    }
}