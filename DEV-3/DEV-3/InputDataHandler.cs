using System;
using System.Numerics;

namespace taskDEV3
{
    enum InputMistakeType
    {
        WrongArgsNumber,
        WrongDecimalFormat,
        WrongDecimalSign,
        WrongRadixFormat,
        WrongRadixValue
    }

    /// <summary>
    /// Class for parsing console args and
    /// checking either their format is acceptable or not
    /// </summary>
    class InputDataHandler
    {
        public BigInteger decimalNumber { get; set; }
        public short newRadix { get; set; }
        string[] data;
        InputMistakeType firstFoundMistakeType;

        public InputDataHandler(string[] args)
        {
            data = args;
        }

        /// <summary>
        /// either unpack args into decimalNumer and newRadix
        /// if there are no format mistakes
        /// or places firstFindMistakeType mistake's type
        /// </summary>
        /// <returns>
        /// True if data format is right
        /// False if it's not
        /// </returns>
        public bool UnPackAndCheckDataFormat()
        {
            bool response = true;
            BigInteger bufferDecimal;
            short bufferRadix;
            if (data.Length != 2)
            {
                firstFoundMistakeType = InputMistakeType.WrongArgsNumber;
                response = false;                
            }
            else if (!BigInteger.TryParse(data[0], out bufferDecimal))
            {
                firstFoundMistakeType = InputMistakeType.WrongDecimalFormat;
                response = false;
            }
            else if (decimalNumber.Sign == -1)
            {
                firstFoundMistakeType = InputMistakeType.WrongDecimalSign;
                response = false;
            }
            else if (!short.TryParse(data[1], out bufferRadix))
            {
                firstFoundMistakeType = InputMistakeType.WrongRadixFormat;
                response = false;
            }
            else if (bufferRadix < 2 || bufferRadix > 20)
            {
                firstFoundMistakeType = InputMistakeType.WrongRadixValue;
                response = false;
            }
            else
            {
                decimalNumber = bufferDecimal;
                newRadix = bufferRadix;
            }
            return response;
        }

        /// <summary>
        /// Prints founded mistake type or 
        /// says that there are non of them
        /// </summary>                   
        public void PrintDataMistakeType()
        {
            switch (firstFoundMistakeType)
            {
                case InputMistakeType.WrongArgsNumber:
                    Console.WriteLine("ERROR: Wrong number of arguments.");
                    break;
                case InputMistakeType.WrongDecimalFormat:
                    Console.WriteLine("ERROR: Input decimal is not a number");
                    break;
                case InputMistakeType.WrongDecimalSign:
                    Console.WriteLine("ERROR: Can't convert negative numbers");
                    break;
                case InputMistakeType.WrongRadixFormat:
                    Console.WriteLine("ERROR: Input radix is not a number");
                    break;
                case InputMistakeType.WrongRadixValue:
                    Console.WriteLine($"ERROR: I can't conver this number to the {newRadix} radix");
                    break;
                default:
                    Console.WriteLine("There are no mistakes in input data");
                    break;
            }
        }
    }
}
