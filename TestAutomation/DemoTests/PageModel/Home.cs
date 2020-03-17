using Magenic.Maqs.BaseSeleniumTest;
using Magenic.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;
using System;

namespace PageModel
{
    /// <summary>
    /// Page object for the HomePageModel page
    /// </summary>
    public class Home : BasePage
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = SeleniumConfig.GetWebSiteBase().Trim('/');

        /// <summary>
        /// Initializes a new instance of the <see cref="Contact" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public Home(SeleniumTestObject testObject):base(testObject)
        {
        }

        public void OpenPage()
        {
            this.TestObject.WebDriver.Navigate().GoToUrl(PageUrl);
        }

        /// <summary>
        /// Gets how to section
        /// </summary>
        private LazyElement HowToSection
        {
            get { return this.GetLazyElement(By.CssSelector("#HowTo"), "How to section"); }
        }

        /// <summary>
        /// Check if the home page has been loaded
        /// </summary>
        /// <returns>True if the page was loaded</returns>
        public override bool IsPageLoaded()
        {
            return HowToSection.Exists && this.TestObject.WebDriver.Url.Trim('/').Equals(PageUrl.Trim('/'), StringComparison.CurrentCultureIgnoreCase);
        }
    }
}

