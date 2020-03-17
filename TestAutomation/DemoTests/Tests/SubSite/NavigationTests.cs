//--------------------------------------------------
// <copyright file="NavigationTests.cs" company="Magenic">
//  Copyright 2016 Magenic, All rights Reserved
// </copyright>
// <summary>Sample Selenium test class</summary>
//--------------------------------------------------
using Magenic.Maqs.Utilities.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModel.SubSite;
using PageModel.SubSite.Pages;

namespace Tests.SubSite
{
    /// <summary>
    /// Sample test class
    /// </summary>
    [TestClass]
    public class NavigationTests : BaseSelenium
    {
        private readonly string userName = Config.GetGeneralValue("UserName");
        private readonly string password = Config.GetGeneralValue("Password");

        /// <summary>
        /// Valid login test
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.Smoke)]
        public void ValidLoginTest()
        {
            LoginPage login = new LoginPage(this.TestObject);
            login.OpenLoginPage();
            HomePage home = login.LoginWithValidCredentials(userName, password);
            Assert.IsTrue(home.IsPageLoaded());
        }

        /// <summary>
        /// Invalid login test
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.Regression)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
    @"|DataDirectory|\TestData\InvalidLogins.csv",
    "InvalidLogins#csv",
    DataAccessMethod.Sequential)]
        public void InvalidLoginTest()
        {
            // Remover data driving until MS fixes reporting bug
            string badUserName = TestContext.DataRow["UserName"].ToString();
            string badPassword = TestContext.DataRow["Password"].ToString();


            LoginPage login = new LoginPage(this.TestObject);
            login.OpenLoginPage();
            login.LoginWithInvalidCredentials(badUserName, badPassword);
            Assert.IsTrue(login.IsPageLoaded());
        }

        /// <summary>
        /// Sample test
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.Regression)]
        public void NavigateToHowWork()
        {
            LoginPage login = new LoginPage(this.TestObject);
            login.OpenLoginPage();
            HomePage home = login.LoginWithValidCredentials(userName, password);
            Assert.IsTrue(home.ClickHowWorkNavigation().IsPageLoaded());
        }

        [TestMethod]
        [TestCategory(TestCategories.Regression)]
        public void NavigateToAsync()
        {
            LoginPage login = new LoginPage(this.TestObject);
            login.OpenLoginPage();
            HomePage home = login.LoginWithValidCredentials(userName, password);
            Assert.IsTrue(home.ClickAsyncNavigation().IsPageLoaded());
        }

        [TestMethod]
        [TestCategory(TestCategories.Regression)]
        public void NavigateToAbout()
        {
            LoginPage login = new LoginPage(this.TestObject);
            login.OpenLoginPage();
            HomePage home = login.LoginWithValidCredentials(userName, password);
            AsyncPage demo = home.ClickAsyncNavigation();
            Assert.IsTrue(demo.IsPageLoaded());
        }

        /// <summary>
        /// Navigation tests
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.Regression)]
        public void ChainedNavigate()
        {
            LoginPage login = new LoginPage(this.TestObject);
            login.OpenLoginPage();
            HomePage home = login.LoginWithValidCredentials(userName, password);

            HowWorkPage howWorks = home.ClickHowWorkNavigation();
            Assert.IsTrue(howWorks.IsPageLoaded());

            AboutPage about = howWorks.ClickAboutNavigation();
            Assert.IsTrue(about.IsPageLoaded());

            AsyncPage asyncPage = about.ClickAsyncNavigation();
            Assert.IsTrue(asyncPage.IsPageLoaded());

            home = asyncPage.ClickHomeNavigation();
            Assert.IsTrue(home.IsPageLoaded());
        }
    }
}
