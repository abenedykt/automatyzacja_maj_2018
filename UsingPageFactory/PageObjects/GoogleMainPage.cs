using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WorkingWithPageObjects
{
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
}
