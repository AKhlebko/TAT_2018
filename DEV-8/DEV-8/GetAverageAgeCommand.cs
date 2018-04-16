using System;

namespace DEV_8
{
    class GetAverageAgeCommand : ICommand
    {
        public PeopleDataBase DataBase { get; set; }
        public int AverageAge { get; set; }

        public void Execute()
        {
            try
            {
                AverageAge = DataBase.GetAverageAge();
            }
            catch
            {
                throw;
            }
        }
    }
}
