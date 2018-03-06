using System;
using System.Numerics;
using System.Text;

namespace taskDEV3
{
    /// <summary>
    /// Class which stores decimal number's form
    /// and can switch it into some other radixs from 2 to 20
    /// </summary>
    class RadixConverter
    {
        BigInteger decimalNumber;
        short newRadix;
        StringBuilder numberInNewRadix;
        
        public RadixConverter(BigInteger pDecimalNumber, short pNewRadix)
        {
            decimalNumber = pDecimalNumber;
            newRadix = pNewRadix;
            numberInNewRadix = new StringBuilder();
        }

        /// <summary>
        /// Method converts decimal number into a number with another radix
        /// I count it with charCode = Code('A') + modulo - 10 = 
        /// = 55 + modulo;
        /// </summary>
        public void ConvertNumberToNewRadix()
        {
            BigInteger bufferDecimalNumber = decimalNumber;
            while (bufferDecimalNumber > 0)
            {
                short modulo = (short)(bufferDecimalNumber % newRadix);
                if (modulo < 10)
                {
                    numberInNewRadix.Insert(0, modulo);
                }
                else
                {
                    char newRadixDigit = (char)(55 + modulo);
                    numberInNewRadix.Insert(0, newRadixDigit);
                }
                bufferDecimalNumber /= newRadix;
            }
        }
        
        /// <summary>
        /// Prints the number in the new Radix
        /// </summary>            
        public void PrintNumberInNewRadix()
        {
            Console.WriteLine($"Number {decimalNumber} in radix {newRadix} is {numberInNewRadix}");
        } 
    }
}
