using System;

namespace TaskDEV11Consumer
{
    /// <summary>
    /// Class which asks user to input date
    /// </summary>
    public class DateFromConsoleGetter
    {
        /// <summary>
        /// Method interacts with user to input date
        /// </summary>
        /// <returns>
        /// date in a format DD/MM/YYYY
        /// </returns>
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