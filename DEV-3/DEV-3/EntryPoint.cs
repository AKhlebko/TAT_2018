using System;
using System.Numerics;

namespace taskDEV3
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            InputDataHandler handler = new InputDataHandler(args);
            if (handler.UnPackAndCheckDataFormat())
            {
                RadixConverter converter = new RadixConverter(handler.decimalNumber, handler.newRadix);
                converter.ConvertNumberToNewRadix();
                converter.PrintNumberInNewRadix();
            }
            else
            {
                handler.PrintDataMistakeType();
            }
        }
    }
}
