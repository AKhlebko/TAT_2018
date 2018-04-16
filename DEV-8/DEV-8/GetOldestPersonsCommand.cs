using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_8
{
    class GetOldestPersonsCommand: ICommand 
    {
        public PeopleDataBase DataBase { get; set; }
        public List<Person> OldestPeople { get; set; }

        public void Execute()
        {
            try
            {
                OldestPeople = DataBase.GetOldestPersons();
            }
            catch
            {
                throw;
            }
        }
    }
}
