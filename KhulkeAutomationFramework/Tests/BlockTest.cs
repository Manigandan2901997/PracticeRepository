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
    public class BlockTest : BaseTest
    {
        [Test]
        public void BlockUser()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[5], TestData.password1);
            var currentULR = driver.Url;
            Assert.That(currentULR, Is.EqualTo("https://jitsi.konsultera.co.in/loginp"));
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            Assert.IsTrue(newPage.checkRoundTableLink);
            //block user from townhall
            driver.FindElement(By.XPath("//button[@id='basic-button']/div/img")).Click();
            driver.FindElement(By.CssSelector("li.MuiMenuItem-root:nth-child(3)")).Click();
            extent.test.Info("first user from timeline is blocked");
            Thread.Sleep(3000);
            IWebElement Linktext1 = driver.FindElement(By.LinkText("Notifications"));
            string linktxtmessage = Linktext1.Text;
            Assert.That(linktxtmessage, Is.EqualTo("Notifications"));
        }
        [Test]
        public void UnBlockUser()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[5], TestData.password1);
            var currentULR = driver.Url;
            Assert.That(currentULR, Is.EqualTo("https://jitsi.konsultera.co.in/loginp"));
            //Driver.Navigate().Refresh();
            Thread.Sleep(4000);
            Assert.IsTrue(newPage.checkRoundTableLink);
            //check if user is blocked or not
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[1]/div[2]/button[1]")).Click();
            driver.FindElement(By.CssSelector(".MuiMenuItem-root:nth-child(3)")).Click();
            driver.FindElement(By.LinkText("Blocked Accounts")).Click();
            driver.FindElement(By.CssSelector(".follow-button-small")).Click();
            extent.test.Info("user is unblocked");
            IWebElement messageId = driver.FindElement(By.XPath("//h3[contains(text(),'Settings')]"));
            string message = messageId.Text;
            Assert.That(message, Is.EqualTo("Settings"));
            Thread.Sleep(3000);
        }
        }
    }

