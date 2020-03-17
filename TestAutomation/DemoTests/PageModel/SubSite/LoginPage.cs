//--------------------------------------------------
// <copyright file="LoginPageModel.cs" company="Magenic">
//  Copyright 2015 Magenic, All rights Reserved
// </copyright>
// <summary>Page object for the login page</summary>
//--------------------------------------------------
using Magenic.Maqs.BaseSeleniumTest;
using Magenic.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;
using PageModel.SubSite.Pages;

namespace PageModel.SubSite
{
    /// <summary>
    /// Page object for the login page
    /// </summary>
    public class LoginPage : BaseSeleniumPageModel
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = SeleniumConfig.GetWebSiteBase().Trim('/') + "/static/BasicSite/LoginPage.html";

        /// <summary>
        /// The user name input element 'By' finder
        /// </summary>
        public LazyElement UserName
        {
            get { return this.GetLazyElement(By.CssSelector("#UserName"), "UserName"); }
        }

        /// <summary>
        /// The password input element 'By' finder
        /// </summary>
        public LazyElement Password
        {
            get { return this.GetLazyElement(By.CssSelector("#Password"), "Password"); }
        }

        public LazyElement LoginButton
        {
            get { return this.GetLazyElement(By.CssSelector("#Login"), "Login button"); }
        }

        /// <summary>
        /// The login error message element 'By' finder
        /// </summary>
        public LazyElement LoginError
        {
            get { return this.GetLazyElement(By.CssSelector("#LoginError"), "LoginError"); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Model1" /> class.
        /// </summary>
        /// <param name="webDriver">The selenium web driver</param>
        public LoginPage(SeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// Open the login page
        /// </summary>
        public void OpenLoginPage()
        {
            // Open the gmail login page
            this.WebDriver.Navigate().GoToUrl(PageUrl);
        }

        /// <summary>
        /// Enter the use credentials
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The user password</param>
        public void EnterCredentials(string userName, string password)
        {
            UserName.SendKeys(userName);
            Password.SendKeys(password);
        }

        /// <summary>
        /// Enter the use credentials and log in
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The user password</param>
        public HomePage LoginWithValidCredentials(string userName, string password)
        {
            EnterCredentials(userName, password);
            LoginButton.Click();

            return new HomePage(this.TestObject);
        }

        /// <summary>
        /// Enter the use credentials and try to log in - Verify login failed
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The user password</param>
        public void LoginWithInvalidCredentials(string userName, string password)
        {
            EnterCredentials(userName, password);
            LoginButton.Click();
            LoginError.GetTheVisibleElement();
        }

        /// <summary>
        /// Verify we are on the login page
        /// </summary>
        public override bool IsPageLoaded()
        {
            return this.WebDriver.Wait().UntilElementExist(Password.By);
        }
    }
}