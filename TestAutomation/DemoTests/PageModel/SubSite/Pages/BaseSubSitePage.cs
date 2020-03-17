using Magenic.Maqs.BaseSeleniumTest;
using Magenic.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel.SubSite.Pages
{
    /// <summary>
    /// Page object for the login page
    /// </summary>
    public abstract class BaseSubSitePage  : BaseSeleniumPageModel
    {
        /// <summary>
        /// Element of type input. This is a field that requires user input.
        /// </summary>
        private LazyElement HomeNavigation
        {
            get { return this.GetLazyElement(By.CssSelector("#Home"), "Home"); }
        }

        /// <summary>
        /// Element of type input. This is a field that requires user input.
        /// </summary>
        private LazyElement HowWorkNavigation
        {
            get { return this.GetLazyElement(By.CssSelector("#HowWork"), "HowWork"); }
        }

        /// <summary>
        /// Element of type input. This is a field that requires user input.
        /// </summary>
        private LazyElement AsyncNavigation
        {
            get { return this.GetLazyElement(By.CssSelector("#Async"), "Async"); }
        }

        /// <summary>
        /// Element of type input. This is a field that requires user input.
        /// </summary>
        private LazyElement AboutNavigation
        {
            get { return this.GetLazyElement(By.CssSelector("#About"), "About"); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Model1" /> class.
        /// </summary>
        /// <param name="webDriver">The selenium web driver</param>
        protected BaseSubSitePage(SeleniumTestObject testObject) : base(testObject)
        {

        }

        /// <summary>
        /// Click the home navigation link
        /// </summary>
        /// <returns>The home page</returns>
        public HomePage ClickHomeNavigation()
        {
            HomeNavigation.Click();
            return new HomePage(this.TestObject);
        }

        /// <summary>
        /// Click the how work navigation link
        /// </summary>
        /// <returns>The how work page</returns>
        public HowWorkPage ClickHowWorkNavigation()
        {
            HowWorkNavigation.Click();
            return new HowWorkPage(this.TestObject);
        }

        /// <summary>
        /// Click the async navigation link
        /// </summary>
        /// <returns>The async page</returns>
        public AsyncPage ClickAsyncNavigation()
        {
            AsyncNavigation.Click();
            return new AsyncPage(this.TestObject);
        }

        /// <summary>
        /// Click the about navigation link
        /// </summary>
        /// <returns>The about page</returns>
        public AboutPage ClickAboutNavigation()
        {
            AboutNavigation.Click();
            return new AboutPage(this.TestObject);
        }
    }
}
