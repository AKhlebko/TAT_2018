using System;

namespace DEV_6
{
    class EntryClass
    {
        static void Main(string[] args)
        {
            try
            {
                Storage storage = new Storage();
                ConsoleMenu menu = new ConsoleMenu(storage);
                menu.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");   
            }
        }
    }
}
