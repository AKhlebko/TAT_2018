using System;
using System.Numerics;
using System.Text;

namespace taskDEV3
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 2)
                {
                    throw new Exception("Wrong number of argumets.");
                }
                BigInteger decimalNumber = BigInteger.Parse(args[0]);
                int newRadix = int.Parse(args[1]);
                if (newRadix < 2 || newRadix > 20)
                {
                    throw new Exception("Radix value is out of correct range.");
                }
                RadixConverter converter = new RadixConverter(decimalNumber, newRadix);
                StringBuilder NumberInNewRadix = converter.GetNewRadixNumber();
                Console.WriteLine($"Number {decimalNumber} in new radix {newRadix} is {NumberInNewRadix}");
            }
            catch (FormatException ex)
            {
                if (ex.Source == "System.Numerics")
                {
                    Console.WriteLine("ERROR: Decimal number format is not acceptable.");
                }
                else
                {
                    Console.WriteLine("ERROR: Radix number format is not acceptable.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
    }
}