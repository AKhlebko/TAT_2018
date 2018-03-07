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
                ConsoleDataFormatChecker checker = new ConsoleDataFormatChecker(args);
                if (checker.CheckInputDataFormat())
                {
                    RadixConverter converter = new RadixConverter(BigInteger.Parse(args[0]), int.Parse(args[1]));
                    StringBuilder NumberInNewRadix = converter.GetNewRadixNumber();
                    Console.WriteLine($"Number {converter.decimalNumber} in new radix {converter.newRadix} is {NumberInNewRadix}");
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("ERROR: " + ex.ParamName);
            }
            catch (FormatException ex)
            {
                if (ex.Source == "System.Numerics")
                {
                    Console.WriteLine("ERROR: Wrong decimal number format.");
                }
                else
                {
                    Console.WriteLine("ERROR: Wrong radix format.");
                }
            }
        }
    }
}