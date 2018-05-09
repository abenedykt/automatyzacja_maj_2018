using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;

namespace WorkingWithPageObjects.Pages
{
    internal class AdminPage
    {
        private const string ClassNameForMenu = "wp-menu-name";
        private const string PostsButtonText = "Posts";
        private const string AddNewButtonText = "Add New";
        private const string IdForAccountBar = "wp-admin-bar-my-account";
        private const string ClassNameForSignOutButton = "ab-sign-out";
        private IWebDriver _driver;

        public AdminPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public NewNotePage GoToNewNote()
        {
            OpenPostsMenu();
            ClickNewPost();

            return new NewNotePage(_driver);
        }

        private void ClickNewPost()
        {
            var addNew = _driver.FindElement(By.LinkText(AddNewButtonText));
            addNew.Click();
        }

        private void OpenPostsMenu()
        {
            var menuSelector = By.ClassName(ClassNameForMenu);
            WaitForClickable(menuSelector);
            var menu = _driver.FindElements(menuSelector);
            var post = menu.Single(p => p.Text == PostsButtonText);
            post.Click();
        }

        public void Logout()
        {
            OpenAccountSideMenu();
            ClickSignOut();
        }

        private void ClickSignOut()
        {
            var signOutSelector = By.ClassName(ClassNameForSignOutButton);
            WaitForClickable(signOutSelector);

            var signOut = _driver.FindElement(signOutSelector);
            signOut.Click();
        }

        private void OpenAccountSideMenu()
        {
            var accountIcon = _driver.FindElement(By.Id(IdForAccountBar));
            accountIcon.Click();
        }

        private void WaitForClickable(By by, int seconds = 10)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
    }
}
