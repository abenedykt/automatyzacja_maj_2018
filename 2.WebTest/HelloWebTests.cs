using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using Xunit;

namespace HelloWeb
{
    public class HelloWebTests : IDisposable
    {
        private const string BlogUrl = "https://autotestdotnet.wordpress.com/";
        private const string UrlToHelloNote = "https://autotestdotnet.wordpress.com/2018/05/07/witamy-na-warsztatach-automatyzacji-testow";
        private IWebDriver browser;

        public HelloWebTests()
        {
            browser = new ChromeDriver();

            browser.Manage().Window.Maximize();
            browser.Manage().Timeouts()
                .ImplicitWait = TimeSpan.FromMilliseconds(100);
        }

        [Fact]
        public void Can_open_blog_and_hello_note_exists()
        {
            browser.Navigate().GoToUrl(BlogUrl);

            var article = browser.FindElement(By.Id("post-3096"));
            var header = article.FindElement(By.TagName("h1"));

            Assert.Equal("Witamy na warsztatach automatyzacji testów!", header.Text);
        }


        [Fact]
        public void Can_open_blog_and_hello_note_exists_hard_way()
        {
            browser.Navigate().GoToUrl(BlogUrl);


            var cssSelector = "#post-3096 > header > h1";

            var title = browser.FindElement(By.CssSelector(cssSelector));

            Assert.Equal("Witamy na warsztatach automatyzacji testów!", title.Text);
        }


        [Fact]
        public void Can_add_comment_to_existing_note()
        {
            // arrange
            browser.Navigate().GoToUrl(UrlToHelloNote);
            var textGuid = Guid.NewGuid().ToString();
            var note = "lorem ipsum dolor sit amet, abc " + textGuid;
            var userName = "j.kowalski";
            var userEmail = GenerateEmail();

            // act
            var comment = browser.FindElement(By.Id("comment"));
            comment.SendKeys(note);

            var emailElement = browser.FindElement(By.Id("email"));
            emailElement.SendKeys(userEmail);

            var userElement = browser.FindElement(By.Id("author"));
            userElement.SendKeys(userName);

            var submit = browser.FindElement(By.Id("comment-submit"));
            submit.Click();

            // assert
            var comments = browser.FindElements(By.ClassName("comment-content"));

            var myComment = comments.SingleOrDefault(c => c.Text.Contains(textGuid));

            Assert.NotNull(myComment);
        }

        private string GenerateEmail()
        {
            var user = Guid.NewGuid().ToString();
            return $"{user}@nonexistent.test.com";
        }

        public void Dispose()
        {
            try
            {
                browser.Quit();
            }
            catch (Exception)
            {
            }
        }
    }
}
