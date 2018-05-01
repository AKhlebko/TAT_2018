using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using VKtask.Selectors;

namespace VKtask.ObjectPages
{
    public class DialogsPage : CurrentVKPage
    {
        private IWebElement dialogSearchForm { get; set; }

        public DialogsPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
            dialogSearchForm = Driver.FindElement(By.XPath(Selector.DialogsPage.DialogSearchForm));
        }

        public bool GoToDialog(string dialogName)
        {
            dialogSearchForm.SendKeys(dialogName);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            return wait.Until<bool>((driver) =>
            {
                IWebElement element = driver.FindElement(By.XPath(Selector.DialogsPage.ResultDialogs));
                IWebElement searchConfirmed = driver.FindElement(By.XPath(Selector.DialogsPage.SearchConfirmed));
                if (!element.Text.Contains("No matching messages found.") &&
                    driver.FindElement(By.XPath(Selector.DialogsPage.SearchConfirmed)).Displayed)
                {
                    dialogSearchForm.SendKeys(Keys.Enter);
                    return true;
                }
                return false;
            });
        }

        public void SendMessage(string message)
        {
            Driver.FindElement(By.TagName("body")).SendKeys(message);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.XPath(Selector.DialogsPage.SendMessageButton)));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Selector.DialogsPage.SendMessageButton)));
            IWebElement sendButton = Driver.FindElement(By.XPath(Selector.DialogsPage.SendMessageButton));
            sendButton.Click();
            sendButton.SendKeys(Keys.Control + Keys.Enter);
        }
    }
}