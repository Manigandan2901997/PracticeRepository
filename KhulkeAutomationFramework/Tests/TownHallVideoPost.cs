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
    internal class TownHallVideoPost:BaseTest
    {
        [Test, Order(1)]
        [Category("sanity")]
        public void PostVideoOnTownhallTest()
        {

            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);            
            string filePath = HelperClass.GetPath("testingvideo.mp4");
            driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(1) > input")).SendKeys(filePath);          
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys(TestData.videoPostTitle);
            driver.FindElement(By.CssSelector(".sc-kIeSZW:nth-child(1) > .MuiButton-root")).Click();
            var alert_win = driver.SwitchTo().Alert();
            alert_win.Accept();
            Assert.That(driver.FindElement(By.XPath("((//button[@type='button'])//*[name()='svg'])[1]")).GetAttribute("class").Equals("icon icon_color"));
            extent.test.Info("video posted on townhall");

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
            string elementpath = "(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.videoPostTitle + "')]//ancestor::div[@id='townhall_post_container']//div[@id='post_header_container']//div[2]/button[@id='basic-button'])[1]";
            townhallPage.DeletePost(elementpath);
            //IWebElement saveBtn = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']//div[@id='post_header_container']//div[2]/button[@id='basic-button'])[1]"));
            //saveBtn.SendKeys(Keys.Enter);
            //driver.FindElement(By.XPath("//li[normalize-space()='Delete']")).Click();
            //Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("Successfully Deleted"));
            extent.test.Info("post deleted");
        }
        [Test]
        [Category("sanity")]
        public void PreviewVidUploadTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[1], TestData.password);
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            string filePath = HelperClass.GetPath("testingvideo.mp4");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/div[2]/div[1]/label[1]/input[1]")).SendKeys(filePath);
            driver.FindElement(By.CssSelector(".main_container > div:nth-child(1) > span:nth-child(2) > textarea:nth-child(1)")).SendKeys(TestData.videoPostTitle);
            driver.FindElement(By.XPath("//video[@id='my_video_player']")).Click();
            Thread.Sleep(10000);
            driver.FindElement(By.XPath("//video[@id='my_video_player']")).Click();
            driver.FindElement(By.CssSelector("div.sc-hOqruk:nth-child(1) > button:nth-child(2)")).Click();
            Thread.Sleep(30000);
            var alert_win4 = driver.SwitchTo().Alert();
            alert_win4.Accept();
            Thread.Sleep(2000);
            TownhallPage townhallPage = new TownhallPage(driver, extent);
            string elementpath = "(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.videoPostTitle + "')]//ancestor::div[@id='townhall_post_container']//div[@id='post_header_container']//div[2]/button[@id='basic-button'])[1]";
            townhallPage.DeletePost(elementpath);
            //IWebElement saveBtn = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']//div[@id='post_header_container']//div[2]/button[@id='basic-button'])[1]"));
            //saveBtn.SendKeys(Keys.Enter);
            //driver.FindElement(By.XPath("//li[normalize-space()='Delete']")).Click();
            //Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("Successfully Deleted"));
            extent.test.Info("preview post deleted");
        }
        

        [Test]
        public void DiscardVideoPost()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            string filePath = HelperClass.GetPath("testingvideo.mp4");
            IWebElement videoFile = driver.FindElement(By.XPath("//input[@accept='video/*']"));
            videoFile.SendKeys(filePath);
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys("Video upload discard");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@role='dialog']//h2//div//div//div//button[@type='button']")).Click();
            Thread.Sleep(2000);
            Assert.That(!driver.FindElement(By.XPath("(//div[@id='townhall_post_body'])[1]/p")).Text.Equals("Video upload discard"));
            extent.test.Info("video uploaded on townhall is discarded");
        }

        [Test]
        public void AlertUploadBigVideoTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);          
            string filePath = HelperClass.GetPath("testingvideo3min.mp4");
            driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(1) > input")).SendKeys(filePath);
            driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys("Video upload of 3min");

            driver.FindElement(By.XPath("//button[normalize-space()='Post']")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => HelperClass.IsAlertShown((WebDriver)driver));
            var alert_win = driver.SwitchTo().Alert();
            Assert.That(alert_win.Text, Is.EqualTo(AlertsData.allAlerts["VideoTimeLimitAlert"]));
            alert_win.Accept();
            extent.test.Info("3min video posted on townhall shows alert");
        }

        [Test]
        public void CropVideoValidationTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);          
            string filePath = HelperClass.GetPath("testingvideo3min.mp4");
            driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(1) > input")).SendKeys(filePath);
            driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys("Crop Video upload");
            driver.FindElement(By.XPath("(//div[@class='icon_container']/button)[2]")).Click();
            var endMinute = driver.FindElement(By.XPath("(//input[@placeholder='00'])[3]"));
            var script = "arguments[0].scrollIntoView(true);";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script, endMinute);
            var endMinuteValue = endMinute.GetAttribute("value");
            // driver.FindElement(By.XPath("//body/div[4]/div[3]/div[1]/div[1]/div[1]/div[2]/div[1]/div[3]/div[1]/div[1]/div[2]/div[2]/input[1]")).Clear();
            var endSecondValue = driver.FindElement(By.XPath("(//input[@placeholder='00'])[4]")).GetAttribute("value");
            Assert.That((endMinuteValue.Equals("02")) && (endSecondValue.Equals("30")));
            extent.test.Info("Validated default crop value for video post");
            driver.FindElement(By.XPath("//div[@role='dialog']//h2//div//div//div//button[@type='button']")).Click();


        }
       
        [Test]
        public void AlertUploadVideoBigsizeTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);            
            string filePath = HelperClass.GetPath("above250mbVideo.mp4");
            driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(2) > input")).SendKeys(filePath);
            // driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys(Keys.Enter);
            // driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys("Testing basics");
            //driver.FindElement(By.XPath("//button[normalize-space()='Post']")).Click();           
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => HelperClass.IsAlertShown((WebDriver)driver));
            var alert_win = driver.SwitchTo().Alert();
            Assert.That(alert_win.Text.Equals(AlertsData.allAlerts["VideoBigSizeALert"]));
            extent.test.Info("Above 250Mb video posted on townhall shows alert");
            alert_win.Accept();
        }

        [Test,Order(3)]
        public void UploadCropVideoTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string filePath = HelperClass.GetPath("testingvideo3min.mp4");
            driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(1) > input")).SendKeys(filePath);
            driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys(TestData.videoPostTitle);
            driver.FindElement(By.XPath("(//div[@class='icon_container']/button)[2]")).Click();
            var endMinute = driver.FindElement(By.XPath("(//input[@placeholder='00'])[3]"));
            var script = "arguments[0].scrollIntoView(true);";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script, endMinute);
            var endMinuteValue = endMinute.GetAttribute("value");
            // driver.FindElement(By.XPath("//body/div[4]/div[3]/div[1]/div[1]/div[1]/div[2]/div[1]/div[3]/div[1]/div[1]/div[2]/div[2]/input[1]")).Clear();
            var endSecondValue = driver.FindElement(By.XPath("(//input[@placeholder='00'])[4]")).GetAttribute("value");
            Assert.That((endMinuteValue.Equals("02")) && (endSecondValue.Equals("30")));
            extent.test.Info("Validated default crop value for video post");
            // driver.FindElement(By.XPath("//div[@role='dialog']//h2//div//div//div//button[@type='button']")).Click();
            driver.FindElement(By.XPath("//button[normalize-space()='Post']")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => HelperClass.IsAlertShown((WebDriver)driver));
            var alert_win = driver.SwitchTo().Alert();
            alert_win.Accept();
            extent.test.Info("after cropinng default value video posted on townhall");
            TownhallPage townhallPage = new TownhallPage(driver, extent);
            string elementpath = "(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.videoPostTitle + "')]//ancestor::div[@id='townhall_post_container']//div[@id='post_header_container']//div[2]/button[@id='basic-button'])[1]";
            townhallPage.DeletePost(elementpath);
            //IWebElement saveBtn = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']//div[@id='post_header_container']//div[2]/button[@id='basic-button'])[1]"));
            //saveBtn.SendKeys(Keys.Enter);
            //driver.FindElement(By.XPath("//li[normalize-space()='Delete']")).Click();
            //Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("Successfully Deleted"));
            extent.test.Info("crop post deleted");
        }

        [Test,Order(4)]
        public void VideoPlayspeedTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            string filePath = HelperClass.GetPath("testingvideo.mp4");
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/div[2]/div[1]/label[1]/input[1]")).SendKeys(filePath);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//video[@id='my_video_player']")).Click();

        }
        [Test, Order(5)]
        public void PlaybackspeedTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            string filePath = HelperClass.GetPath("testingvideo.mp4");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/div[2]/div[1]/label[1]/input[1]")).SendKeys(filePath);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById(\"my_video_player\").playbackRate+=1.75");
            //js.ExecuteScript("document.getElementById(\"my_video_player\").play()");
            Thread.Sleep(10000);
            driver.FindElement(By.CssSelector(".main_container > div:nth-child(1) > span:nth-child(2) > textarea:nth-child(1)")).SendKeys("Video automation Test");
            driver.FindElement(By.XPath("//video[@id='my_video_player']")).Click();
            Thread.Sleep(10000);
            driver.FindElement(By.XPath("//video[@id='my_video_player']")).Click();
            driver.FindElement(By.CssSelector("div.sc-hOqruk:nth-child(1) > button:nth-child(2)")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => HelperClass.IsAlertShown((WebDriver)driver));
            var alert_win4 = driver.SwitchTo().Alert();
            alert_win4.Accept();
            Thread.Sleep(2000);
        }

        [Test, Order(6)]
        public void VidVolupdownTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            string filePath = HelperClass.GetPath("testingvideo.mp4");
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/div[2]/div[1]/label[1]/input[1]")).SendKeys(filePath);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById(\"my_video_player\").muted=true");
            //js.ExecuteScript("document.getElementById(\"my_video_player\").play()");


            driver.FindElement(By.CssSelector(".main_container > div:nth-child(1) > span:nth-child(2) > textarea:nth-child(1)")).SendKeys("Video automation Test");
            driver.FindElement(By.XPath("//video[@id='my_video_player']")).Click();
            Thread.Sleep(10000);
            driver.FindElement(By.XPath("//video[@id='my_video_player']")).Click();
            //driver.FindElement(By.CssSelector("div.sc-hOqruk:nth-child(1) > button:nth-child(2)")).Click();
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            //wait.Until(driver => HelperClass.IsAlertShown((WebDriver)driver));
            //var alert_win4 = driver.SwitchTo().Alert();
            //alert_win4.Accept();
            //Thread.Sleep(2000);
        }

        [Test]
        public void VerifyOnlyMP4Test()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            string filePath = HelperClass.GetPath("PVS_2086.JPG");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/div[2]/div[1]/label[1]/input[1]")).SendKeys(filePath);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => HelperClass.IsAlertShown((WebDriver)driver));
            var alert_win3 = driver.SwitchTo().Alert();
            alert_win3.Accept();
            Thread.Sleep(2000);
        }
        [Test, Order(3)]
        public void AddAndDeleteVideoBeforeUploadTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string filePath = HelperClass.GetPath("testingvideo3min.mp4");
            driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(1) > input")).SendKeys(filePath);
            driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys(TestData.videoPostTitle);
            driver.FindElement(By.XPath("(//div[@class='icon_container']/button)[3]")).Click();
          
            //video[@id='my_video_player']
           // Assert.That(driver.FindElement(By.XPath("//div[@role='dialog']//div//div[2]")).));
            driver.FindElement(By.XPath("//div[@role='dialog']//h2//div//div//div//button[@type='button']")).Click();
            extent.test.Info("Video added and then deleted using delete button");
        }
    }
}
