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
                menu.Work();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");   
            }
        }
    }
}
