using System;

namespace DevTask1
{
    class SameSymbolSubstringFinder
    {
        /// <summary>
        /// This class contains methods for getting string
        /// and for for finding the longest same character substring
        /// Stores processed string in a private field
        /// </summary>        
        private string str;

        public int LongestSubStringSameSymbols()
        {
            /// <summary>
            /// Returns length of the longest substring consisting of the same symbols
            /// </summary>
            int MaxStringLength = 0;
            if (str.Length == 0)
            {
                return 0;
            }
            for (int i = 0; i < str.Length - 1; i++)
            {
                int tempCounter = 1;
                int j = i + 1;
                while (j < str.Length)
                {
                    try
                    {
                        if (str[i] == str[j])
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
                    catch (IndexOutOfRangeException ex)
                    {

                    }
                }
                if (tempCounter > MaxStringLength)
                {
                    MaxStringLength = tempCounter;
                }
            }
            return MaxStringLength;
        }

        public SameSymbolSubstringFinder(string[] args)
        {
            /// <summary>
            /// StringHandler class's instance initializer
            /// Gets console args as input arguments
            /// </summary>        
            if (args.Length == 0)
            {
                str = "";
            }
            else
            {
                GetStringFromArguments(args);
            }
        }

        private void GetStringFromArguments(string[] args)
        {
            /// <summary>
            /// Makes string from the console arguments
            /// </summary>        
            str = String.Join("", args);
            return;
        }
    }
}
