using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using VKtask.ObjectPages;

namespace VKtask
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\User\Desktop");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            CurrentVKPage currentPage = new LoginPage(driver);
            currentPage = (currentPage as LoginPage).LogIn("375336609897", "OTBIr2ba6ZyUSdf0YwEKH0j5");
            if (currentPage.GetType() == typeof(NewsPage))
            {
                currentPage = (currentPage as NewsPage).goToMessages();
                (currentPage as DialogsPage).GoToDialog("Anton Khlebko");
                (currentPage as DialogsPage).SendMessage("Hi, how's it going?");
            }
            Thread.Sleep(10000);
            driver.Close();
            driver.Quit();
            return;
        }
    }
}
