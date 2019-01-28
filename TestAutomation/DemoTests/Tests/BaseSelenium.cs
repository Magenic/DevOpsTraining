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
        //[TestInitialize]
        //public void SetName()
        //{
        //    if (SeleniumConfig.GetBrowserName().Equals("Remote", System.StringComparison.CurrentCultureIgnoreCase))
        //    {
        //        try
        //        {
        //            string name = TestContext.FullyQualifiedTestClassName + "." + TestContext.TestName;
        //            ((IJavaScriptExecutor)this.WebDriver).ExecuteScript("sauce:job-name=" + name);
        //        }
        //        catch (Exception e)
        //        {
        //            this.Log.LogMessage(MessageType.WARNING, "Failed to set Sauce name because: " + e.Message);
        //        }
        //    }
        //}

        //[TestCleanup]
        //public new void Teardown()
        //{
        //    bool passed = this.GetResultType() == TestResultType.PASS;

        //    if (SeleniumConfig.GetBrowserName().Equals("Remote", System.StringComparison.CurrentCultureIgnoreCase))
        //    {
        //        try
        //        {
        //            // Logs the result to Sauce Labs
        //            ((IJavaScriptExecutor)this.WebDriver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
        //            ((IJavaScriptExecutor)this.WebDriver).ExecuteScript("sauce:job-build=" + Config.GetGeneralValue("Build", "0.0.0.0"));
        //        }
        //        catch (Exception e)
        //        {
        //            this.Log.LogMessage(MessageType.WARNING, "Failed to set Sauce result because: " + e.Message);
        //        }
        //    }

        //    string screenshotPath = string.Empty;
        //    string directory = TestContext.TestResultsDirectory;

        //    if (!passed && this.Log is FileLogger)
        //    {
                
        //        Directory.CreateDirectory(directory);

        //        string path = ((FileLogger)this.Log).FilePath;
        //        string destination = Path.Combine(directory, Path.GetFileName(path));

        //        this.Log.LogMessage(path);

        //        screenshotPath = Path.ChangeExtension(path, "png");

        //        File.Copy(path, destination);
        //        TestContext.AddResultFile(destination);
        //    }

        //    base.Teardown();

        //    if (!passed && !string.IsNullOrEmpty(screenshotPath) && File.Exists(screenshotPath))
        //    {
        //        string destination = Path.Combine(directory, Path.GetFileName(screenshotPath));
        //        File.Copy(screenshotPath, destination);
        //        TestContext.AddResultFile(destination);
        //    }
       // }
    }
}
