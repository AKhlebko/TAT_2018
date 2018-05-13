using System;

namespace TaskDEV11Consumer
{
    public class DateFromConsoleGetter
    {
        public string GetDateFromConsole()
        {
            Console.Write("Input Day: ");
            string Day = Console.ReadLine();
            Console.Write("Input Month: ");
            string Month = Console.ReadLine();
            Console.Write("Input Year: ");
            string Year = Console.ReadLine();
            return $"{Day}/{Month}/{Year}";
        }
    }
}