using System;
using System.Numerics;
using System.Text;

namespace taskDEV3
{
    /// <summary>
    /// Class which stores decimal number's form
    /// and can convert it into some other radixs from 2 to 20
    /// </summary>
    class RadixConverter
    {
        // The idea is that we have 'A' with code 65 and if modulo is 10 or more, we have to 
        // use symbols starting from it in new radix number. DigitCode = 65 + (mudulo - 10);
        private const int AsciiRadixDigitBase = 55;
        BigInteger decimalNumber;
        int newRadix;
        
        public RadixConverter(BigInteger pDecimalNumber, int pNewRadix)
        {
            decimalNumber = pDecimalNumber;
            newRadix = pNewRadix;
            
        }

        /// <summary>
        /// Method converts decimal number into a number with another radix
        /// </summary>
        public void ConvertAndPrintNewRadixNumber()
        {
            StringBuilder numberInNewRadix = new StringBuilder();
            BigInteger bufferDecimalNumber = decimalNumber;
            while (bufferDecimalNumber > 0)
            {
                int modulo = (int)(bufferDecimalNumber % newRadix);
                if (modulo < 10)
                {
                    numberInNewRadix.Insert(0, modulo);
                }
                else
                {
                    char newRadixDigit = (char)(AsciiRadixDigitBase + modulo);
                    numberInNewRadix.Insert(0, newRadixDigit);
                }
                bufferDecimalNumber /= newRadix;
            }
            PrintNumberInNewRadix(numberInNewRadix);
        }
                    
        private void PrintNumberInNewRadix(StringBuilder numberInNewRadix)
        {
            Console.WriteLine($"Number {decimalNumber} in radix {newRadix} is {numberInNewRadix}");
        } 
    }
}
