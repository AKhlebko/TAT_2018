using AWcars.AV;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace AWcars
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainPage = new MainPage(new ChromeDriver(@"C:\Users\User\Desktop"));
            (mainPage as MainPage).FindCars("bmw", "M5");
            (mainPage as MainPage).sortBy();
            (mainPage as MainPage).getCarWithLowestCost();
            Thread.Sleep(10000);
        }
    }
}
