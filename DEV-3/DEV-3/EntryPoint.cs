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
                var converter = new RadixConverter(BigInteger.Parse(args[0]), int.Parse(args[1]));
                StringBuilder NumberInNewRadix = converter.GetNewRadixNumber();
                Console.WriteLine($"Number {converter.DecimalNumber} in new radix {converter.NewRadix} is {NumberInNewRadix}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("ERROR: " + ex.ParamName);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
    }
}