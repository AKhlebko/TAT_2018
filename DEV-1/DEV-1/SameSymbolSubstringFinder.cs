using System;

namespace DevTask1
{
    /// <summary>
    /// This class contains methods for getting string
    /// and for for finding the longest same character substring
    /// Stores processed string in a private field
    /// </summary>
    class SameSymbolSubstringFinder
    {
        private string processedString;

        /// <summary>
        /// SameSymbolSubstringFinder class's instance initializer
        /// </summary>
        /// <param name="arg">
        /// Gets the string from the console
        /// </param>            
        public SameSymbolSubstringFinder(string arg)
        {
            processedString = arg;
        }

        /// <summary>
        /// Finds the longest substring with same symbols
        /// </summary>
        /// <returns>
        /// Returns the length of the longest substring
        /// </returns>
        public int GetLongestSubStringSameSymbols()
        {
            int maxStringLength = 0;
            if (processedString.Length == 0)
            {
                return 0;
            }
            int start = 0;
            for (int i = 0; i < processedString.Length; i++)
            {   
                if (processedString[i] != processedString[start])
                {
                    ChangeStartPosAndMaxLength(ref maxStringLength, ref start, i-1);
                }
            }
            ChangeStartPosAndMaxLength(ref maxStringLength, ref start, processedString.Length - 1);
            return maxStringLength;
        }

        /// <summary>                       
        /// Compare buffer and max lines' lengths
        /// Change start's point
        /// </summary>
        /// <param name="maxLength">
        /// Max length of the same symbol string on this iteration 
        /// </param>
        /// <param name="start">
        /// Start point of temp line
        /// </param>
        /// <param name="end">
        /// End point of temp line 
        /// </param>
        public void ChangeStartPosAndMaxLength(ref int maxLength, ref int start, int end)
        {
            int tempLength = end - start + 1;
            if (tempLength > maxLength)
            {
                maxLength = tempLength;
            }
            start = end;
        } 
    }
}
