using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using Xunit;

namespace WorkingWithPageObjects
{
    public class FactoryExample
    {
        private IWebDriver _driver;

        public FactoryExample()
        {
            _driver = new ChromeDriver();
        }

        [Fact]
        public void Example()
        {
            _driver.Navigate().GoToUrl("https://autotestdotnet.wordpress.com/");

            var page = new FactoryExamplePage();

            PageFactory.InitElements(_driver, page);
            var countOfNotes = page.Titles.Count;
            _driver.Navigate().Refresh();

            var countOfNotes2 = page.Titles.Count;


        }
    }

    internal class FactoryExamplePage
    {
        public FactoryExamplePage()
        {
        }

        [FindsBy(How = How.CssSelector, Using = "entry-title")]
        public IList<IWebElement> Titles { get; set; }
    }
}
