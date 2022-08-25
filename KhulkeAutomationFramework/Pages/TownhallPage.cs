using NUnit.Framework;
using OpenQA.Selenium;
using ReportingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AutomationFramework.Pages
{
    public class  TownhallPage
    {

        ExtentReportsHelper extentHelper;
        IWebDriver Driver;


        public TownhallPage(IWebDriver driver, ExtentReportsHelper extentReportHelper)
        {
            Driver = driver;
            extentHelper = extentReportHelper;
        }

        public IWebElement kebabMenu => Driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[2]/div[1]/div[2]/button[1]"));
        public IWebElement deleteLi => Driver.FindElement(By.XPath("//li[contains(text(),'Delete')]"));
        
        public void DeletePost(string elementPath)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
           
            IWebElement saveBtn = Driver.FindElement(By.XPath(elementPath));
            saveBtn.SendKeys(Keys.Enter);
            Driver.FindElement(By.XPath("//li[normalize-space()='Delete']")).Click();
            Thread.Sleep(1000);
            var alert_win = Driver.SwitchTo().Alert();            
            Assert.That(alert_win.Text, Is.EqualTo("Successfully Deleted"));
            alert_win.Accept();


        }
    }
}
