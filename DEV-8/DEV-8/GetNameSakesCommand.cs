using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_8
{
    class GetNameSakesCommand : ICommand
    {
        PeopleDataBase DataBase { get; set; }
        public Person PersonToFindNamesakes { get; set; }
        public List<Person> Namesakes { get; set; }

        public void Execute()
        {
            try
            { 
                Namesakes = DataBase.GetNameSakes(PersonToFindNamesakes);
            }
            catch
            {
                throw;
            }
        }
    }
}
