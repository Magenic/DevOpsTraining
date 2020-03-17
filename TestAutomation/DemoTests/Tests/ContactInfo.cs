using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModel;

namespace Tests
{
    /// <summary>
    /// Contact test class
    /// </summary>
    [TestClass]
    public class ContactInfo : BaseSelenium
    {
        /// <summary>
        /// Check that the contact info is valid
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.Smoke)]
        public void ValidateContactInfo()
        {
            Home home = new Home(this.TestObject);
            home.OpenPage();

            Contact contact = home.OpenContactTab();

            this.SoftAssert.AreEqual("Magenic", contact.CompanyName.Text);
            this.SoftAssert.AreEqual("Info: info@magenic.com", contact.EmailContact.Text);
            this.SoftAssert.FailTestIfAssertFailed();
        }
    }
}
