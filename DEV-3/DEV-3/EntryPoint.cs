namespace taskDEV3
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            InputDataChecker preparer = new InputDataChecker(args);
            if (preparer.ParseAndCheckDataFormat())
            {
                RadixConverter converter = new RadixConverter(preparer.decimalNumber, preparer.newRadix);
                converter.ConvertAndPrintNewRadixNumber();
            }
        }
    }
}
