using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWcars.Selectors
{
    class MainPageSelectors
    {
        public static string BrandTypeForm = "//select[@name='brand_id[]']";
        public static string ModelTypeForm = "//select[@id='model_id']";
        public static string SubmitButton = "//button[@type='submit']";
    }
}
