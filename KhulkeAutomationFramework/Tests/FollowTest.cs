using AutomationFramework.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;

namespace AutomationFramework.Tests
{
    internal class FollowTest: BaseTest
    {
        [Test,Order(1)]
        [Category("sanity")]
        public void FollowUser()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[5], TestData.password1);
            var currentULR = driver.Url;
            Assert.That(currentULR, Is.EqualTo("https://jitsi.konsultera.co.in/loginp"));
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            //search user testKhulke
            Driver.FindElement(By.XPath("//input[@placeholder='Search']")).Click();
            Driver.FindElement(By.XPath("//input[@placeholder='Search']")).SendKeys("testKhulke");
            Driver.FindElement(By.XPath("//input[@placeholder='Search']")).SendKeys(Keys.Enter);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //Follow searched user
            Driver.FindElement(By.CssSelector(".follow-button")).Click();
            Thread.Sleep(1000);
            extent.test.Info("Test khulke is followed");
            //go back to townhall
            driver.FindElement(By.XPath("//*[@class='sc-fubCzh fLnZpM nav_title undefined']")).Click();
            //again search user to check following status
            driver.FindElement(By.XPath("//input[@placeholder='Search']")).Click();
            driver.FindElement(By.XPath("//input[@placeholder='Search']")).SendKeys("testKhulke");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@placeholder='Search']")).SendKeys(Keys.Enter);
            extent.test.Info("Test Khulke is followed - Verified");
            //click on menubutton
            Driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[1]/div[1]/div[2]/button[1]/span[1]/img[1]")).Click();
            //click on logout
            Driver.FindElement(By.CssSelector(".MuiMenuItem-root:nth-child(5)")).Click();
            Thread.Sleep(3000);
            IWebElement errormessageID = driver.FindElement(By.XPath("//h2[contains(text(),'A platform where conversations matter.')]"));
            string errormessage = errormessageID.Text;
            Assert.That(errormessage, Is.EqualTo("A platform where conversations matter."));
        }
        [Test, Order(2)]
        [Category("sanity")]
        public void CheckFollow()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[5], TestData.password1);
            var currentULR = driver.Url;
            Assert.That(currentULR, Is.EqualTo("https://jitsi.konsultera.co.in/loginp"));
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            Driver.FindElement(By.LinkText("Notifications")).Click();
            //Driver.FindElement(By.CssSelector("#optInText")).Click();
            //Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//button[contains(.,'Network')]")).Click();
            extent.test.Info("Notifications are verified");
            IWebElement Linktext1 = driver.FindElement(By.LinkText("Notifications"));
            string linktxtmessage = Linktext1.Text;
            Assert.That(linktxtmessage, Is.EqualTo("Notifications"));
        }

        [Test, Order(3)]
        [Category("sanity")]
        public void UnFollowUser()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[5], TestData.password1);
            var currentULR = driver.Url;
            Assert.That(currentULR, Is.EqualTo("https://jitsi.konsultera.co.in/loginp"));
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            //search user testKhulke
            Driver.FindElement(By.XPath("//input[@placeholder='Search']")).Click();
            Driver.FindElement(By.XPath("//input[@placeholder='Search']")).SendKeys("testkhulke");
            Driver.FindElement(By.XPath("//input[@placeholder='Search']")).SendKeys(Keys.Enter);
            // unfollow user
            Driver.FindElement(By.CssSelector(".following-button")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            extent.test.Info("test Khulke is unfollowed - Verified");
            //click on menubutton
            Driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[1]/div[1]/div[2]/button[1]/span[1]/img[1]")).Click();
            //click on logout
            Driver.FindElement(By.CssSelector(".MuiMenuItem-root:nth-child(5)")).Click();
            IWebElement errormessageID = driver.FindElement(By.XPath("//h2[contains(text(),'A platform where conversations matter.')]"));
            string errormessage = errormessageID.Text;
            Assert.That(errormessage, Is.EqualTo("A platform where conversations matter."));
        }


    }
}
