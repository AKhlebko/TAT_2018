using System;

namespace taskDEV3
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 2 || args == null)
                {
                    throw new Exception("Wrong number of argumets.");
                }
                InputDataPreparer preparer = new InputDataPreparer(args);
                if (preparer.PrepareData())
                {
                    RadixConverter converter = new RadixConverter(preparer.decimalNumber, preparer.newRadix);
                    converter.ConvertAndPrintNewRadixNumber();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
    }
}
