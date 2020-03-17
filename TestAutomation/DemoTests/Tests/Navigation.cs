using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModel;

namespace Tests
{
    /// <summary>
    /// Tests test class
    /// </summary>
    [TestClass]
    public class Navigation : BaseSelenium
    {
        /// <summary>
        /// Open home page
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.Smoke)]
        public void OpenHome()
        {
            Home page = new Home(this.TestObject);
            page.OpenPage();
            Assert.IsTrue(page.IsPageLoaded(), "Page was not loaded");
        }

        /// <summary>
        /// Page navigation
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.Smoke)]
        public void ValidateNavigation()
        {
            Home home = new Home(this.TestObject);
            home.OpenPage();
            Assert.IsTrue(home.IsPageLoaded(), "Home page was not loaded");

            About about = home.OpenAboutTab();
            Assert.IsTrue(about.IsPageLoaded(), "About page was not loaded");

            Contact contact = about.OpenContactTab();
            Assert.IsTrue(contact.IsPageLoaded(), "Contact page was not loaded");
        }
    }
}