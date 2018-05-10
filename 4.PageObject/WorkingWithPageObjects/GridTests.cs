using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Html5;
using OpenQA.Selenium.Remote;
using System;
using Xunit;

namespace WorkingWithPageObjects
{
    public class GridTests : IDisposable
    {
        private IWebDriver _driver;

        public GridTests()
        {
            //var cap = new DesiredCapabilities();
            //cap.SetCapability(CapabilityType.BrowserName, "firefox");
            //cap.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));

            //_driver = new RemoteWebDriver(new Uri("http://172.16.240.247:6543/wd/hub"), cap);

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
        Google("kabza")]
        public void I_can_google(string term)
        {
            _driver.Navigate().GoToUrl("https://www.google.com/");


            // example of reading web storage
            var webstorage = _driver as IHasWebStorage;
            if (webstorage != null)
            {
                webstorage.WebStorage.LocalStorage.GetItem("abc");
            }

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