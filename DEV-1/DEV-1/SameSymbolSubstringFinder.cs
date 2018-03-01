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
        /// Returns length of the longest substring consisting of the same symbols
        /// </summary>
        public int LongestSubStringSameSymbols()
        {
            int maxStringLength = 0;
            if (processedString.Length == 0)
            {
                return 0;
            }
            for (int i = 0; i < processedString.Length - 1; i++)
            {
                int tempCounter = 1;
                int j = i + 1;
                while (j < processedString.Length)
                {
                    if (processedString[i] == processedString[j])
                    {
                        j++;
                        tempCounter++;
                    }
                    else
                    {
                        i = j - 1;
                        break;
                    }

                }
                if (tempCounter > maxStringLength)
                {
                    maxStringLength = tempCounter;
                }
            }
            return maxStringLength;
        }

        /// <summary>
        /// StringHandler class's instance initializer
        /// Gets console args as input arguments
        /// </summary>        
        public SameSymbolSubstringFinder(string arg)
        {
            processedString = arg;
        }
    }
}
