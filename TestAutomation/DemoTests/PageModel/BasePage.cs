using Magenic.Maqs.BaseSeleniumTest;
using Magenic.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for Base
    /// </summary>
    public abstract class BasePage : BaseSeleniumPageModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasePage" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        protected BasePage(SeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// Gets root site navigation
        /// </summary>
        private LazyElement SiteRootNavigation
        {
            get { return new LazyElement(this.testObject, By.CssSelector("#RootNav"), "RootNav"); }
        }

        /// <summary>
        /// Gets home navigation
        /// </summary>
        private LazyElement HomeNavigation
        {
            get { return new LazyElement(this.testObject, By.CssSelector("#Home"), "Home"); }
        }

        /// <summary>
        /// Gets about navigation
        /// </summary>
        private LazyElement AboutNavigation
        {
            get { return new LazyElement(this.testObject, By.CssSelector("#About"), "About"); }
        }

        /// <summary>
        /// Gets contact navigation
        /// </summary>
        private LazyElement ContactNavigation
        {
            get { return new LazyElement(this.testObject, By.CssSelector("#Contact"), "Contact"); }
        }

        public Home OpenSiteRootTab()
        {
            SiteRootNavigation.Click();
            return new Home(this.testObject);
        }

        public Home OpenHomeTab()
        {
            HomeNavigation.Click();
            return new Home(this.testObject);
        }

        public About OpenAboutTab()
        {
            AboutNavigation.Click();
            return new About(this.testObject);
        }

        public Contact OpenContactTab()
        {
            ContactNavigation.Click();
            return new Contact(this.testObject);
        }
    }
}
