using OpenQA.Selenium;

namespace VKtask.ObjectPages
{
    public class NewsPage : CurrentVKPage
    {
        IWebElement textNewInput;
        IWebElement postTextNew;

        public NewsPage(IWebDriver driver) : base(driver)
        {
            textNewInput = Driver.FindElement(By.XPath(Selectors.TextForNewPostForm));
            postTextNew = Driver.FindElement(By.XPath(Selectors.SendTextPost));
        }

        public void PostText(string text)
        {
            textNewInput.SendKeys(text);
            postTextNew.Click();
        }
    }
}