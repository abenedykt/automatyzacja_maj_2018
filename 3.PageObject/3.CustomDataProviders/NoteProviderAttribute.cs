using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace WorkingWithPageObjects
{
    public class TestWithDataProvider : IDisposable
    {
        private IWebDriver _driver;

        public TestWithDataProvider()
        {
            _driver = new ChromeDriver();
        }

        public void Dispose()
        {
            _driver.Quit();
        }

        [Theory,
        Google("code sprinters"),
        Google("agile szkolenia"),
        Google("kausza"),
        Google("fortepian"),
        Google("pytania z matury"),
        Google("kabza")
        ]
        public void I_can_google(string term)
        {
            _driver.Navigate().GoToUrl("https://www.google.com/");
            var queryBox = _driver.FindElement(By.Id("lst-ib"));
            queryBox.SendKeys(term + Keys.Return);
        }

        [Theory,
        GoogleFromFile("instruments.txt"),
        GoogleFromFile("animals.txt")
        ]
        public void I_can_google_from_file(string term)
        {
            _driver.Navigate().GoToUrl("https://www.google.com/");
            var queryBox = _driver.FindElement(By.Id("lst-ib"));
            queryBox.SendKeys(term + Keys.Return);
        }
    }
}