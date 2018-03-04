using System;
using System.Text;

namespace TaskDEV2
{
    /// <summary>
    /// Class contains methods for deleting all odd symbols 
    /// in the string using StringBilder
    /// </summary>
    class OnlyEvenPositionCharsString
    {
        StringBuilder processedString;

        /// <summary>
        /// Initializer for class's instances
        /// </summary>
        /// <param name="str">
        /// StringBuilder parameter for 
        /// processedString assignment
        /// </param>
        public OnlyEvenPositionCharsString(StringBuilder str)
        {
            processedString = str;
        }
        
        /// <summary>
        /// Method for leaves only even positions char
        /// in the processedString
        /// </summary>
        public void LeaveOnlyEvenPositionChars()
        {
            if (processedString.Length < 2)
            {
                return;
            }
            int deletePos = 1;
            while (deletePos < processedString.Length)
            {
                processedString.Remove(deletePos, 1);
                deletePos++;
            }
            Console.WriteLine($"String with only even position chars - {processedString}");
        }     
    }
}
