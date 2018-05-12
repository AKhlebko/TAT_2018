using OpenQA.Selenium;
using AWcars.Selectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWcars.AV
{
    class MainPage
    {
        IWebDriver Driver { get; set; }
        IWebElement brandForm;
        IWebElement modelForm;
        IWebElement submitButton;

        public MainPage(IWebDriver driver)
        {
            Driver = driver;
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://av.by/");
            brandForm = Driver.FindElement(By.XPath(MainPageSelectors.BrandTypeForm));
            modelForm = Driver.FindElement(By.XPath(MainPageSelectors.ModelTypeForm));
            submitButton = Driver.FindElement(By.XPath(MainPageSelectors.SubmitButton));
        }

        public void getCarWithLowestCost()
        {
            Console.WriteLine(Driver.FindElements(By.XPath("//div[@class='listing-item']"))[0].FindElement(
                By.XPath("//strong")).Text
                );
        }

        public void FindCars(string brand, string model)
        {
            brandForm.Click();
            brandForm.SendKeys(brand);
            brandForm.SendKeys(Keys.Enter);

            modelForm.Click();
            modelForm.SendKeys(model);
            modelForm.SendKeys(Keys.Enter);

            submitButton.Click();
        }

        public void sortBy()
        {
            Driver.FindElement(By.XPath(SearchPageSelectors.SortButton)).Click();
        }
    }
}
