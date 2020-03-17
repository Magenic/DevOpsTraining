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
            get { return this.GetLazyElement(By.CssSelector("#RootNav"), "RootNav"); }
        }

        /// <summary>
        /// Gets home navigation
        /// </summary>
        private LazyElement HomeNavigation
        {
            get { return this.GetLazyElement(By.CssSelector("#Home"), "Home"); }
        }

        /// <summary>
        /// Gets about navigation
        /// </summary>
        private LazyElement AboutNavigation
        {
            get { return this.GetLazyElement(By.CssSelector("#About"), "About"); }
        }

        /// <summary>
        /// Gets contact navigation
        /// </summary>
        private LazyElement ContactNavigation
        {
            get { return this.GetLazyElement(By.CssSelector("#Contact"), "Contact"); }
        }

        public Home OpenSiteRootTab()
        {
            SiteRootNavigation.Click();
            return new Home(this.TestObject);
        }

        public Home OpenHomeTab()
        {
            HomeNavigation.Click();
            return new Home(this.TestObject);
        }

        public About OpenAboutTab()
        {
            AboutNavigation.Click();
            return new About(this.TestObject);
        }

        public Contact OpenContactTab()
        {
            ContactNavigation.Click();
            return new Contact(this.TestObject);
        }
    }
}
