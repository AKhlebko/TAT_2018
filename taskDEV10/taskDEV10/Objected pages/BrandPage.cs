using OpenQA.Selenium;
using System.Linq;
using System.Collections.Generic;
using taskDEV10.AWSelectors;
using System.Text;

namespace taskDEV10.Objected_pages
{
    /// <summary>
    /// Page shown when brand is chosen
    /// </summary>
    public class BrandPage : CurrentAWPage
    {
        public Dictionary<string, int> ModelsWithRefs { get; set; }

        public BrandPage(IWebDriver driver)
        {
            Driver = driver;
            ModelsWithRefs = new Dictionary<string, int>();
            foreach (IWebElement element in Driver.FindElements(By.XPath(Selectors.MainPageSelectors.Brands)))
            {
                ModelsWithRefs[element.FindElement(By.TagName("span")).Text.ToLower()] = int.Parse(element.FindElement(By.TagName("small")).Text);
            }
            ModelsWithRefs = ModelsWithRefs.OrderBy(x => x.Value).Reverse().ToDictionary(x => x.Key, x => x.Value);
        }

        public override string ToString()
        {
            StringBuilder response = new StringBuilder();
            foreach (KeyValuePair<string, int> pair in ModelsWithRefs)
            {
                response.Append($"{pair.Key} - {pair.Value}\n");
            }
            return response.ToString();
        }

        public override CurrentAWPage NavigateTo(string DictionaryKey)
        {
            if (ModelsWithRefs.ContainsKey(DictionaryKey))
            {
                Driver.Navigate().GoToUrl(GetUrl(DictionaryKey));
                return new CurrentModelPage(Driver);
            }
            else
            {
                throw new NoSuchElementException(message: "No such brand in the list.");
            }
        }

        private string GetUrl(string DictionaryKey)
        {
            return Driver.Url + "/" + DictionaryKey.ToLower();
        }
    }
}