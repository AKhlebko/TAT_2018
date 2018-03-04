using System;
using System.Text;

namespace TaskDEV2
{
    /// <summary>
    /// Class contains methods for deleting all odd symbols 
    /// in the string using StringBilder
    /// </summary>
    class OddIndexCharsDeleter
    {
        StringBuilder processedStringBuilder;

        /// <summary>
        /// Initializer for class's instances
        /// </summary>
        /// <param name="str">
        /// string parameter for 
        /// processedStringBuilder assignment
        /// </param>
        public OddIndexCharsDeleter(string str)
        {
            processedStringBuilder = new StringBuilder(str);
        }

        /// <summary>
        /// Method prints string builder from GetEvenInderStringBuilder 
        /// </summary>
        public void PrintOnlyEvenPositionChars()
        {
            Console.WriteLine($"String with only even position chars - {GetEvenIndexStringBulder()}");
        }

        /// <summary>
        /// Makes StringBuilder made of chars from
        /// processedStringBuilder which are on even indexes
        /// </summary>
        /// <returns>
        /// Returns made StringBuilder
        /// </returns>
        private StringBuilder GetEvenIndexStringBulder()
        {
            StringBuilder outputEvenStringBuilder = new StringBuilder();
            for (int evenPos = 0; evenPos < processedStringBuilder.Length; evenPos += 2)
            {
                outputEvenStringBuilder.Append(processedStringBuilder[evenPos]);
            }
            return outputEvenStringBuilder;
        }
        
    }
}
