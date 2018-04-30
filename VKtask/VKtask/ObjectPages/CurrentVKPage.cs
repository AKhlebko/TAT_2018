using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKtask.ObjectPages
{
    public enum LeftPanelButtons
    {
        MESSAGES,
        FRIENDS,
        COMMUNITIES,
        AUDIOS,
        NEWS
    }

    public abstract class CurrentVKPage
    {
        public IWebDriver Driver { get; set; }

        public CurrentVKPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void GoToURL(string URL)
        {
            Driver.Navigate().GoToUrl(URL);
        }

        public CurrentVKPage GoTo(LeftPanelButtons button)
        {
            if (GetType() == typeof(LoginPage)) return this;
            CurrentVKPage pageToReturn = this;
            switch (button)
            {
                case LeftPanelButtons.FRIENDS:
                    Driver.FindElement(By.XPath(Selectors.LFriendsButton)).Click();
                    pageToReturn = new FriendsPage(Driver);
                    break;
                case LeftPanelButtons.COMMUNITIES:
                    Driver.FindElement(By.XPath(Selectors.LCommunitiesButton)).Click();
                    pageToReturn = new CommunitiesPage(Driver);
                    break;
                case LeftPanelButtons.MESSAGES:
                    Driver.FindElement(By.XPath(Selectors.LMessageButton)).Click();
                    pageToReturn = new DialogsPage(Driver);
                    break;
                case LeftPanelButtons.AUDIOS:
                    Driver.FindElement(By.XPath(Selectors.LAudiosButton)).Click();
                    pageToReturn = new AudiosPage(Driver);
                    break;
            }
            return pageToReturn;
        }
    }
}
