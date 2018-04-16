using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_8
{
    class AddAnotherPersonToDataBaseCommand : ICommand
    {
        public PeopleDataBase DataBase { get; set; }
        public Person PersonToAdd { get; set; }

        public void Execute()
        {
            try
            {
                DataBase.AddPerson(PersonToAdd);
            }
            catch
            {
                throw;
            }
        }
    }
}
