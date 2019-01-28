using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Magenic.Maqs.BaseSeleniumTest;
using Magenic.Maqs.Utilities;
using Magenic.Maqs.Utilities.Helper;
using System;
using Magenic.Maqs.BaseSeleniumTest.Extensions;

namespace PageModel.SubSite.Pages
{
    /// <summary>
    /// Page object for the login page
    /// </summary>
    public class AsyncPage : BaseSubSitePage
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static string PageUrl = SeleniumConfig.GetWebSiteBase().Trim('/') + "/static/BasicSite/Async.html";

        public LazyElement AsyncContent
        {
            get { return new LazyElement(this.testObject, By.CssSelector("#AsyncContent"), "AsyncContent"); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Model1" /> class.
        /// </summary>
        /// <param name="webDriver">The selenium web driver</param>
        public AsyncPage(SeleniumTestObject testObject)
            : base(testObject)
        {
        }

        /// <summary>
        /// Verify we are on the login page
        /// </summary>
        public override bool IsPageLoaded()
        {
            return this.testObject.WebDriver.Wait().UntilElementExist(AsyncContent.By);
        }
    }
}
