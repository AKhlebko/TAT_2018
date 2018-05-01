using OpenQA.Selenium;
using System;
using VKtask.Selectors;

namespace VKtask.ObjectPages
{
    public class LoginPage : CurrentVKPage
    {
        public string HomePageUrl { get; set; } = @"https://vk.com/";

        public IWebElement userLoginInputForm { get; set; }
        public IWebElement userPasswordInputForm { get; set; }
        public IWebElement loginPushButtion { get; set; }

        public LoginPage(IWebDriver driver) : base(driver)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            Driver.Navigate().GoToUrl(HomePageUrl);
            userLoginInputForm = Driver.FindElement(By.XPath(Selector.LoginPage.LoginInputForm));
            userPasswordInputForm = Driver.FindElement(By.XPath(Selector.LoginPage.LoginPasswordForm));
            loginPushButtion = Driver.FindElement(By.XPath(Selector.LoginPage.LoginPushButton));
        }

        public CurrentVKPage LogIn(string userLogin, string userPassword)
        {
            userLoginInputForm.SendKeys(userLogin);
            userPasswordInputForm.SendKeys(userPassword);
            loginPushButtion.Click();
            if (Driver.PageSource.Contains("Please check that you have entered your"))
            {
                return new FailedToLoginPage(Driver);
            }
            else
            {
                return new NewsPage(Driver);
            }
        }
    }
}
