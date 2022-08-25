using AutomationFramework.Pages;
using AutomationFramework.HelperMethods;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace AutomationFramework.Tests
{
    internal class TownhallAudioPost: BaseTest
    {
        [Test, Order(1)]
        [Category("sanity")]
        public void PostAudioOnTownhall()
        {

            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();           
            string filePath = HelperClass.GetPath("testingaudio.mp3");

            //var dirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            // var folderPath = dirPath.Substring(0, dirPath.IndexOf("bin"));
            //var filePath = folderPath + "assets\\testingaudio.mp3";
            //  var filePath = "..\\..\\..\\assets\\testingaudio.mp3";
            driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(4) > input")).SendKeys(filePath);
           
            driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys(TestData.audioPostTitle);
            //IWebElement postBtn = HelperClass.WaitForElement((WebDriver)driver, "//body/div[4]/div[3]/div[1]/div[2]/div[1]/button[1]");               
            //postBtn.Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => HelperClass.IsAlertShown((WebDriver) driver));
            var alert_win = driver.SwitchTo().Alert();
            alert_win.Accept();
            Thread.Sleep(2000);
            Assert.IsTrue(driver.FindElement(By.XPath("//p[normalize-space()='"+ TestData.audioPostTitle+"']")).Displayed);
            extent.test.Info("Audio posted on townhall");
        }
        [Test, Order(2)]
        public void DeletePostTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            TownhallPage townhallPage = new TownhallPage(driver, extent);
            string elementpath = "(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.audioPostTitle + "')]//ancestor::div[@id='townhall_post_container']//div[@id='post_header_container']//div[2]/button[@id='basic-button'])[1]";
            townhallPage.DeletePost(elementpath);
            //IWebElement saveBtn = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']//div[@id='post_header_container']//div[2]/button[@id='basic-button'])[1]"));
            //saveBtn.SendKeys(Keys.Enter);
            //driver.FindElement(By.XPath("//li[normalize-space()='Delete']")).Click();
            //Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("Successfully Deleted"));
            extent.test.Info("post deleted");
        }

        [Test]
        public void DiscardAudioPostTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            string filePath = HelperClass.GetPath("testingaudio.mp3");
            IWebElement audioFile = driver.FindElement(By.XPath("//input[@accept='audio/*']"));
            audioFile.SendKeys(filePath);
            driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys("Audio upload discard");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@role='dialog']//h2//div//div//div//button[@type='button']")).Click();
            Thread.Sleep(2000);
            Assert.That(!driver.FindElement(By.XPath("(//div[@id='townhall_post_body'])[1]/p")).Text.Equals("Audio upload discard"));
            extent.test.Info("Audio uploaded on townhall is discarded");
        }
        [Test]
        public void AlertUploadAudioBigsizeTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string filePath = HelperClass.GetPath("above250mbaudio.mp3"); 
            driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(4) > input")).SendKeys(filePath);
            // driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys(Keys.Enter);
            // driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys("Testing basics");
            //driver.FindElement(By.XPath("//button[normalize-space()='Post']")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => HelperClass.IsAlertShown((WebDriver)driver));
            var alert_win = driver.SwitchTo().Alert();
            Assert.That(alert_win.Text.Equals(AlertsData.allAlerts["AudioBigSizeALert"]));
            extent.test.Info("Above 250Mb audio posted on townhall shows alert");
            alert_win.Accept();
        }

        [Test]
        public void AlertUploadAudioAbove230MinTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string filePath = HelperClass.GetPath("above250mbaudio.mp3");
            driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(4) > input")).SendKeys(filePath);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => HelperClass.IsAlertShown((WebDriver)driver));
            var alert_win = driver.SwitchTo().Alert();
            Assert.That(alert_win.Text.Equals(AlertsData.allAlerts["AudioTimeLimitAlert"]));
            extent.test.Info("Above 2:30 min audio posted on townhall shows alert");
            alert_win.Accept();
        }

        [Test]
        public void CropAudioValidationTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string filePath = HelperClass.GetPath("above2-30minaudio.mp3");
            driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(4) > input")).SendKeys(filePath);
            driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys("Crop audio upload");
            driver.FindElement(By.XPath("(//div[@class='icon_container']/button)[2]")).Click();
            var endMinute = driver.FindElement(By.XPath("(//input[@placeholder='00'])[3]"));
            var endMinuteValue = endMinute.GetAttribute("value");           
            var script = "arguments[0].scrollIntoView(true);";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script, endMinute);
            
            // driver.FindElement(By.XPath("//body/div[4]/div[3]/div[1]/div[1]/div[1]/div[2]/div[1]/div[3]/div[1]/div[1]/div[2]/div[2]/input[1]")).Clear();
            var endSecondValue = driver.FindElement(By.XPath("(//input[@placeholder='00'])[4]")).GetAttribute("value");
            Assert.That((endMinuteValue.Equals("02")) && (endSecondValue.Equals("30")));
            extent.test.Info("Validated default crop value for audio post");
            driver.FindElement(By.XPath("//div[@role='dialog']//h2//div//div//div//button[@type='button']")).Click();

        }

        [Test]
        public void UploadCropAudio()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string filePath = HelperClass.GetPath("above2-30minaudio.mp3");
            driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(4) > input")).SendKeys(filePath);
            driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys(TestData.audioPostTitle);
            driver.FindElement(By.XPath("(//div[@class='icon_container']/button)[2]")).Click();
            var endMinute = driver.FindElement(By.XPath("(//input[@placeholder='00'])[3]"));
          
            var endMinuteValue = endMinute.GetAttribute("value");
            var endSecond = driver.FindElement(By.XPath("(//input[@placeholder='00'])[4]"));
            endSecond.Click();
            endSecond.SendKeys(Keys.Backspace);
            endSecond.SendKeys("29");

            var script = "arguments[0].scrollIntoView(true);";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script, endMinute);

            //driver.FindElement(By.XPath("//body/div[4]/div[3]/div[1]/div[1]/div[1]/div[2]/div[1]/div[3]/div[1]/div[1]/div[2]/div[2]/input[1]")).Clear();
            var endSecondValue = driver.FindElement(By.XPath("(//input[@placeholder='00'])[4]")).GetAttribute("value");
            Assert.That((endMinuteValue.Equals("02")) && (endSecondValue.Equals("29")));
            extent.test.Info("Validated default crop value for video post");
            // driver.FindElement(By.XPath("//div[@role='dialog']//h2//div//div//div//button[@type='button']")).Click();
            //IWebElement postBtn = HelperClass.WaitForElement((WebDriver)driver, "//body/div[4]/div[3]/div[1]/div[2]/div[1]/button[1]");
            //postBtn.Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => HelperClass.IsAlertShown((WebDriver)driver));
            var alert_win = driver.SwitchTo().Alert();
            alert_win.Accept();            
            //IWebElement audio = driver.FindElement(By.TagName("audio"));
            //var duration = audio.GetAttribute("duration");
            //Assert.That(duration, Is.EqualTo("137.4"));           
            extent.test.Info("after cropinng default value video posted on townhall");
            //! delete post
            TownhallPage townhallPage = new TownhallPage(driver, extent);
            string elementpath = "(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.audioPostTitle + "')]//ancestor::div[@id='townhall_post_container']//div[@id='post_header_container']//div[2]/button[@id='basic-button'])[1]";
            townhallPage.DeletePost(elementpath);
        }
    }
}
