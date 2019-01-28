using Magenic.Maqs.BaseSeleniumTest;
using Magenic.Maqs.Utilities.Helper;
using Magenic.Maqs.Utilities.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.IO;

namespace Tests
{
   // [TestClass]
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
                    ((IJavaScriptExecutor)this.WebDriver).ExecuteScript("sauce:job-name=" + name);
                }
                catch (Exception e)
                {
                    this.Log.LogMessage(MessageType.WARNING, "Failed to set Sauce name because: " + e.Message);
                }
            }
        }

        [TestCleanup]
        public new void Teardown()
        {
            try
            {
                bool passed = this.GetResultType() == TestResultType.PASS;

                if (SeleniumConfig.GetBrowserName().Equals("Remote", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    try
                    {
                        // Logs the result to Sauce Labs
                        ((IJavaScriptExecutor)this.WebDriver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
                        ((IJavaScriptExecutor)this.WebDriver).ExecuteScript("sauce:job-build=" + Config.GetGeneralValue("Build", "0.0.0.0"));
                    }
                    catch (Exception e)
                    {
                        this.Log.LogMessage(MessageType.WARNING, "Failed to set Sauce result because: " + e.Message);
                    }
                }
            }
            finally
            {
                base.Teardown();
            }
        }
    }
}
