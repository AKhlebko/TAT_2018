using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class MainClass
    {
        static void Main(string[] args)
        {
            try
            {
                (new FileSearcher(args[0], args[1])).SearchFiles();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
