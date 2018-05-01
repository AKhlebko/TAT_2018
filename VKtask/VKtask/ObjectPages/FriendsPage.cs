using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace VKtask.ObjectPages
{
    public class FriendsPage : CurrentVKPage
    {
        List<IWebElement> friends;

        public FriendsPage(IWebDriver driver) : base(driver)
        {
            friends = new List<IWebElement>(Driver.FindElements(By.XPath("//div[@class='friends_user_row clear_fix']")));
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine(friends[i].FindElement(By.XPath("//a[contains(@href,.)]")).Text);
            }
        }

        public void PrintFiveFirstFriends()
        {
            Console.WriteLine("User's first friends are:");
            friends = new List<IWebElement>(Driver.FindElements(By.XPath("//div[@class='friends_user_info']")));
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine($"{i}) " + friends[i-1].FindElement(By.XPath("div/a")).Text.Trim());
            }

        }
    }
}