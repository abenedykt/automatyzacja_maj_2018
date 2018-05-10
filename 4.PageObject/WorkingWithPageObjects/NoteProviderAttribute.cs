using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

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



    internal class GoogleAttribute : DataAttribute
    {
        private readonly string query;

        public GoogleAttribute(string query)
        {
            this.query = query;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new[] { query };
        }
    }






    internal class GoogleFromFileAttribute : DataAttribute
    {
        private readonly string fileName;

        public GoogleFromFileAttribute(string fileName)
        {
            this.fileName = fileName;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var lines = File.ReadAllLines(fileName);
            
            foreach (var line in lines)
            {
                yield return new[] { line };
            }
        }
    }
}