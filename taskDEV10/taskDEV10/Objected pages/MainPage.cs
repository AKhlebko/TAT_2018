using OpenQA.Selenium;
using System.Collections.Generic;
using taskDEV10.AWSelectors;

namespace taskDEV10.Objected_pages
{
    class MainPage : CurrentAWPage
    {
        public Dictionary<string, int> BrandsWithRefs { get; set; }

        public MainPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            Driver.Navigate().GoToUrl("https://av.by/");
            BrandsWithRefs = new Dictionary<string, int>();
            Driver.FindElement(By.XPath(Selectors.MainPageSelectors.ShowAll)).Click();
            foreach (IWebElement element in Driver.FindElements(By.XPath(Selectors.MainPageSelectors.Brands)))
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
