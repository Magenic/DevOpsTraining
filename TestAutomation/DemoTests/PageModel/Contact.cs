using System;
using Magenic.Maqs.BaseSeleniumTest;
using Magenic.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for the Contact page
    /// </summary>
    public class Contact : BaseSeleniumPageModel
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = SeleniumConfig.GetWebSiteBase().Trim('/') + "/Home/Contact";

        /// <summary>
        /// Initializes a new instance of the <see cref="Contact" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public Contact(SeleniumTestObject testObject):base(testObject)
        {
        }

        /// <summary>
        /// Gets physical address
        /// </summary>
        public LazyElement PhysicalAddress
        {
            get { return new LazyElement(this.testObject, By.CssSelector("#PhysicalAddress"), "Physical Address"); }
        }

        /// <summary>
        /// Gets company name
        /// </summary>
        public LazyElement CompanyName
        {
            get { return new LazyElement(this.testObject, By.CssSelector("#companyName"), "Company Name"); }
        }

        /// <summary>
        /// Gets email contact
        /// </summary>
        public LazyElement EmailContact
        {
            get { return new LazyElement(this.testObject, By.CssSelector("#EmailContact"), "Email Contact"); }
        }

        /// <summary>
        /// Check if the home page has been loaded
        /// </summary>
        /// <returns>True if the page was loaded</returns>
        public override bool IsPageLoaded()
        {
            return this.testObject.WebDriver.Url.Trim('/').Equals(PageUrl.Trim('/'), StringComparison.CurrentCultureIgnoreCase);
        }
    }
}

