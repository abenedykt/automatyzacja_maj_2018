using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace HelloWeb
{
    public class HelloWebTests : IDisposable
    {
        private readonly string BlogUrl = "https://autotestdotnet.wordpress.com/";
        private IWebDriver browser;

        public HelloWebTests()
        {
            browser = new ChromeDriver();
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
