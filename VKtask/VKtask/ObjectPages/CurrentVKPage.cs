using OpenQA.Selenium;
using VKtask.Selectors;

namespace VKtask.ObjectPages
{
    /// <summary>
    /// Buttons in the left part of each page
    /// </summary>
    public enum LeftPanelButtons
    {
        PROFILE,
        MESSAGES,
        FRIENDS,
        AUDIOS,
        NEWS
    }

    /// <summary>
    /// Base VKpage class and it's basic methods
    /// </summary>
    public abstract class CurrentVKPage
    {
        public IWebDriver Driver { get; set; }

        public CurrentVKPage(IWebDriver driver)
        {
            Driver = driver;
            Driver.Manage().Window.Maximize();
        }

        public void GoToURL(string URL)
        {
            Driver.Navigate().GoToUrl(URL);
        }

        /// <summary>
        /// Switching between pages through left side panel
        /// </summary>
        /// <param name="button">
        /// button to press
        /// </param>
        /// <returns>
        /// Page's object of needed type
        /// </returns>
        public CurrentVKPage GoTo(LeftPanelButtons button)
        {
            if (GetType() == typeof(LoginPage)) return this;
            CurrentVKPage pageToReturn = this;
            switch (button)
            {
                case LeftPanelButtons.FRIENDS:
                    Driver.FindElement(By.XPath(Selector.LeftMenuButtons.LFriendsButton)).Click();
                    pageToReturn = new FriendsPage(Driver);
                    break;
                case LeftPanelButtons.MESSAGES:
                    Driver.FindElement(By.XPath(Selector.LeftMenuButtons.LMessageButton)).Click();
                    pageToReturn = new DialogsPage(Driver);
                    break;
                case LeftPanelButtons.AUDIOS:
                    Driver.FindElement(By.XPath(Selector.LeftMenuButtons.LAudiosButton)).Click();
                    pageToReturn = new AudiosPage(Driver);
                    break;
                case LeftPanelButtons.PROFILE:
                    Driver.FindElement(By.XPath(Selector.LeftMenuButtons.LProfile)).Click();
                    pageToReturn = new ProfilePage(Driver);
                    break;
            }
            return pageToReturn;
        }

        /// <summary>
        /// Logs out of the account
        /// </summary>
        public void LogOut()
        {
            if (this.GetType() == typeof(LoginPage) || this.GetType() == typeof(FailedToLoginPage)) return;
            Driver.FindElement(By.XPath(Selector.LogOutMenuSelectors.OpenMenu)).Click();
            Driver.FindElement(By.XPath(Selector.LogOutMenuSelectors.LogOutButton)).Click();
        }
    }
}
