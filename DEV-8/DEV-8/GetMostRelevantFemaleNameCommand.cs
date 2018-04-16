using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_8
{
    class GetMostRelevantFemaleNameCommand : ICommand
    {
        public PeopleDataBase DataBase { get; set; }
        public string MostRelevanceName { get; set; }

        public void Execute()
        {
            try
            {
                MostRelevanceName = DataBase.GetMostRelevantFemaleName();
            }
            catch
            {
                throw;
            }
        }
    }
}
