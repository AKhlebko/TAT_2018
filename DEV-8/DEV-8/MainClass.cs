using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

                GetOldestPeopleCommand getOldestPersonsCommand = new GetOldestPeopleCommand();
                getOldestPersonsCommand.DataBase = dataBase;

                GetMostFrequentFemaleNameCommand getMostRelevantFemaleNameCommand = new GetMostFrequentFemaleNameCommand();
                getMostRelevantFemaleNameCommand.DataBase = dataBase;

                Menu menu = new Menu();
                menu.PeopleToDataBaseAdder = addAnotherPersonToDataBaseCommand;
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
            Console.WriteLine($"\nNamesakes for input person are: \n{e}");
        }

        static void NamesakesToFile(object sender, NamesakeEventArg e)
        {
            File.WriteAllText("namesakes.txt", $"Namesakes for input person are: \n{e}");
        }
    }
}
