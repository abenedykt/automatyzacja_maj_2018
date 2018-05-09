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
        private readonly ExampleComment testComment;

        public HelloWebWithPageObjectTests()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            testComment = new ExampleComment();
        }

        [Fact]
        public void Can_add_comment_to_existing_note()
        {
            //arrange
            var welcomeNote = new Note(driver, FirstNoteUrl);

            // act
            welcomeNote.AddComment(testComment);

            //assert
            var comments = welcomeNote.SearchCommentsByText(testComment);
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
