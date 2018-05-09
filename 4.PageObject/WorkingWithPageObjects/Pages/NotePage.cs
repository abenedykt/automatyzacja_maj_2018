using OpenQA.Selenium;
using WorkingWithPageObjects.Domain;

namespace WorkingWithPageObjects.Pages
{
    internal class NotePage
    {
        private IWebDriver _driver;

        public NotePage(IWebDriver driver, string noteUrl)
        {
            _driver = driver;
            _driver.Navigate().GoToUrl(noteUrl);
        }

        public bool Is(Note expected)
        {
            var title = _driver.FindElement(By.ClassName("entry-title"));
            var content = _driver.FindElement(By.ClassName("entry-content"));
            content = content.FindElement(By.TagName("p"));

            return title.Text == expected.Title && content.Text == expected.Text;
        }
    }
}
