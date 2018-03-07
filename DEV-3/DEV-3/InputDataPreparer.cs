using System;
using System.Numerics;

namespace taskDEV3
{
    /// <summary>
    /// Class checks input data format and 
    /// if it's right prepare data for transfering into RadixConverter instance
    /// </summary>
    class InputDataPreparer
    {
        string[] commandLineData;
        public BigInteger decimalNumber { get; set; }
        public int newRadix { get; set; }
        
        public InputDataPreparer(string[] args)
        {
            commandLineData = args;
        }

        /// <summary>
        /// Prepares command line data for futher
        /// transfering into RadixConverter instance
        /// </summary>
        /// <returns>
        /// Returns true if data format is right and data's been prepared correctly
        /// Returns false in any other situation
        /// </returns>
        public bool PrepareData() 
        {
            bool response = true;
            try
            {
                decimalNumber = BigInteger.Parse(commandLineData[0]);
                if (decimalNumber.Sign == -1)
                {
                    throw new Exception("I can't convert negative numbers.");
                }
                newRadix = int.Parse(commandLineData[1]);
                if (newRadix < 2 || newRadix > 20)
                {
                    response = false;
                    throw new Exception("Radix value is out of correct range.");
                }
            }
            catch (FormatException ex)
            {
                response = false;
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
                response = false;
                Console.WriteLine("ERROR: " + ex.Message);
            }
            return response;
        }
    }
}
