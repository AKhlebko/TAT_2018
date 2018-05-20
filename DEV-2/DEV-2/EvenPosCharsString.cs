using System.Text;

namespace TaskDEV2
{
    /// <summary>
    /// Class for gettings string with
    /// chars on the even indexes
    /// </summary>
    public class EvenPosCharsString
    {
        StringBuilder processedStringBuilder;

        /// <summary>
        /// Initializer for class's instances
        /// </summary>
        /// <param name="str">
        /// string parameter for 
        /// processedStringBuilder assignment
        /// </param>
        public EvenPosCharsString(string str)
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
        public StringBuilder GetEvenPossStringBuilder()
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
