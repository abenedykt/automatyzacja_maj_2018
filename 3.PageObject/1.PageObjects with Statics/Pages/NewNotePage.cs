using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using PageObjects_with_Statics.Domain;

namespace PageObjects_with_Statics.Pages
{
    internal class NewNotePage
    {
        private const string IdForSamplePermalink = "sample-permalink";
        private const string ClassNameForEditSlug = "edit-slug";
        private const string IdForPublish = "publish";
        private const string IdForContent = "content";
        private const string IdForContentHtml = "content-html";
        private const string IdForTitle = "title";

        public static string CreateNote(IWebDriver driver, Note note)
        {
            InsertTitle(driver, note);
            GoToContentTab(driver );
            InsertContent(driver, note);
            Publish(driver);
            return GetNewNoteUrl(driver);
        }

        private static string GetNewNoteUrl(IWebDriver driver)
        {
            var permalinkSelector = By.Id(IdForSamplePermalink);
            WaitForClickable(driver, permalinkSelector);
            var permalink = driver.FindElement(permalinkSelector);
            var a = permalink.FindElement(By.TagName("a"));
            var url = a.GetAttribute("href");
            return url;
        }

        private static void Publish(IWebDriver driver)
        {
            var editSlugSelector = By.ClassName(ClassNameForEditSlug);
            WaitForClickable(driver, editSlugSelector);

            var publishSelector = By.Id(IdForPublish);
            WaitForClickable(driver, publishSelector);
            var publish = driver.FindElement(publishSelector);
            publish.Click();
        }

        private static void InsertContent(IWebDriver driver, Note note)
        {
            var content = driver.FindElement(By.Id(IdForContent));
            content.SendKeys(note.Text);
        }

        private static void GoToContentTab(IWebDriver driver)
        {
            var textTab = driver.FindElement(By.Id(IdForContentHtml));
            textTab.Click();
        }

        private static void InsertTitle(IWebDriver driver, Note note)
        {
            var title = driver.FindElement(By.Id(IdForTitle));
            title.SendKeys(note.Title);
        }

        private static void WaitForClickable(IWebDriver driver, By by, int seconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
    }
}
