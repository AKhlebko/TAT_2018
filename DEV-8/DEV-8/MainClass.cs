using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DEV_8
{
    class MainClass
    {
        static void Main(string[] args)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Person[] readPersons;
                using (FileStream fs = new FileStream("people.txt", FileMode.OpenOrCreate))
                {
                    readPersons = (Person[])formatter.Deserialize(fs);
                    Console.WriteLine("Objects deserialized");
                    foreach (Person person in readPersons)
                    {
                        Console.WriteLine(person);
                    }
                }
                PeopleDataBase dataBase = new PeopleDataBase(readPersons);

                AddAnotherPersonToDataBaseCommand addAnotherPersonToDataBaseCommand = new AddAnotherPersonToDataBaseCommand();
                addAnotherPersonToDataBaseCommand.DataBase = dataBase;

                GetAverageAgeCommand getAverageAgeCommand = new GetAverageAgeCommand();
                getAverageAgeCommand.DataBase = dataBase;

                GetOldestPersonsCommand getOldestPersonsCommand = new GetOldestPersonsCommand();
                getOldestPersonsCommand.DataBase = dataBase;

                GetMostRelevantFemaleNameCommand getMostRelevantFemaleNameCommand = new GetMostRelevantFemaleNameCommand();
                getMostRelevantFemaleNameCommand.DataBase = dataBase;

                Menu menu = new Menu();
                menu.AddPersonToDataBase = addAnotherPersonToDataBaseCommand;
                menu.AverageAgeGetter = getAverageAgeCommand;
                menu.OldestPersonsGetter = getOldestPersonsCommand;
                menu.MostRelevantFemaleNameGetter = getMostRelevantFemaleNameCommand;

                dataBase.NamesakeDispatching += NamesakesToConsole;
                dataBase.NamesakeDispatching += NamesakesToFile;

                menu.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex}");
            }
        }

        static void NamesakesToConsole(object sender, NamesakeEventArg e)
        {
            Console.WriteLine($"Namesakes are: {e}");
        }

        static void NamesakesToFile(object sender, NamesakeEventArg e)
        {
            File.WriteAllText("namesakes.txt", $"Namesakes are: {e}");
        }
    }
}
