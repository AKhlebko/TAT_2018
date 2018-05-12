using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarIterable
{
    class ModelEnumerator : IEnumerator
    {
        public Car[] cars;
        int position = -1;

        public ModelEnumerator(params Car[] list)
        {
            cars = list;
        }
        public bool MoveNext()
        {
            position++;
            while (position < cars.Length)
            {
                if (Uniq(position))
                {
                    break;
                }
                position++;
            }
            return (position < cars.Length);
        }

        private bool Uniq(int pos)
        {
            bool response = true;
            for (int i = 0; i < pos; i++)
            {
                if (cars[pos].Model == cars[i].Model)
                {
                    response = false;
                    break;
                }
            }
            return response;
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
                    return cars[position].Model;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
