using OpenQA.Selenium;
using System.Collections.Generic;
using taskDEV10.AVLocators;

namespace taskDEV10.Objected_pages
{
    /// <summary>
    /// Main av.by's page
    /// </summary>
    class MainPage : CurrentAWPage
    {
        public Dictionary<string, int> BrandsWithRefs { get; set; }

        public MainPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            Driver.Navigate().GoToUrl("https://av.by/");
            BrandsWithRefs = new Dictionary<string, int>();
            Driver.FindElement(By.XPath(Locators.ShowAll)).Click();
            foreach (IWebElement element in Driver.FindElements(By.XPath(Locators.Brands)))
            {
                BrandsWithRefs[element.FindElement(By.TagName("span")).Text.ToLower()] = int.Parse(element.FindElement(By.TagName("small")).Text);
            }
        }

        public override CurrentAWPage NavigateTo(string DictionaryKey)
        {
            if (BrandsWithRefs.ContainsKey(DictionaryKey))
            {
                string newUrl = GetBrandUrl(DictionaryKey);
                Driver.Navigate().GoToUrl(newUrl);
                History.Push(this);
                return new BrandPage(Driver);
            }
            else
            {
                throw new NoSuchElementException(message: "No such brand in the list.");
            }
        }

        public string GetBrandUrl(string brandName)
        {
            return @"https://cars.av.by/" + brandName;
        }
    }
}
