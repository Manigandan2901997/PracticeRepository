
using OpenQA.Selenium;
using ReportingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationFramework.Pages
{
    public class HomePage
    {
        ExtentReportsHelper extentHelper;
        IWebDriver Driver;
       

        public HomePage(IWebDriver driver, ExtentReportsHelper extentReportHelper)
        {
            extentHelper = extentReportHelper;
            Driver = driver;
        }

        public IWebElement RoundtableLink => Driver.FindElement(By.LinkText("RoundTable"));
        public IWebElement PastRoundtableTab => Driver.FindElement(By.XPath("//button[contains(.,'Past')]"));
        public IWebElement NotificationLink => Driver.FindElement(By.LinkText("Notifications"));
        public  bool checkRoundTableLink => RoundtableLink.Displayed;
        public bool checkPastRoundTableTab => PastRoundtableTab.Displayed;

        public void NavigateToRoundTable()
        {
            RoundtableLink.Click();
            extentHelper.test.Info("Clicked on roundtable link");
            Thread.Sleep(2000);
        }
        public void NavigateToNotification()
        {
            NotificationLink.Click();
            extentHelper.test.Info("Clicked on Notification link");

            Thread.Sleep(2000);
        }


    }
}
