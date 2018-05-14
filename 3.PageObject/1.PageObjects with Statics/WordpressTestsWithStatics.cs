using Xunit;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects_with_Statics.Pages;
using PageObjects_with_Statics.Domain;

namespace PageObjects_with_Statics
{
    public class WordpressTestsWithStatics : IDisposable
    {
        private IWebDriver _driver;

        private readonly User admin = new User(Settings.AdminName, Settings.AdminPassword);
        private readonly Note exampleNote = new Note("hello world", "this is an example note created with selenium");

        public WordpressTestsWithStatics()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Fact]
        public void Can_create_new_note()
        {
            LoginPage.Open(_driver);
            LoginPage.Login(_driver, admin);
            AdminPage.GoToNewNote(_driver);

            var noteUrl = NewNotePage.CreateNote(_driver, exampleNote);
            AdminPage.Logout(_driver);

            NotePage.Open(_driver, noteUrl);
            Assert.True(NotePage.Is(_driver, exampleNote));
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
