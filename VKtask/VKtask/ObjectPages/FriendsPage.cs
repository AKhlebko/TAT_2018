using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using VKtask.Selectors;

namespace VKtask.ObjectPages
{
    public class FriendsPage : CurrentVKPage
    {
        List<IWebElement> friends;

        public FriendsPage(IWebDriver driver) : base(driver)
        {
            friends = new List<IWebElement>(Driver.FindElements(By.XPath(Selector.FriendsPage.FriendsInfo)));
        }

        public void PrintFiveFirstFriends()
        {
            Console.WriteLine("User's first friends are:");
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine($"{i}) " + friends[i-1].FindElement(By.XPath("div/a")).Text.Trim());
            }
        }
    }
}