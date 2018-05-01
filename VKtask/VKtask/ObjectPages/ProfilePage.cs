using OpenQA.Selenium;
using VKtask.Selectors;

namespace VKtask.ObjectPages
{
    public class ProfilePage : CurrentVKPage
    {
        public string CurrentStatus { get; set; }
        public string FullName { get; set; }

        public ProfilePage(IWebDriver driver) : base(driver)
        {
            CurrentStatus = Driver.FindElement(By.XPath(Selector.ProfilePage.Status)).Text;
            FullName = Driver.FindElement(By.XPath(Selector.ProfilePage.FullName)).Text;
        }
    }
}
