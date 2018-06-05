using System;

namespace DEV_8
{
    /// <summary>
    /// Command for getting most frequent female name
    /// </summary>
    class GetMostFrequentFemaleNameCommand : ICommand
    {
        public PeopleDataBase DataBase { get; set; }
        public string MostRelevanceName { get; set; }

        public void Execute()
        {
            try
            {
                Console.WriteLine($"Most relevant female name is {DataBase.GetMostFrequentFemaleName()}");
            }
            catch
            {
                throw;
            }
        }
    }
}
