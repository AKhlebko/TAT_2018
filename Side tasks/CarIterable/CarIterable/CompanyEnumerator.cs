using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarIterable
{
    class CompanyEnumerator : IEnumerator
    {
        public Car[] cars;
        int position = -1;

        public CompanyEnumerator(params Car[] list)
        {
            cars = list;
        }
        public bool MoveNext()
        {
            position++;
            return (position < cars.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public string Current
        {
            get
            {
                try
                {
                    return cars[position].Company;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
