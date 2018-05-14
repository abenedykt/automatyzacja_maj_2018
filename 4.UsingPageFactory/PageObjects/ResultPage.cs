using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithPageObjects
{
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
