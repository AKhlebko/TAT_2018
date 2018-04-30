using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

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
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(HomePageUrl);
            userLoginInputForm = Driver.FindElement(By.XPath(Selectors.LoginInputForm));
            userPasswordInputForm = Driver.FindElement(By.XPath(Selectors.LoginPasswordForm));
            loginPushButtion = Driver.FindElement(By.XPath(Selectors.LoginPushButton));
        }

        public CurrentVKPage LogIn(string userLogin, string userPassword)
        {
            userLoginInputForm.SendKeys(userLogin);
            userPasswordInputForm.SendKeys(userPassword);
            loginPushButtion.Click();
            if (Driver.PageSource.Contains("Please check that you have entered your login and password correctly."))
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
