using Magenic.Maqs.BaseSeleniumTest;
using Magenic.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel.SubSite.Pages
{
    /// <summary>
    /// Page object for the login page
    /// </summary>
    public class HowWorkPage : BaseSubSitePage
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static string PageUrl = SeleniumConfig.GetWebSiteBase().Trim('/') + "/static/BasicSite/HowWork.html";

        /// <summary>
        /// Sample element 'By' finder
        /// </summary>
        public LazyElement HowWorks
        {
            get { return this.GetLazyElement(By.CssSelector("#HowWorks"), "HowWorks"); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Model1" /> class.
        /// </summary>
        /// <param name="webDriver">The selenium web driver</param>
        public HowWorkPage(SeleniumTestObject testObject)
            : base(testObject)
        {
        }

        /// <summary>
        /// Verify we are on the  page
        /// </summary>
        public override bool IsPageLoaded()
        {
            return this.TestObject.WebDriver.Wait().UntilElementExist(HowWorks.By);
        }
    }
}
