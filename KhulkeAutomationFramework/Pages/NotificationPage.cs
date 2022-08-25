using OpenQA.Selenium;
using ReportingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Pages
{
    internal class  NotificationPage
    {
        ExtentReportsHelper extentHelper;
        IWebDriver Driver;

        public NotificationPage(IWebDriver driver, ExtentReportsHelper extentReportHelper)
        {
            extentHelper = extentReportHelper;
            Driver = driver;
        }
        public IWebElement NotificationLink => Driver.FindElement(By.LinkText("Notifications"));
        public IWebElement NetworkTab => Driver.FindElement(By.CssSelector(".sc-cVksOY .MuiButtonBase-root:nth-child(2)"));
        public IWebElement RoundtableTab => Driver.FindElement(By.CssSelector(".MuiTab-root:nth-child(3)"));

        public void ClickonNotification()
        {
            NotificationLink.Click();
        }

        public void ClickonNetworkTab()
        {
            NetworkTab.Click();
            
        }
        public void ClickonRoundTableTab()
        {
            RoundtableTab.Click();

        }
    }
}
