using AutoFixture.Xunit2;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace HelloWeb
{
    public class HelloWebWithPageObjectTests : IDisposable
    {
        private const string FirstNoteUrl = "https://autotestdotnet.wordpress.com/2018/05/07/witamy-na-warsztatach-automatyzacji-testow";
        private IWebDriver driver;

        public HelloWebWithPageObjectTests()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Theory, AutoData]
        public void Can_add_comment_to_existing_note(ExampleComment comment)
        {
            //arrange
            var welcomeNote = new Note(driver, FirstNoteUrl);

            // act
            welcomeNote.AddComment(comment);

            //assert
            var comments = welcomeNote.SearchCommentsByText(comment);
            Assert.Single(comments);
        }

        public void Dispose()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
