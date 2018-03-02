using System;

namespace DevTask1
{
    /*
        This class contains methods for getting string
        and for for finding the longest same character substring
        Stores processed string in a private field
    */
    /// <summary>
    /// This class contains methods for getting string
    /// and for for finding the longest same character substring
    /// Stores processed string in a private field
    /// </summary>
    class SameSymbolSubstringFinder
    {
        private string processedString;
                                                
        /// <summary>
        /// StringHandler class's instance initializer
        /// Gets console args as input arguments 
        /// </summary>
        /// <param name="arg"></param>            
        public SameSymbolSubstringFinder(string arg)
        {
            processedString = arg;
        }

        /// <summary>
        /// Finds the longest substring with same symbols
        /// </summary>
        /// <returns>
        /// The length of the longest substring
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
                    ChangeStartPosAndMaxLength(ref maxStringLength, ref start, i);
                }
            }
            ChangeStartPosAndMaxLength(ref maxStringLength, ref start, processedString.Length - 1);
            return maxStringLength;
        }

        /// <summary>
        /// Private method for comparasing maxSymbolStringLength with tempLength 
        /// of the string between end and start points
        /// replaces maxSamsSymbolLength when it's smaller then tempLength
        /// replaces start point with end one
        /// </summary>
        /// <param name="maxLength"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
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
