using AutomationFramework.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using NUnit.Framework;

using System.Threading;

namespace AutomationFramework.Tests
{
    internal class MutedWordTest: BaseTest
    {
        [Test]
        [Category("sanity")]
        public void MuteWord()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[5], TestData.password1);
            var currentULR = driver.Url;
            Assert.That(currentULR, Is.EqualTo("https://jitsi.konsultera.co.in/loginp"));
            //Driver.Navigate().Refresh();
            Thread.Sleep(3000);
            Driver.FindElement(By.CssSelector(".MuiIconButton-label > img:nth-child(1)")).Click();
            Driver.FindElement(By.CssSelector(".MuiMenuItem-root:nth-child(3)")).Click();
            Driver.FindElement(By.LinkText("Muted Words")).Click();
            Driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/div[2]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".form-control-div > input:nth-child(1)")).Click();
            driver.FindElement(By.CssSelector(".form-control-div > input:nth-child(1)")).SendKeys("Bad");
            driver.FindElement(By.CssSelector(".btn")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/div[2]")).Click();
            driver.FindElement(By.CssSelector(".form-control-div > input:nth-child(1)")).Click();
            driver.FindElement(By.CssSelector(".form-control-div > input:nth-child(1)")).SendKeys("Abuse");
            driver.FindElement(By.Id("radio-option-2")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            Thread.Sleep(2000);
            IWebElement messageId = driver.FindElement(By.XPath("//h3[contains(text(),'Settings')]"));
            string message = messageId.Text;
            Assert.That(message, Is.EqualTo("Settings"));
        }
        [Test]
        [Category("sanity")]

        public void UnmuteWords()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[5], TestData.password1);
            var currentULR = driver.Url;
            Assert.That(currentULR, Is.EqualTo("https://jitsi.konsultera.co.in/loginp"));
            //Driver.Navigate().Refresh();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            Driver.FindElement(By.CssSelector(".MuiIconButton-label > img:nth-child(1)")).Click();
            Driver.FindElement(By.CssSelector(".MuiMenuItem-root:nth-child(3)")).Click();
            Driver.FindElement(By.LinkText("Muted Words")).Click();
            Driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[2]/button[1]")).Click();
            Thread.Sleep(2000);
            Driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[2]/button[1]")).Click();
            IWebElement messageId = driver.FindElement(By.XPath("//h3[contains(text(),'Settings')]"));
            string message = messageId.Text;
            Assert.That(message, Is.EqualTo("Settings"));
        }

    }
}
