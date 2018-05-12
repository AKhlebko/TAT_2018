using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebDriverIntoduction
{
    class Program
    {
        private static int ended;

        static void Main(string[] args)
        { 
            Task.Run(() =>
                GetFirstThreeNewsTitles(new ChromeDriver(@"C:\Users\User\Desktop"))
            );
            
            while (ended != 2)
            {

            }
        }

        static void GetFirstThreeNewsTitles(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://www.tut.by/");
            List<string> links = new List<string>();
            for (int i = 1; i < 4; i++)
            {
                IWebElement NewsLink = driver.FindElement(By.XPath($".//*[@data-ua-hash='main_news~{i}']"));
                NewsLink.Click();
                IWebElement header = driver.FindElement(By.XPath("//*/div/div/h1"));
                Console.WriteLine(header.Text);
                driver.Navigate().Back();
            }
            ended++;
            driver.Close();
        }
    }
}
