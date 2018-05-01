using OpenQA.Selenium;
using VKtask.Selectors;

namespace VKtask.ObjectPages
{
    public class AudiosPage : CurrentVKPage
    {
        private IWebElement shuffleAll;

        public AudiosPage(IWebDriver driver) : base(driver)
        {
            shuffleAll = Driver.FindElement(By.XPath(Selector.AudiosPage.ShuffleAndPlayMusicButton));
        }

        public void ShuffleAndPlay()
        {
            shuffleAll.Click();
        }
    }
}