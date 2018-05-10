using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace WorkingWithPageObjects
{
    public class GooglePageFactoryExample : IDisposable
    {
        private IWebDriver _driver;

        public GooglePageFactoryExample()
        {
            _driver = new FirefoxDriver();
            //_driver = new ChromeDriver();
        }

        [Theory,
            InlineData("code sprinters", "Code Sprinters - Agile Experts"),
            InlineData("microsoft", "Microsoft — oficjalna strona główna"),
            InlineData("krowa", "Krowa z Janowa")
            ]
        public void Can_search_term_in_google(string query, string expected)
        {
            //arrange
            var googleMainPage = new GoogleMainPage(_driver);

            //act
            var resultPage = googleMainPage.Search(query);

            //assert
            Assert.True(resultPage.Contains(expected));
        }

        public void Dispose()
        {
            try
            {
                _driver.Quit();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    internal class GoogleMainPage : BasePage
    {
        private const string GoogleMainPageUrl = "https://www.google.com/";

        public GoogleMainPage(IWebDriver driver) : base(driver)
        {
            _driver.Navigate().GoToUrl(GoogleMainPageUrl);
        }

        [FindsBy(How = How.Id, Using = "lst-ib")]
        public IWebElement QueryBox;

        public ResultPage Search(string query)
        {
            QueryBox.SendKeys(query);
            QueryBox.Submit();

            return new ResultPage(_driver);
        }
    }

    public abstract class BasePage
    {
        protected readonly IWebDriver _driver;

        public BasePage( IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        protected void WaitForClickable(By by, int seconds = 10)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
    }

    public class ResultPage : BasePage
    {
        public ResultPage(IWebDriver driver) :base(driver)
        {
            WaitForClickable(By.CssSelector("h3.r"));
        }

        [FindsBy(How=How.CssSelector, Using ="h3.r")]
        public IList<IWebElement> SearchResults;


        public bool Contains(string expected)
        {
            return SearchResults.Any(s => s.Text.Contains(expected));
        }

        
    }
}
