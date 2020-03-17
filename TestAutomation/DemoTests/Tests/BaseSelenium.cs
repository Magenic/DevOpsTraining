using Magenic.Maqs.BaseSeleniumTest;
using Magenic.Maqs.Utilities.Helper;
using Magenic.Maqs.Utilities.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class BaseSelenium : BaseSeleniumTest
    {
        [TestInitialize]
        public void SetName()
        {
            if (SeleniumConfig.GetBrowserName().Equals("Remote", System.StringComparison.CurrentCultureIgnoreCase))
            {
                try
                {
                    string name = TestContext.FullyQualifiedTestClassName + "." + TestContext.TestName;

                    RemoteBrowserType remoteBrowser = SeleniumConfig.GetRemoteBrowserType();
                    string remotePlatform = SeleniumConfig.GetRemotePlatform();
                    string remoteBrowserVersion = SeleniumConfig.GetRemoteBrowserVersion();
                    Dictionary<string, object> capabilities = SeleniumConfig.GetRemoteCapabilitiesAsObjects();
                    capabilities.Add("build", Environment.GetEnvironmentVariable("SAUCE_BUILD_NAME"));
                    capabilities.Add("name", name);
                    capabilities.Add("extendedDebugging", Config.GetValueForSection(ConfigSection.SeleniumMaqs, "extendedDebugging"));

                    var options = WebDriverFactory.GetRemoteOptions(remoteBrowser, remotePlatform, remoteBrowserVersion, capabilities);

                    this.WebDriver = new RemoteWebDriver(SeleniumConfig.GetHubUri(), options.ToCapabilities(), SeleniumConfig.GetCommandTimeout());
                }
                catch (Exception e)
                {
                    Log.LogMessage(MessageType.WARNING, "Failed to set Sauce name because: " + e.Message);
                }
            }
        }

        [TestCleanup]
        public new void Teardown()
        {
            bool passed = GetResultType() == TestResultType.PASS;

            if (SeleniumConfig.GetBrowserName().Equals("Remote", System.StringComparison.CurrentCultureIgnoreCase))
            {
                try
                {
                    // Logs the result to Sauce Labs
                    ((IJavaScriptExecutor)WebDriver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));


                }
                catch (Exception e)
                {
                    Log.LogMessage(MessageType.WARNING, "Failed to set Sauce result because: " + e.Message);
                }
            }

            base.Teardown();
        }
    }
}
