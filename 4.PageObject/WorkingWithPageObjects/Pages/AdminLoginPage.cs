using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WorkingWithPageObjects.Domain;

namespace WorkingWithPageObjects.Pages
{
    internal class LoginPage
    {
        private const string IdForUserName = "usernameOrEmail";
        private const string IdForPassword = "password";
        private const string ClassNameForContinueButton = "form-button";

        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Navigate().GoToUrl(Settings.AdminPage);
        }

        public AdminPage Login(User user)
        {
            InsertUserName(user);
            ClickContinue();
            InserPassword(user);
            ClickContinue();

            return new AdminPage(_driver);
        }

        private void InserPassword(User user)
        {
            var passwordSelector = By.Id(IdForPassword);
            WaitForClickable(passwordSelector);
            var password = _driver.FindElement(passwordSelector);
            password.SendKeys(user.Password);
        }

        private void ClickContinue()
        {
            var continueButton = _driver.FindElement(By.ClassName(ClassNameForContinueButton));
            continueButton.Click();
        }

        private void InsertUserName(User user)
        {
            var userName = _driver.FindElement(By.Id(IdForUserName));
            userName.SendKeys(user.UserName);
        }

        private void WaitForClickable(By by, int seconds = 10)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }


    }
}
