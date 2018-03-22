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
                Terminal terminal = new Terminal(storage);
                ConsoleMenu menu = new ConsoleMenu();
                menu.SetCommandTerminal(terminal);
                menu.Work();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");   
            }
        }
    }
}
