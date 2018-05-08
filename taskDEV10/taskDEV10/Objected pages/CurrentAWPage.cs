using OpenQA.Selenium;
using System.Collections.Generic;

namespace taskDEV10.Objected_pages
{
    public abstract class CurrentAWPage
    {
        public IWebDriver Driver { get; set; }
        public static Stack<CurrentAWPage> History = new Stack<CurrentAWPage>();
        public abstract CurrentAWPage NavigateTo(string DictionaryKey);

        public CurrentAWPage GoBack()
        {
            Driver.Navigate().Back();
            return History.Pop();
        }
    }
}
