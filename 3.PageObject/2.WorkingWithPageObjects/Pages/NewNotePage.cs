using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using WorkingWithPageObjects.Domain;

namespace WorkingWithPageObjects.Pages
{
    internal class NewNotePage
    {
        private const string IdForSamplePermalink = "sample-permalink";
        private const string ClassNameForEditSlug = "edit-slug";
        private const string IdForPublish = "publish";
        private const string IdForContent = "content";
        private const string IdForContentHtml = "content-html";
        private const string IdForTitle = "title";

        private IWebDriver _driver;

        public NewNotePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string CreateNote(Note note)
        {
            InsertTitle(note);
            GoToContentTab();
            InsertContent(note);
            Publish();
            return GetNewNoteUrl();
        }

        private string GetNewNoteUrl()
        {
            var permalinkSelector = By.Id(IdForSamplePermalink);
            WaitForClickable(permalinkSelector);
            var permalink = _driver.FindElement(permalinkSelector);
            var a = permalink.FindElement(By.TagName("a"));
            var url = a.GetAttribute("href");
            return url;
        }

        private void Publish()
        {
            var editSlugSelector = By.ClassName(ClassNameForEditSlug);
            WaitForClickable(editSlugSelector);

            var publishSelector = By.Id(IdForPublish);
            WaitForClickable(publishSelector);
            var publish = _driver.FindElement(publishSelector);
            publish.Click();
        }

        private void InsertContent(Note note)
        {
            var content = _driver.FindElement(By.Id(IdForContent));
            content.SendKeys(note.Text);
        }

        private void GoToContentTab()
        {
            var textTab = _driver.FindElement(By.Id(IdForContentHtml));
            textTab.Click();
        }

        private void InsertTitle(Note note)
        {
            var title = _driver.FindElement(By.Id(IdForTitle));
            title.SendKeys(note.Title);
        }

        private void WaitForClickable(By by, int seconds = 10)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
    }
}
