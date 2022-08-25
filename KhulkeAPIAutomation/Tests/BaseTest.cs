using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using KhulkeAPIAutomation.HelperMethods;

namespace KhulkeAPIAutomation.Tests
{
    [SetUpFixture]
    public abstract class BaseTest
    {
        //public static ExtentReports _extent;
        public ExtentTest _test;
        public ExtentReports reporter = SimpleReportFactory.getReporter();


        [OneTimeSetUp]
        protected void Setup()
        {
            
        }

        [OneTimeTearDown]
        protected void TearDown()
        {
            reporter.Flush();
        }

        [SetUp]
        public void BeforeTest()
        {
           _test = reporter.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void AfterTest()
        {
            string stacktrace = "";
            string message = "";
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == TestStatus.Failed)
            {
                 stacktrace = "stacktrace: " + TestContext.CurrentContext.Result.StackTrace;
                 message = "Error Message: " + TestContext.CurrentContext.Result.Message;
            }

            //var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? ""
            //: string.Format("{ 0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            _test.Log(logstatus, "Test ended with " +logstatus +" "+message+" "+stacktrace+"");
           // _extent.Flush();
        }
       
    }
}