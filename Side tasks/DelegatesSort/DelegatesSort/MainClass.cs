using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesSort
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random rand = new Random();
            int length = 10;
            double[] array = new double[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = rand.NextDouble() * 100;
            }
            ArrayClass arrayClass = new ArrayClass(array);
            arrayClass.Sort(BubleSort);
            arrayClass.Print();
        }

        public static void BubleSort(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        double temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        
    }
}
