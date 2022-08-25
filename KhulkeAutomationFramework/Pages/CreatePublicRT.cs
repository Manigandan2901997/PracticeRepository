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
    internal class CreatePublicRT
    {
        ExtentReportsHelper extentHelper;
        IWebDriver Driver;


        public CreatePublicRT(IWebDriver driver, ExtentReportsHelper extentReportHelper)
        {
            extentHelper = extentReportHelper;
            Driver = driver;
        }
        //!Create RT elements
        public IWebElement RoundtableLink => Driver.FindElement(By.LinkText("RoundTable"));
        public IWebElement newBtn => Driver.FindElement(By.CssSelector(".follow-button-small > span"));
        public IWebElement rtName => Driver.FindElement(By.CssSelector(".form-control-div > input"));
        public IWebElement rtDesc => Driver.FindElement(By.CssSelector("textarea"));

        public IWebElement rtDatebtn => Driver.FindElement(By.CssSelector("button.MuiButtonBase-root:nth-child(1)"));

        public IWebElement rtDate => Driver.FindElement(By.CssSelector("div.css-mvmu1r:nth-child(5) > div:nth-child(4) > button:nth-child(1)"));

        public IWebElement autoRec => Driver.FindElement(By.CssSelector(".switch"));



        public IWebElement continuBtn => Driver.FindElement(By.CssSelector(".btn"));
        public IWebElement moderator => Driver.FindElement(By.Id("react-select-6-input"));
        public IWebElement moderatorDesc => Driver.FindElement(By.CssSelector(".introCount:nth-child(3) > textarea"));
        public IWebElement panelist => Driver.FindElement(By.Id("react-select-7-input"));
        public IWebElement panintro => Driver.FindElement(By.CssSelector("div.introCount:nth-child(7) > textarea:nth-child(1)"));
        public IWebElement addPanelistBtn => Driver.FindElement(By.CssSelector(".addpanelistbtn"));
        public IWebElement addCategory => Driver.FindElement(By.CssSelector("div:nth-child(2) > .form-control-div > input"));
        public IWebElement addTag => Driver.FindElement(By.CssSelector("div:nth-child(4) > .form-control-div > input"));
        public IWebElement followChk => Driver.FindElement(By.CssSelector(".follow_detail:nth-child(3) span"));
        public IWebElement proceedBtn => Driver.FindElement(By.CssSelector(".proceed_btn"));

        public void CreateNewPublicRT()
        {
            //RoundtableLink.Click();
            //Thread.Sleep(2000);
            //newBtn.Click();
            //Thread.Sleep(2000);
            //rtName.Click();
            //Thread.Sleep(2000);
            //rtName.SendKeys("Test RT 1 ");
            //rtDesc.Click();
            //rtDesc.SendKeys("This is test roundtable");
            //continuBtn.SendKeys(Keys.Enter);
            //Thread.Sleep(2000);
            //moderator.SendKeys("TestUser15");
            //Thread.Sleep(2000);
            //moderator.SendKeys(Keys.Enter);
            //moderatorDesc.SendKeys("TestUser15 is moderator");

            //panelist.SendKeys("testKhulke");
            //Thread.Sleep(2000);
            //panelist.SendKeys(Keys.Enter);
            //panintro.SendKeys("testKhulke is panelist");
            //addPanelistBtn.SendKeys(Keys.Enter);
            //continuBtn.SendKeys(Keys.Enter);
            //addCategory.SendKeys("politics");
            //addCategory.SendKeys(Keys.Enter);
            //addTag.Click();
            //Thread.Sleep(3000);
            //addTag.SendKeys("public rt");
            //addTag.SendKeys(Keys.Enter);
            //continuBtn.SendKeys(Keys.Enter);
            //Thread.Sleep(2000);
            ////followChk.Click();
            ////Thread.Sleep(2000);
            ////followChk.SendKeys(Keys.Enter);
            //continuBtn.Click();
            //Thread.Sleep(3000);
            ////js.ExecuteScript("window.scrollTo(0,0)");
            //proceedBtn.SendKeys(Keys.Enter);
            //Thread.Sleep(4000);


        }

        public void CreateRT1()
        {
            RoundtableLink.Click();
            newBtn.Click();
            rtName.Click();
            rtName.SendKeys("Test Roundtable");
            rtDesc.Click();
            rtDesc.SendKeys("Test Roundtable");
            Thread.Sleep(2000);

        }
    }
}
