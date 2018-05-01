using OpenQA.Selenium;
using VKtask.Selectors;

namespace VKtask.ObjectPages
{
    public class FailedToLoginPage : CurrentVKPage
    {
        public IWebElement userLoginInputForm { get; set; }
        public IWebElement userPasswordInputForm { get; set; }
        public IWebElement loginPushButtion { get; set; }

        public FailedToLoginPage(IWebDriver driver) : base(driver)
        {
            userLoginInputForm = Driver.FindElement(By.XPath(Selector.LoginFailedPage.LoginInputForm));
            userPasswordInputForm = Driver.FindElement(By.XPath(Selector.LoginFailedPage.LoginPasswordForm));
            loginPushButtion = Driver.FindElement(By.XPath(Selector.LoginFailedPage.LoginPushButtonFailedPage));
        }

        public CurrentVKPage LogIn(string userLogin, string userPassword)
        {
            userLoginInputForm.SendKeys(userLogin);
            userPasswordInputForm.SendKeys(userPassword);
            loginPushButtion.Click();
            if (Driver.PageSource.Contains("Please check that you have entered your login and password correctly."))
            {
                return this;
            }
            else
            {
                return new NewsPage(Driver);
            }
        }
    }
}
