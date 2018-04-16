using System;

namespace DEV_8
{
    /// <summary>
    /// Command for getting average age in the database
    /// </summary>
    class GetAverageAgeCommand : ICommand
    {
        public PeopleDataBase DataBase { get; set; }
        public int AverageAge { get; set; }

        public void Execute()
        {
            try
            {
                Console.WriteLine($"Average peoples' age in the database is {DataBase.GetAverageAge()}");
            }
            catch
            {
                throw;
            }
        }
    }
}
