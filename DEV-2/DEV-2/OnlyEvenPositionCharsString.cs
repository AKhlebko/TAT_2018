using System.Text;

namespace TaskDEV2
{
    /// <summary>
    /// Class contains methods for deleting all odd symbols 
    /// in the string using StringBilder
    /// </summary>
    public class OddIndexCharsDeleter
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
        /// Makes StringBuilder made of chars from
        /// processedStringBuilder which are on even indexes
        /// </summary>
        /// <returns>
        /// Returns made StringBuilder
        /// </returns>
        public StringBuilder MakeEvenIndexStringBulder()
        {
            StringBuilder outputEvenStringBuilder = new StringBuilder();
            for (int i = 0; i < processedStringBuilder.Length; i += 2)
            {
                outputEvenStringBuilder.Append(processedStringBuilder[i]);
            }
            return outputEvenStringBuilder;
        }
    }
}
