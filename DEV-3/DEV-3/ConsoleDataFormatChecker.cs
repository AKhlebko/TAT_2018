using System;
using System.Numerics;

namespace taskDEV3
{
    /// <summary>
    /// Class has method for checking 
    /// commandLineArgs' format
    /// </summary>
    class ConsoleDataFormatChecker
    {
        string[] commandLineArgs;
        
        public ConsoleDataFormatChecker(string[] args)
        {
            commandLineArgs = args;
        }

        /// <summary>
        /// Checks commandLineArgs' format
        /// </summary>
        /// <returns>
        /// Returns true if data format is right
        /// Returns false if it's not
        /// </returns>
        public bool CheckInputDataFormat()
        {
            bool response = true;
            try
            {
                if (commandLineArgs.Length < 2 || commandLineArgs == null)
                {
                    throw new ArgumentOutOfRangeException("Wrong number of arguments.");
                }
                BigInteger decimalNumber = BigInteger.Parse(commandLineArgs[0]);
                if (decimalNumber.Sign == -1)
                {
                    throw new ArgumentOutOfRangeException("Can't convert negative numbers.");
                }
                int newRadix = int.Parse(commandLineArgs[1]);
                if (newRadix < 2 || newRadix > 20)
                {
                    throw new ArgumentOutOfRangeException("Radix value is out of correct range.");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }
    }
}
