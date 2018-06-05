using OpenQA.Selenium;
using NUnit.Framework;
using VKtask.ObjectPages;
using OpenQA.Selenium.Chrome;

namespace VKtaskTests
{
    [TestFixture]
    public class VKTests
    {
        string login = "375336609897";
        string password = "OTBIr2ba6ZyUSdf0YwEKH0j5";
        IWebDriver driver;
        CurrentVKPage currentPage;

        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver(@"C:\Users\User\Desktop");
            currentPage = new LoginPage(driver);
        }

        [Test]
        public void LoggedIn()
        {
            currentPage = (currentPage as LoginPage).LogIn(login, password);
            Assert.AreEqual(currentPage.GetType(), typeof(NewsPage));
            currentPage.LogOut();
            driver.Close();
        }

        [TestCase("Anton Khlebko", "genres: psychological thriller, deja vu, psychedelic")]
        public void CorrectProfile(string fullName, string userStatus)
        {
            currentPage = (currentPage as LoginPage).LogIn(login, password);
            ProfilePage profilePage = (ProfilePage)currentPage.GoTo(LeftPanelButtons.PROFILE);
            Assert.AreEqual(fullName, profilePage.FullName);
            Assert.AreEqual(userStatus, profilePage.CurrentStatus);
            profilePage.LogOut();
            driver.Close();
        }

        [Test]
        public void SendMessage()
        {
            currentPage = (currentPage as LoginPage).LogIn(login, password);
            DialogsPage dialogsPage = (DialogsPage)currentPage.GoTo(LeftPanelButtons.MESSAGES);
            if (dialogsPage.FindDialog("Anton Khlebko"))
            {
                dialogsPage.SendMessage("HI!");
            }
            dialogsPage.LogOut();
            driver.Close();
        }

        [Test]
        public void TurnOnTheMusic()
        {
            currentPage = (currentPage as LoginPage).LogIn(login, password);
            AudiosPage audiosPage = (AudiosPage)currentPage.GoTo(LeftPanelButtons.AUDIOS);
            audiosPage.ShuffleAndPlay();
            audiosPage.LogOut();
            driver.Close();
        }

        [Test]
        public void LogInAndLogOut()
        {
            currentPage = (currentPage as LoginPage).LogIn(login, password);
            ProfilePage profilePage = (ProfilePage)currentPage.GoTo(LeftPanelButtons.PROFILE);
            profilePage.LogOut();
            driver.Close();
        }
    }
}
