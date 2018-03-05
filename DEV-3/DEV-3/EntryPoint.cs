using System;
using System.Numerics;

namespace taskDEV3
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            BigInteger decimalNumer;
            short newRadix;
            if (args.Length != 2)
            {
                Console.WriteLine("ERROR: Wrong number of arguments.");
            }            
            else if (!BigInteger.TryParse(args[0], out decimalNumer))
            {
                Console.WriteLine("ERROR: Input decimal is not a number");
            }
            else if (decimalNumer.Sign == -1)
            {
                Console.WriteLine("ERROR: Can't convert negative numbers");
            }
            else if (!short.TryParse(args[1], out newRadix))
            {
                Console.WriteLine("ERROR: Input radix is not a number");
            }
            else if (newRadix > 2 && newRadix < 20)
            {
                RadixConvenet converter = new RadixConvenet(decimalNumer, newRadix);
                converter.ConvertNumberToNewRadix();
                converter.PrintNumberInNewRadix();
            }
            else
            {
                Console.WriteLine($"ERROR: I can't conver this number to the {newRadix} radix");
            }
        }
    }
}
