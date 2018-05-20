using System;
using System.Numerics;
using System.Text;

namespace taskDEV3
{
    /// <summary>
    /// Class stores decimal number and
    /// has method for returning this number converted into another radix
    /// </summary>
    public class RadixConverter
    {
        // if modulo > 9 -> DigitCode = code('A') + (mudulo - 10);
        private const int AsciiRadixDigitBase = 55;
        public BigInteger DecimalNumber { get; set; }
        public int NewRadix { get; set; }

        /// <summary>
        /// Gets any decimal number above zero and new Radix in range of (2, 20)
        /// </summary>
        /// <param name="pDecimalNumber">
        /// Decimal number
        /// </param>
        /// <param name="pNewRadix">
        /// New Radix
        /// </param>
        public RadixConverter(BigInteger pDecimalNumber, int pNewRadix)
        {
            DecimalNumber = pDecimalNumber;
            NewRadix = pNewRadix;
            if (DecimalNumber.Sign == -1 || NewRadix < 2 || NewRadix > 20)
            {
                throw new ArgumentOutOfRangeException(paramName: "Invalid range of input decimal number or radix");
            }
        }

        /// <summary>
        /// Method converts decimal number into a number with another radix
        /// </summary>
        /// <returns>
        /// Returns StringBuilder with NumberInNewRadix
        /// </returns>
        public StringBuilder GetNewRadixNumber()
        {
            var numberInNewRadix = new StringBuilder();
            BigInteger bufferDecimalNumber = DecimalNumber;
            if (bufferDecimalNumber.IsZero)
            {
                numberInNewRadix.Append(0);
            }
            else
            {
                while (bufferDecimalNumber > 0)
                {
                    int modulo = (int)(bufferDecimalNumber % NewRadix);
                    if (modulo < 10)
                    {
                        numberInNewRadix.Insert(0, modulo);
                    }
                    else
                    {
                        char newRadixDigit = (char)(AsciiRadixDigitBase + modulo);
                        numberInNewRadix.Insert(0, newRadixDigit);
                    }
                    bufferDecimalNumber /= NewRadix;
                }
            }
            return numberInNewRadix;
        }
    }
}
