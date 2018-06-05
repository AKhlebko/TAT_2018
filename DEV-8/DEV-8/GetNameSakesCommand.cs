using System.Collections.Generic;

namespace DEV_8
{
    /// <summary>
    /// Command for getting namesakes for a person
    /// </summary>
    class GetNamesakesCommand : ICommand
    {
        PeopleDataBase DataBase { get; set; }
        public Person PersonToFindNamesakes { get; set; }
        public List<Person> Namesakes { get; set; }

        public void Execute()
        {
            try
            { 
                Namesakes = DataBase.GetNamesakes(PersonToFindNamesakes);
            }
            catch
            {
                throw;
            }
        }
    }
}
