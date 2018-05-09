using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using WorkingWithPageObjects.Domain;

namespace WorkingWithPageObjects.Pages
{
    internal class NewNotePage
    {
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
            var permalinkSelector = By.Id("sample-permalink");
            WaitForClickable(permalinkSelector, 10);
            var permalink = _driver.FindElement(permalinkSelector);
            var a = permalink.FindElement(By.TagName("a"));
            var url = a.GetAttribute("href");
            return url;
        }

        private void Publish()
        {
            var editSlugSelector = By.ClassName("edit-slug");
            WaitForClickable(editSlugSelector, 10);

            var publishSelector = By.Id("publish");
            WaitForClickable(publishSelector, 10);
            var publish = _driver.FindElement(publishSelector);
            publish.Click();
        }

        private void InsertContent(Note note)
        {
            var content = _driver.FindElement(By.Id("content"));
            content.SendKeys(note.Text);
        }

        private void GoToContentTab()
        {
            var textTab = _driver.FindElement(By.Id("content-html"));
            textTab.Click();
        }

        private void InsertTitle(Note note)
        {
            var title = _driver.FindElement(By.Id("title"));
            title.SendKeys(note.Title);
        }

        private void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
    }
}
