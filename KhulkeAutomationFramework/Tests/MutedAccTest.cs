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
    public class MutedAccTest : BaseTest
    {
        [Test]
        public void MuteUser()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[5], TestData.password1);
            var currentULR = driver.Url;
            Assert.That(currentULR, Is.EqualTo("https://jitsi.konsultera.co.in/loginp"));
            //Driver.Navigate().Refresh();
            Thread.Sleep(4000);
            driver.FindElement(By.Id("basic-button")).Click();
            driver.FindElement(By.CssSelector("li.MuiMenuItem-root:nth-child(5)")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("button.MuiButtonBase-root:nth-child(3)")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.CssSelector("li.MuiMenuItem-root:nth-child(5)")).Click();
            Thread.Sleep(2000);
            IWebElement errormessageID = driver.FindElement(By.XPath("//h2[contains(text(),'A platform where conversations matter.')]"));
            string errormessage = errormessageID.Text;
            Assert.That(errormessage, Is.EqualTo("A platform where conversations matter."));
        }

        [Test]

        public void CheckMuteUser() 
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[5], TestData.password1);
            var currentULR = driver.Url;
            Assert.That(currentULR, Is.EqualTo("https://jitsi.konsultera.co.in/loginp"));
            //Driver.Navigate().Refresh();
            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("button.MuiButtonBase-root:nth-child(3)")).Click();
            driver.FindElement(By.CssSelector("li.MuiMenuItem-root:nth-child(3)")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Muted Accounts")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".follow-button-small")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.CssSelector(".sc-bdfBQB")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("button.MuiButtonBase-root:nth-child(3)")).Click();
            driver.FindElement(By.CssSelector("li.MuiMenuItem-root:nth-child(5)")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement errormessageID = driver.FindElement(By.XPath("//h2[contains(text(),'A platform where conversations matter.')]"));
            string errormessage = errormessageID.Text;
            Assert.That(errormessage, Is.EqualTo("A platform where conversations matter."));

        }


    }
}
