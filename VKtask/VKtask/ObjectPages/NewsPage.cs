using OpenQA.Selenium;
using VKtask.Selectors;

namespace VKtask.ObjectPages
{
    /// <summary>
    /// Page with user's feed
    /// </summary>
    public class NewsPage : CurrentVKPage
    {
        IWebElement textNewInput;
        IWebElement postTextNew;

        public NewsPage(IWebDriver driver) : base(driver)
        {
            textNewInput = Driver.FindElement(By.XPath(Selector.NewsPage.TextForNewPostForm));
            postTextNew = Driver.FindElement(By.XPath(Selector.NewsPage.SendTextPost));
        }

        /// <summary>
        /// Makes text post through form on the page
        /// </summary>
        /// <param name="text">
        /// Text to post
        /// </param>
        public void PostText(string text)
        {
            textNewInput.SendKeys(text);
            postTextNew.Click();
        }
    }
}