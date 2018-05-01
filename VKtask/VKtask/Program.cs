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
            currentPage = (currentPage as LoginPage).LogIn("375336609897", "OTBIrw2ba6ZyUSdf0YwEKH0j5");
            if (currentPage.GetType() == typeof(NewsPage))
            {
                AudiosPage userAudios = (AudiosPage)currentPage.GoTo(LeftPanelButtons.AUDIOS);
                userAudios.ShuffleAndPlay();

                FriendsPage userFriends = (FriendsPage)currentPage.GoTo(LeftPanelButtons.FRIENDS);
                userFriends.PrintFiveFirstFriends();

                DialogsPage userDialogs = (DialogsPage)currentPage.GoTo(LeftPanelButtons.MESSAGES);
                userDialogs.GoToDialog("Ilya Obukhov");
                userDialogs.SendMessage("Annoying Ilya while testing automated bot");
            }
            else
            {
                currentPage.GoToURL("https://www.youtube.com");
            }
            Thread.Sleep(100000);
            driver.Close();
            driver.Quit();
            return;
        }
    }
}
