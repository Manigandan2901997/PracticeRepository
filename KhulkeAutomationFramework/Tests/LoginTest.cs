using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFramework.Pages;
using NUnit;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Threading;
using AutomationFramework.HelperMethods;

namespace AutomationFramework.Tests
{
    internal class LoginTest : BaseTest
    {
        //!Login using username   
        [Test]
        public void PerformLoginTest()
        {

            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login("radhikayewale", "#TestDemo1234");
            //Driver.Navigate().Refresh();
            Thread.Sleep(8000);

            Assert.IsTrue(newPage.checkRoundTableLink);
          //  _test.Info("Login succesful");
            //newPage.NavigateToRoundTable();
            //Thread.Sleep(4000);
            //Assert.IsTrue(newPage.checkPastRoundTableTab);
            //newPage.NavigateToNotification();
        }
       
        [Test]
        public void ValidUnameInvalidPass()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[0], TestData.invalidPassword);
            Assert.That(Driver.FindElement(By.XPath("//small[contains(text(),'"+ AlertsData.allAlerts["InvalidPassword"] + "')]")).Displayed);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void InValidUnameValidPassTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[3], TestData.password);
            Assert.That(Driver.FindElement(By.XPath("//small[contains(text(),'" + AlertsData.allAlerts["InvalidUser"] + "')]")).Displayed);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void InValidUnameInvalidPassTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[2], TestData.invalidPassword);  
            Assert.That(Driver.FindElement(By.XPath("//small[contains(text(),'" + AlertsData.allAlerts["InvalidUser"] + "')]")).Displayed);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //_test.Log(AventStack.ExtentReports.Status.Pass);

        }

        //!Login using mobile   
        [Test]
        public void PerformLoginMobileTest()
        {

            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login("8805071357", "#TestDemo1234");
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            Assert.IsTrue(newPage.checkRoundTableLink);
            //  _test.Info("Login succesful");
           
        }

        [Test]
        public void ValidMobileInvalidPassTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userMobile[0], TestData.invalidPassword);
            IWebElement ErrormessageId = Driver.FindElement(By.XPath("//small[@class='alert-text errorLine']"));
            string errorMessage = ErrormessageId.Text;
            //Assert.AreEqual("Username / Password entered is incorrect!", errorMessage);
            Assert.That(Driver.FindElement(By.XPath("//small[contains(text(),'" + AlertsData.allAlerts["InvalidPassword"] + "')]")).Displayed);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void InValidMobileValidPassTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userMobile[1], TestData.password);           
            Assert.That(Driver.FindElement(By.XPath("//small[contains(text(),'" + AlertsData.allAlerts["InvalidUser"] + "')]")).Displayed);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void InValidMobileInvalidPassTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userMobile[1], TestData.invalidPassword);
            //Assert.AreEqual("Username / Password entered is incorrect!", errorMessage);
            Assert.That(Driver.FindElement(By.XPath("//small[contains(text(),'" + AlertsData.allAlerts["InvalidUser"] + "')]")).Displayed);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //_test.Log(AventStack.ExtentReports.Status.Pass);

        }
        //!Login using email   
        [Test]
        public void PerformLoginEmailTest()
        {

            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login("rashika_09g@yahoo.co.in", "#TestDemo1234");
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            Assert.IsTrue(newPage.checkRoundTableLink);
            //  _test.Info("Login succesful");
          
        }

        [Test]
        public void ValidEmailInvalidPassTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userEmail[0], TestData.invalidPassword);
            Assert.That(Driver.FindElement(By.XPath("//small[contains(text(),'" + AlertsData.allAlerts["InvalidPassword"] + "')]")).Displayed);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void InValidEmailValidPassTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userEmail[1], TestData.password);
            Assert.That(Driver.FindElement(By.XPath("//small[contains(text(),'" + AlertsData.allAlerts["InvalidUser"] + "')]")).Displayed);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void InValidEmailInvalidPassTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userEmail[1], TestData.invalidPassword);
            Assert.That(Driver.FindElement(By.XPath("//small[contains(text(),'" + AlertsData.allAlerts["InvalidUser"] + "')]")).Displayed);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //_test.Log(AventStack.ExtentReports.Status.Pass);

        }


    }
}
