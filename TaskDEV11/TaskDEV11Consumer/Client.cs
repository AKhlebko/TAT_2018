using System;
using TaskDEV11;

namespace TaskDEV11Consumer
{
    class Client
    {
        static void Main(string[] args)
        {
            try
            {
                DaysFromBC service = new DaysFromBC();
                string date = (new DateFromConsoleGetter()).GetDateFromConsole();
                int daysFromBC = service.CountDaysFromBC(date);
                Console.WriteLine($"It's been {daysFromBC} until {date} since the BC");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.ParamName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
