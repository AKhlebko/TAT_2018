using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace VKtask.ObjectPages
{
    public class FailedToLoginPage : CurrentVKPage
    {
        public IWebElement userLoginInputForm { get; set; }
        public IWebElement userPasswordInputForm { get; set; }
        public IWebElement loginPushButtion { get; set; }

        public FailedToLoginPage(IWebDriver driver) : base(driver)
        {
            userLoginInputForm = Driver.FindElement(By.XPath(Selectors.LoginInputForm));
            userPasswordInputForm = Driver.FindElement(By.XPath(Selectors.LoginPasswordForm));
            loginPushButtion = Driver.FindElement(By.XPath(Selectors.LoginPushButtonFailedPage));
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
