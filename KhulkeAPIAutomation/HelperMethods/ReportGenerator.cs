using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KhulkeAPIAutomation.HelperMethods
{
      public class SimpleReportFactory
        {

            public static ExtentReports reporter;

            public static ExtentReports getReporter()
            {
                if (reporter == null)
                {
                    var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                    var actualPath = path.Substring(0, path.LastIndexOf("bin"));
                    var projectPath = new Uri(actualPath).LocalPath;
                    Directory.CreateDirectory(projectPath.ToString() + "Reports");
                    var reportPath = projectPath + "Reports\\ExtentReport.html";
                    var htmlReporter = new ExtentHtmlReporter(reportPath);
                    reporter = new ExtentReports();
                    reporter.AttachReporter(htmlReporter);
                    reporter.AddSystemInfo("Host Name", "LocalHost");
                    reporter.AddSystemInfo("Environment", "QA");
                    reporter.AddSystemInfo("UserName", "Ram");
                }
                return reporter;
            }

            public static void closeReporter()
            {
                reporter.Flush();              
            }

        }    
}
