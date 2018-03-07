using System;
using System.Numerics;

namespace taskDEV3
{
    /// <summary>
    /// Class checks input data format and 
    /// if it's right prepare data for transfering into RadixConverter instance
    /// </summary>
    class InputDataChecker
    {
        string[] data;
        public BigInteger decimalNumber { get; set; }
        public int newRadix { get; set; }
        
        public InputDataChecker(string[] args)
        {
            data = args;
        }

        /// <summary>
        /// Parse input data, check it's format and 
        /// prepare it for futher transfering to RadixConventer instance
        /// </summary>
        /// <returns>
        /// Returns true if data format is right and data's been parsed correctly
        /// Returns false in any other situation
        /// </returns>
        public bool ParseAndCheckDataFormat()
        {
            bool response = true;
            try
            { 
                decimalNumber = BigInteger.Parse(data[0]);
                newRadix = int.Parse(data[1]); 
                if (newRadix < 2 || newRadix > 20)
                {
                    response = false;
                    throw new Exception("Radix value is out of correct range.");
                }
            }
            catch (IndexOutOfRangeException)
            {
                response = false;
                Console.WriteLine("Wrong number of console arguments.");
            }
            catch (FormatException ex)
            {
                response = false;
                if (ex.Source == "System.Numerics")
                {
                    Console.WriteLine("Decimal number format is not acceptable.");
                }
                else
                {
                    Console.WriteLine("Radix number format is not acceptable.");
                }  
            }
            catch (Exception ex)
            {
                response = false;
                Console.WriteLine(ex.Message);
            }
            return response;
        }
    }
}
