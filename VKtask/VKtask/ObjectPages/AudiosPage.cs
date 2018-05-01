using OpenQA.Selenium;

namespace VKtask.ObjectPages
{
    public class AudiosPage : CurrentVKPage
    {
        private IWebElement shuffleAll;

        public AudiosPage(IWebDriver driver) : base(driver)
        {
            shuffleAll = Driver.FindElement(By.XPath(Selectors.ShuffleAndPlayMusicButton));
        }

        public void ShuffleAndPlay()
        {
            shuffleAll.Click();
        }
    }
}