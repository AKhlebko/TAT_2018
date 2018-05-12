using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarIterable
{
    class CarEnumerator : IEnumerator
    {
        public Car[] cars;
        int position = -1;

        public CarEnumerator(params Car[] list)
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

        public Car Current
        {
            get
            {
                try
                {
                    return cars[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
