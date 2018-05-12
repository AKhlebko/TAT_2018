using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarIterable
{
    class Car
    {
        private string model;
        private string company;

        public Car()
        {
            model = string.Empty;
            company = string.Empty;
        }

        public Car(string Model, string Company)
        {
            model = Model;
            company = Company;
        }

        public string Model
        {
            get
            {
                return model;
            }        
        }

        public string Company
        {
            get
            {
                return company;
            }
        }

        public override string ToString()
        {
            return $"Car: {company} - {model}";
        }
    }
}
