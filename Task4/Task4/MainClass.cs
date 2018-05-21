using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class MainClass
    {
        static void Main(string[] args)
        {
            try
            {
                var dataBase = new SimplePeopleDataBase();
                dataBase.InputPeople();
                dataBase.PrintPeople();
                Console.WriteLine(dataBase.GetGeneralInfo());
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
