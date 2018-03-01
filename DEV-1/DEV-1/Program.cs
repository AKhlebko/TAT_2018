using System;

namespace EntryPoint
{
    class StringHandler
    {
        // Class contain method for handling strings without storing them
        public static int LongestEqualSymbols(string str)
        {
            // Return length of substring which consists of same symbols
            // The aim of static here is to hadle lines
            // withous creating instance of StringHandler class
            int length = 0;
            for (int i = 0; i < str.Length; i++)
            {
                Boolean equal = true;
                int buffer = 0;
                int j = i;
                while (equal && j < str.Length)
                {
                    if (str[i] == str[j])
                    {
                        j++;
                        buffer++;
                    }
                    else
                    {
                        equal = false;
                    }
                }
                if (buffer > length) length = buffer;
            }
            return length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Console.WriteLine(StringHandler.LongestEqualSymbols(line));
        }
    }
}
