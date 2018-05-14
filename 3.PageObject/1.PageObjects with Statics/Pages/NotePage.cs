using OpenQA.Selenium;
using PageObjects_with_Statics.Domain;

namespace PageObjects_with_Statics.Pages
{
    internal class NotePage
    {
        private const string ClassNameForTitle = "entry-title";
        private const string ClassNameForContent = "entry-content";

        public static bool Is(IWebDriver driver, Note expected)
        {
            string title = GetTitle(driver);
            string content = GetContent(driver);

            return title == expected.Title && content == expected.Text;
        }

        private static string GetContent(IWebDriver driver)
        {
            var content = driver.FindElement(By.ClassName(ClassNameForContent));
            content = content.FindElement(By.TagName("p"));
            return content.Text;
        }

        private static string GetTitle(IWebDriver driver)
        {
            return driver.FindElement(By.ClassName(ClassNameForTitle)).Text;
        }

        internal static void Open(IWebDriver driver, string noteUrl)
        {
            driver.Navigate().GoToUrl(noteUrl);
        }
    }
}
