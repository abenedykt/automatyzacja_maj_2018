using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using Xunit;

namespace WorkingWithPageObjects
{
    public class GooglingWithFirefox : IDisposable
    {
        private IWebDriver _driver;

        public GooglingWithFirefox()
        {
            _driver = new FirefoxDriver();
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
}
