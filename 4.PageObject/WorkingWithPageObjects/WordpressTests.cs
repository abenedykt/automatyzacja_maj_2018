using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WorkingWithPageObjects.Domain;
using WorkingWithPageObjects.Pages;
using Xunit;

namespace WorkingWithPageObjects
{
    public class WordpressTests : IDisposable
    {
        private readonly User admin = new User(Settings.AdminName, Settings.AdminPassword);
        private readonly Note exampleNote = new Note("hello world", "this is an example note created with selenium");
        private readonly IWebDriver _driver;
        
        public WordpressTests()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Fact]
        public void Can_create_new_note()
        {
            var logingPage = new LoginPage(_driver);
            var adminPage = logingPage.Login(admin);
            var notePage = adminPage.GoToNewNote();

            var noteUrl = notePage.CreateNote(exampleNote);
            adminPage.Logout();

            var note = new NotePage(_driver, noteUrl);
            Assert.True(note.Is(exampleNote));
        }

        public void Dispose()
        {
            try
            {
                _driver.Quit();
            }
            catch (Exception)
            {

            }
        }
    }
}
