using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Xunit;

namespace HelloWeb
{
    internal class Note
    {
        private IWebDriver _driver;
        private readonly string _url;

        public Note(IWebDriver driver, string url)
        {
            _driver = driver;
            _url = url;
            _driver.Navigate().GoToUrl(url);
        }

        internal void AddComment(ExampleComment comment)
        {
            var commentElement = _driver.FindElement(By.Id("comment"));
            commentElement.SendKeys(comment.Text);

            var emailElement = _driver.FindElement(By.Id("email"));
            emailElement.SendKeys(comment.Email);

            var userElement = _driver.FindElement(By.Id("author"));
            userElement.SendKeys(comment.Name);

            var submitElement = _driver.FindElement(By.Id("comment-submit"));

            submitElement.Click();
        }

        internal IEnumerable<IWebElement> SearchCommentsByText(ExampleComment comment)
        {
            var comments = _driver.FindElements(By.ClassName("comment-content"));

            return comments.Where(c => c.Text.Contains(comment.Text));
        }
    }
}