using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarIterable
{
    class AutoHouse : IEnumerable
    {
        private Car[] cars;
        private IEnumerator currentEnumerator;

        public AutoHouse()
        {
            cars = new Car[0];
        }

        public AutoHouse(string enumType, params Car[] cars)
        {
            this.cars = cars;
            if (enumType.ToLower() == "model")
            {
                currentEnumerator = new ModelEnumerator(cars);
            }
            else if (enumType.ToLower() == "car")
            {
                currentEnumerator = new CarEnumerator(cars);
            }
            else if (enumType.ToLower() == "company")
            {
                currentEnumerator = new CompanyEnumerator(cars);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return currentEnumerator;
        }
    }
}
