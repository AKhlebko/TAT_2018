﻿using OpenQA.Selenium;
using taskDEV10.AWSelectors;

namespace taskDEV10.Objected_pages
{
    /// <summary>
    /// Page shown when model selected
    /// </summary>
    public class CurrentModelPage : CurrentAWPage
    {
        private string ModelName;

        public CurrentModelPage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

        public override CurrentAWPage NavigateTo(string DictionaryKey)
        {
            return this;
        }

        public CurrentAWPage GoToNextPage()
        {
            string[] array = Selectors.CurrentModelPageSelectors.CurrentPageString.Split(' ');
            if (array[0] == array[1])
            {
                return this;
            }
            else
            {
                Driver.FindElement(By.XPath(Selectors.CurrentModelPageSelectors.NextPageButton)).Click();
                History.Push(this);
                return new CurrentModelPage(Driver);
            }
        }

        public CurrentAWPage GoToPreviousPage()
        {
            string[] array = Selectors.CurrentModelPageSelectors.CurrentPageString.Split(' ');
            if (int.Parse(array[0]) == 1)
            {
                return this;
            }
            else
            {
                Driver.FindElement(By.XPath(Selectors.CurrentModelPageSelectors.PreviousPageButton)).Click();
                History.Push(this);
                return new CurrentModelPage(Driver);
            }
        }
    }
}