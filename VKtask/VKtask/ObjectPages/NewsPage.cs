using OpenQA.Selenium;
using VKtask.Selectors;

namespace VKtask.ObjectPages
{
    public class NewsPage : CurrentVKPage
    {
        IWebElement textNewInput;
        IWebElement postTextNew;

        public NewsPage(IWebDriver driver) : base(driver)
        {
            textNewInput = Driver.FindElement(By.XPath(Selector.NewsPage.TextForNewPostForm));
            postTextNew = Driver.FindElement(By.XPath(Selector.NewsPage.SendTextPost));
        }

        public void PostText(string text)
        {
            textNewInput.SendKeys(text);
            postTextNew.Click();
        }
    }
}