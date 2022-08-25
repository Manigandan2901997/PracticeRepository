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
    public  class ChangePass : BaseTest
    {
        [Test]

        public void PasswordChangeTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[1], TestData.password);
            var currentULR = driver.Url;
            Assert.That(currentULR, Is.EqualTo("https://jitsi.konsultera.co.in/home"));
            //Driver.Navigate().Refresh();
            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("button.MuiButtonBase-root:nth-child(3)")).Click();
            driver.FindElement(By.CssSelector("li.MuiMenuItem-root:nth-child(3)")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Password")).Click();
            Thread.Sleep(2000);
            IWebElement currentpasstext = driver.FindElement(By.CssSelector("div.row:nth-child(1) > div:nth-child(1) > div:nth-child(2) > input:nth-child(1)"));
            currentpasstext.Click();
            currentpasstext.SendKeys("#TestDemo1234");
            Thread.Sleep(1000);
            IWebElement newpasstext = driver.FindElement(By.CssSelector("div.row:nth-child(3) > div:nth-child(1) > div:nth-child(2) > input:nth-child(1)"));
            newpasstext.Click();
            newpasstext.SendKeys("#TestDemo12345");
            Thread.Sleep(2000);
            IWebElement confpasstext = driver.FindElement(By.CssSelector("div.col-lg-6:nth-child(2) > div:nth-child(2) > input:nth-child(1)"));
            confpasstext.Click();
            confpasstext.SendKeys("#TestDemo12345");
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".btn")).Click();
            Thread.Sleep(2000);
            IWebElement errormessageID = driver.FindElement(By.CssSelector("#root > div > div.sc-kmATbt.bAMQjc > div > div.my-5.container-fluid > div:nth-child(3) > small.text-success"));
            string errormessage = errormessageID.Text;
            Assert.That(errormessage, Is.EqualTo("Password Changed Succesfully."));


        }
    }
}
