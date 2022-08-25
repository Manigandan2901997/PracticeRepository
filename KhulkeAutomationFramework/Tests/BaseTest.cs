
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using ReportingLibrary;
using KhulkeKhulkeAutomationFramework.Tests;

namespace KhulkeAutomationFramework.Tests
{
    [TestClass]
    public class BaseTest
    {
        public static IWebDriver driver;
        protected ExtentReportsHelper extent;
        public TestContext TestContext { get; set; }
        public static IWebDriver Driver { get => driver; set => driver = value; }

        [ClassInitialize]        
        public void SetUpReporter()
        {
            extent = new ExtentReportsHelper();
        }

        [ClassCleanup]
        protected void TearDown()
        {
            extent.Close();
        }

        [TestInitialize]
        public void Setup()
        {
            Driver = DriverManagement.GetChromeDriver();
            Thread.Sleep(4000);
            Driver.Manage().Window.Maximize();
            // _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);

        }

        [TestCleanup]
        public void Cleanup()
        {
            try
            {
                var status = TestContext.CurrentTestOutcome;
                 var errorMessage = "<pre>" + TestContext.CurrentTestOutcome + "</pre>";
                switch (status)
                {
                    case UnitTestOutcome.Passed:
                        extent.SetTestStatusFail($"<br>{errorMessage}<br>");
                        // extent.AddTestFailureScreenshot(driver.ScreenCaptureAsBase64String());
                        break;
                    case UnitTestOutcome.NotRunnable:
                        extent.SetTestStatusSkipped();
                        break;
                    default:
                        extent.SetTestStatusPass();
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                driver.Close();
            }
        }
        public static string Capture(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var reportPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(reportPath + "Reports\\" + "Screenshots");
            var finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports\\Screenshots\\" + screenShotName;
            var localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return reportPath;
        }
    }
}

