using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;

namespace PageObjects_with_Statics.Pages
{
    internal class AdminPage
    {
        private const string ClassNameForMenu = "wp-menu-name";
        private const string PostsButtonText = "Posts";
        private const string AddNewButtonText = "Add New";
        private const string IdForAccountBar = "wp-admin-bar-my-account";
        private const string ClassNameForSignOutButton = "ab-sign-out";


        public static void GoToNewNote(IWebDriver driver)
        {
            OpenPostsMenu(driver);
            ClickNewPost(driver);
        }

        public static void Logout(IWebDriver driver)
        {
            OpenAccountSideMenu(driver);
            ClickSignOut(driver);
        }

        private static void ClickNewPost(IWebDriver driver)
        {
            var addNew = driver.FindElement(By.LinkText(AddNewButtonText));
            addNew.Click();
        }

        private static void OpenPostsMenu(IWebDriver driver)
        {
            var menuSelector = By.ClassName(ClassNameForMenu);
            WaitForClickable(driver, menuSelector);
            var menu = driver.FindElements(menuSelector);
            var post = menu.Single(p => p.Text == PostsButtonText);
            post.Click();
        }

       

        private static void ClickSignOut(IWebDriver driver)
        {
            var signOutSelector = By.ClassName(ClassNameForSignOutButton);
            WaitForClickable(driver, signOutSelector);

            var signOut = driver.FindElement(signOutSelector);
            signOut.Click();
        }

        private static void OpenAccountSideMenu(IWebDriver driver)
        {
            var accountIcon = driver.FindElement(By.Id(IdForAccountBar));
            accountIcon.Click();
        }

        private static void WaitForClickable(IWebDriver driver, By by, int seconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
    }
}
