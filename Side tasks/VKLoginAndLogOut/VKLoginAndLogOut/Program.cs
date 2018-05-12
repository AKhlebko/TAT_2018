using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace VKLoginAndLogOut
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\User\Desktop");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            driver.Navigate().GoToUrl(@"https://vk.com/");
            IWebElement loginForm = driver.FindElement(By.XPath(Selectors.LoginFormSelector));
            loginForm.FindElement(By.XPath(Selectors.LoginInputForm)).SendKeys("375336609897");
            loginForm.FindElement(By.XPath(Selectors.LoginPasswordForm)).SendKeys("OTBIr2ba6ZyUSdf0YwEKH0j5");
            loginForm.FindElement(By.XPath(Selectors.LoginPushButton)).Click();

            driver.FindElement(By.XPath(Selectors.LMessageButton)).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(@"//ul[@id='im_dialogs']")));
            Console.WriteLine("Waited");
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Selectors.UserInDialogFinder)));
            Console.WriteLine("Waited");
            driver.FindElement(By.XPath(@"//body")).SendKeys("Anton Khlebko");
            Thread.Sleep(10000);

            driver.Close();
            return;
        }
    }
}
