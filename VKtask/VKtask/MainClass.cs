using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using VKtask.ObjectPages;

namespace VKtask
{
    /// <summary>
    /// Simulating my default action list on the VK.com
    /// </summary>
    class MainClass
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\User\Desktop");
            CurrentVKPage currentPage = new LoginPage(driver);
            currentPage = (currentPage as LoginPage).LogIn("375336609897", "OTBIr2ba6ZyUSdf0YwEKH0j5");
            if (currentPage.GetType() == typeof(NewsPage))
            {
                AudiosPage audios = (AudiosPage)currentPage.GoTo(LeftPanelButtons.AUDIOS);
                audios.ShuffleAndPlay();

                ProfilePage profile = (ProfilePage)audios.GoTo(LeftPanelButtons.PROFILE);
                Console.WriteLine(profile.FullName);
                Console.WriteLine(profile.CurrentStatus);
                
                FriendsPage friends = (FriendsPage)profile.GoTo(LeftPanelButtons.FRIENDS);
                friends.PrintFiveFirstFriends();

                DialogsPage userDialogs = (DialogsPage)friends.GoTo(LeftPanelButtons.MESSAGES);
                userDialogs.FindDialog("Anton Khlebko");
                userDialogs.SendMessage("Hi! How's it going?");

                userDialogs.LogOut();
            }
            else
            {
                currentPage.GoToURL("https://www.youtube.com");
            }
            driver.Close();
            driver.Quit();
            return;
        }
    }
}