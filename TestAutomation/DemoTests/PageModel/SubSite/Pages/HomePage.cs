using Magenic.Maqs.BaseSeleniumTest;
using Magenic.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel.SubSite.Pages
{
    /// <summary>
    /// Page object for the login page
    /// </summary>
    public class HomePage : BaseSubSitePage
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static string PageUrl = SeleniumConfig.GetWebSiteBase().Trim('/') + "/static/BasicSite/HomePage.html";

        /// <summary>
        /// Sample element 'By' finder
        /// </summary>
        public LazyElement WelcomeMessage
        {
            get { return this.GetLazyElement(By.CssSelector("#WelcomeMessage"), "WelcomeMessage"); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Model1" /> class.
        /// </summary>
        /// <param name="webDriver">The selenium web driver</param>
        public HomePage(SeleniumTestObject testObject)
            : base(testObject)
        {
        }

        public override bool IsPageLoaded()
        {
            return this.TestObject.WebDriver.Wait().UntilElementExist(WelcomeMessage.By);
        }
    }
}
