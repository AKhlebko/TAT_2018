using System.Numerics;
using System.Text;

namespace taskDEV3
{
    /// <summary>
    /// Class stores decimal number and
    /// has method for returning this number converted into another radix
    /// </summary>
    class RadixConverter
    {
        // if modulo > 9 -> DigitCode = code('A') + (mudulo - 10);
        private const int AsciiRadixDigitBase = 55;
        public BigInteger decimalNumber { get; set; }
        public int newRadix { get; set; }

        public RadixConverter(BigInteger pDecimalNumber, int pNewRadix)
        {
            decimalNumber = pDecimalNumber;
            newRadix = pNewRadix;
        }

        /// <summary>
        /// Method converts decimal number into a number with another radix
        /// </summary>
        /// <returns>
        /// Returns StringBuilder with NumberInNewRadix
        /// </returns>
        public StringBuilder GetNewRadixNumber()
        {
            StringBuilder numberInNewRadix = new StringBuilder();
            BigInteger bufferDecimalNumber = decimalNumber;
            if (bufferDecimalNumber.IsZero)
            {
                numberInNewRadix.Append(0);
            }
            else
            {
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
            }
            return numberInNewRadix;
        }
    }
}
