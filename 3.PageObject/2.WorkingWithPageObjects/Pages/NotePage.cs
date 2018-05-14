using OpenQA.Selenium;
using WorkingWithPageObjects.Domain;

namespace WorkingWithPageObjects.Pages
{
    internal class NotePage
    {
        private const string ClassNameForTitle = "entry-title";
        private const string ClassNameForContent = "entry-content";

        private IWebDriver _driver;

        public NotePage(IWebDriver driver, string noteUrl)
        {
            _driver = driver;
            _driver.Navigate().GoToUrl(noteUrl);
        }

        public bool Is(Note expected)
        {
            string title = GetTitle();
            string content = GetContent();

            return title == expected.Title && content == expected.Text;
        }

        private string GetContent()
        {
            var content = _driver.FindElement(By.ClassName(ClassNameForContent));
            content = content.FindElement(By.TagName("p"));
            return content.Text;
        }

        private string GetTitle()
        {
            return _driver.FindElement(By.ClassName(ClassNameForTitle)).Text;
        }
    }
}
