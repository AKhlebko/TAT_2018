using System;
using System.Text;

namespace DelegatesSort
{
    class ArrayClass
    {
        private double[] array;
        public delegate void DelegatedSort(double[] pArray);

        public ArrayClass()
        {
            array = new double[0];

        }

        public ArrayClass(double[] pArray)
        {
            array = pArray;
        }

        public void Sort(DelegatedSort sort)
        {
            DelegatedSort delegatedSort = new DelegatedSort(sort);
            delegatedSort(array);
        }

        public void Print()
        {
            StringBuilder response = new StringBuilder("[");
            for(int i = 0; i < array.Length - 1; i++)
            {
                response.Append($"{array[i]:00}, ");
            }
            response.Append($"{array[array.Length - 1]:00}]");
            Console.WriteLine(response);
        }
    }
}