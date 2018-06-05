using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using taskDEV10.Objected_pages;

namespace taskDEV10
{
    class MainClass
    {
        static void Main(string[] args)
        {
            try
            {
                IWebDriver driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                MainPage mainPage = new MainPage(driver);
                string chosenBrand = args[0];
                BrandPage brandPage = (BrandPage)mainPage.NavigateTo(chosenBrand.ToLower());
                Console.Write(brandPage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
