using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using PageObjects_with_Statics.Domain;

namespace PageObjects_with_Statics.Pages
{
    internal class LoginPage
    {
        private const string IdForUserName = "usernameOrEmail";
        private const string IdForPassword = "password";
        private const string ClassNameForContinueButton = "form-button";

        public static void Login(IWebDriver driver, User user)
        {
            InsertUserName(driver, user);
            ClickContinue(driver);
            InserPassword(driver, user);
            ClickContinue(driver );
        }

        internal static void Open(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(Settings.AdminPage);
        }

        private static void InserPassword(IWebDriver driver, User user)
        {
            var passwordSelector = By.Id(IdForPassword);
            WaitForClickable(driver, passwordSelector);
            var password = driver.FindElement(passwordSelector);
            password.SendKeys(user.Password);
        }

        private static void ClickContinue(IWebDriver driver)
        {
            var continueButton = driver.FindElement(By.ClassName(ClassNameForContinueButton));
            continueButton.Click();
        }

        private static void InsertUserName(IWebDriver driver, User user)
        {
            var userName = driver.FindElement(By.Id(IdForUserName));
            userName.SendKeys(user.UserName);
        }

        private static void WaitForClickable(IWebDriver driver, By by, int seconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }


    }
}
