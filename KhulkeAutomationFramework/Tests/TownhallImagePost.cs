using AutomationFramework.Pages;
using AutomationFramework.HelperMethods;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Reflection;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationFramework.Tests
{
    internal class TownhallImagePost:BaseTest
    {
        [Test]
        [Category("sanity")]
        public void PostImageonTownhall()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string filePath = HelperClass.GetPath("PVS_2086.JPG");
            driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(2) > input")).SendKeys(filePath);
            // driver.FindElement(By.XPath("(//textarea[@placeholder='Write your content here...'])[2]")).Click();
            driver.FindElement(By.XPath("(//textarea[@placeholder='Write your content here...'])[2]")).SendKeys("Nature at its best !!");
            driver.FindElement(By.XPath("//button[normalize-space()='Post']")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => HelperClass.IsAlertShown((WebDriver)driver));
            var alert_win = driver.SwitchTo().Alert();
            alert_win.Accept();
            Assert.IsTrue(driver.FindElement(By.XPath("(//p[contains(text(),'Nature at its best !!')])[1]")).Displayed);
        }

        [Test]
        public void DiscardImagePost()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            // TownhallPage townhallPage = new TownhallPage(Driver, extent);
            //  townhallPage.DiscardPost("video");
            // driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(1) > img")).Click();
            string filePath = HelperClass.GetPath("PVS_2086.JPG");
            IWebElement imageFile = driver.FindElement(By.XPath("//input[@accept='image/*']"));
            imageFile.SendKeys(filePath);
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys("Image upload discard");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@role='dialog']//h2//div//div//div//button[@type='button']")).Click();
            Thread.Sleep(2000);
            Assert.That(!driver.FindElement(By.XPath("(//div[@id='townhall_post_body'])[1]/p")).Text.Equals("Image upload discard"));
            extent.test.Info("Image uploaded on townhall is discarded");
        }

        [Test]
        public void AlertUploadImageBigsize()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string filePath = HelperClass.GetPath("above15MbPhoto.JPG");           
            driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(3) > input")).SendKeys(filePath);
            // driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys(Keys.Enter);
            // driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys("Testing basics");
            //driver.FindElement(By.XPath("//button[normalize-space()='Post']")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => HelperClass.IsAlertShown((WebDriver)driver));
            var alert_win = driver.SwitchTo().Alert();
            Assert.That(alert_win.Text.Equals(AlertsData.allAlerts["ImageBigSizeALert"]));
            extent.test.Info("Above 15Mb Document posted on townhall shows alert");
            alert_win.Accept();
        }
        [Test]
        public void PreviewImgUpload()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[1], TestData.password);
            //Driver.Navigate().Refresh();
            string filePath = HelperClass.GetPath("PVS_2086.JPG");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/div[2]/div[1]/label[2]/input[1]")).SendKeys(filePath);
            driver.FindElement(By.CssSelector(".main_container > div:nth-child(1) > span:nth-child(2) > textarea:nth-child(1)")).SendKeys("Image preview Automation");
            driver.FindElement(By.CssSelector(".sc-bqyKOL")).SendKeys("Beutiful Nature");
            driver.FindElement(By.CssSelector("div.sc-hOqruk:nth-child(1) > button:nth-child(2)")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => HelperClass.IsAlertShown((WebDriver)driver));
            var alert_win4 = driver.SwitchTo().Alert();
            alert_win4.Accept();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/img[1]")).Click();
            driver.FindElement(By.CssSelector(".MuiDialogContent-root > div:nth-child(1) > button:nth-child(1)")).Click();
        }


    }
}
