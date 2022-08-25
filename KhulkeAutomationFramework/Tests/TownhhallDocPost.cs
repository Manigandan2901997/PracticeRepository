using AutomationFramework.HelperMethods;
using AutomationFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AutomationFramework.Tests
{
    internal class TownhhallDocPost:BaseTest
    {
        [Test]
        [Category("sanity")]
        public void PostPDFonTownhallTest()
        {

            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string filePath = HelperClass.GetPath("Testingpdf.pdf");
            driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(3) > input")).SendKeys(filePath);
            // driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys(Keys.Enter);
            driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys("Testing basics");
            driver.FindElement(By.XPath("//button[normalize-space()='Post']")).Click();
            var alert_win = driver.SwitchTo().Alert();
            alert_win.Accept();
            Assert.IsTrue(driver.FindElement(By.XPath("//p[normalize-space()='Testingpdf.pdf']")).Displayed);
            extent.test.Info("Document posted on townhall");
        }
        [Test]
        public void DiscardDocPostTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            string filePath = HelperClass.GetPath("Testingpdf.pdf");
            // TownhallPage townhallPage = new TownhallPage(Driver, extent);
            //  townhallPage.DiscardPost("video");
            // driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(1) > img")).Click();
            IWebElement videoFile = driver.FindElement(By.XPath("//input[@accept='.doc,.docx,.pdf,.xlsx,.xls,.ppt,.pptx']"));
            videoFile.SendKeys(filePath);
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys("Document upload discard");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@role='dialog']//h2//div//div//div//button[@type='button']")).Click();
            Thread.Sleep(2000);
            Assert.That(!driver.FindElement(By.XPath("(//div[@id='townhall_post_body'])[1]/p")).Text.Equals("Document upload discard"));
            extent.test.Info("Document uploaded on townhall is discarded");
        }
        [Test]
        public void AlertUploadDocBigsizeTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);            
            string filePath = HelperClass.GetPath("above15mbPDF.pdf");
            driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(3) > input")).SendKeys(filePath);
            // driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys(Keys.Enter);
            // driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys("Testing basics");
            //driver.FindElement(By.XPath("//button[normalize-space()='Post']")).Click();
            
            var alert_win = driver.SwitchTo().Alert();
            Assert.That(alert_win.Text.Equals(AlertsData.allAlerts["DocBigSizeALert"]));
            extent.test.Info("Above 15Mb Document posted on townhall shows alert");
            alert_win.Accept();
        }
        [Test]
        [Category("sanity")]

        public void PostAllTypeFilesTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[1], TestData.password);
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            //uploading.doc file
            string filePathDoc = HelperClass.GetPath("above15mbPDF.pdf");
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/div[2]/div[1]/label[3]/input[1]")).SendKeys(filePathDoc);
            driver.FindElement(By.CssSelector(".main_container > div:nth-child(1) > span:nth-child(2) > textarea:nth-child(1)")).SendKeys("Word Doc automation Test");
            driver.FindElement(By.CssSelector("div.sc-hOqruk:nth-child(1) > button:nth-child(2)")).Click();            
            wait.Until(driver => HelperClass.IsAlertShown((WebDriver)driver));
            var alert_win = driver.SwitchTo().Alert();
            alert_win.Accept();
            Thread.Sleep(2000);
            //uploading .xlxs file
            string filePathXlxs = HelperClass.GetPath("above15mbPDF.pdf");
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/div[2]/div[1]/label[3]/input[1]")).SendKeys(filePathXlxs);
            driver.FindElement(By.CssSelector(".main_container > div:nth-child(1) > span:nth-child(2) > textarea:nth-child(1)")).SendKeys("Exel file automation Test");
            driver.FindElement(By.CssSelector("div.sc-hOqruk:nth-child(1) > button:nth-child(2)")).Click();           
            wait.Until(driver => HelperClass.IsAlertShown((WebDriver)driver));
            var alert_win1 = driver.SwitchTo().Alert();
            alert_win.Accept();
            Thread.Sleep(2000);
            //uploading .ppt file
            string filePathPPT = HelperClass.GetPath("above15mbPDF.pdf");
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/div[2]/div[1]/label[3]/input[1]")).SendKeys(filePathPPT);
            driver.FindElement(By.CssSelector(".main_container > div:nth-child(1) > span:nth-child(2) > textarea:nth-child(1)")).SendKeys("Powerpoint file automation Test");
            driver.FindElement(By.CssSelector("div.sc-hOqruk:nth-child(1) > button:nth-child(2)")).Click();            
            wait.Until(driver => HelperClass.IsAlertShown((WebDriver)driver));
            var alert_win2 = driver.SwitchTo().Alert();
            alert_win.Accept();
            Thread.Sleep(2000);
            //uploading PDF file
            string filePathPDF = HelperClass.GetPath("above15mbPDF.pdf");
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/div[2]/div[1]/label[3]/input[1]")).SendKeys(filePathPDF);
            driver.FindElement(By.CssSelector(".main_container > div:nth-child(1) > span:nth-child(2) > textarea:nth-child(1)")).SendKeys("PDF file automation Test");
            driver.FindElement(By.CssSelector("div.sc-hOqruk:nth-child(1) > button:nth-child(2)")).Click();
            wait.Until(driver => HelperClass.IsAlertShown((WebDriver)driver));
            var alert_win3 = driver.SwitchTo().Alert();
            alert_win.Accept();
            Thread.Sleep(2000);
        }

        [Test]
        public void VerifyUnsupportedfileTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[1], TestData.password);
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            string filePath = HelperClass.GetPath("PVS_2086.JPG");
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/div[2]/div[1]/label[3]/input[1]")).SendKeys(filePath);
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".main_container > div:nth-child(1) > span:nth-child(2) > textarea:nth-child(1)")).SendKeys("Text doc unsupportive file automation Test");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => HelperClass.IsAlertShown((WebDriver)driver));
            var alert_win = driver.SwitchTo().Alert();
            alert_win.Accept();
            Thread.Sleep(2000);
        }
        [Test]
        public void PreviewFileUploadTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[1], TestData.password);
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            string filePath = HelperClass.GetPath("above15mbPDF.pdf");
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/div[2]/div[1]/label[3]/input[1]")).SendKeys(filePath);
            driver.FindElement(By.CssSelector(".main_container > div:nth-child(1) > span:nth-child(2) > textarea:nth-child(1)")).SendKeys("File preview Automation");
            driver.FindElement(By.CssSelector("div.MuiGrid-root:nth-child(3) > div:nth-child(1) > div:nth-child(1) > div:nth-child(2) > a:nth-child(2)")).Click();
            Thread.Sleep(3000);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            driver.FindElement(By.CssSelector("div.sc-hOqruk:nth-child(1) > button:nth-child(2)")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => HelperClass.IsAlertShown((WebDriver)driver));
            var alert_win3 = driver.SwitchTo().Alert();
            alert_win3.Accept();
        }

        [Test]
        public void VerifyDownloadDocTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[1], TestData.password);
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);            
            IWebElement download = driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/a[1]"));
            Thread.Sleep(2000);
            download.SendKeys(Keys.Enter);
        }
    }
}
