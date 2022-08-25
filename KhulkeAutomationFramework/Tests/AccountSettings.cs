using AutomationFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace AutomationFramework.Tests
{
    internal class AccountSettings:BaseTest
    {
        [Test, Order(1)]
        [Category("sanity")]
        //Update email from account settings->account
        public void UpdateEmail()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            extent.test.Info("Login succesful");
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);

            driver.FindElement(By.CssSelector(".MuiIconButton-label > .sc-iwyWTf")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//li[2]")).Click();

            driver.SwitchTo().NewWindow(WindowType.Tab);
            //Random rnd = new Random();
            //int num = rnd.Next(100);
            //var emailName = "Thisismymail" + num;
            //var emailName = "Thisismymail";
            RegisterPage registerPage = new RegisterPage(Driver, extent);
            registerPage.OpenYopMailPage();
            var usernameTextbox = driver.FindElement(By.XPath("//input[@id='login']"));
            usernameTextbox.Clear();
            usernameTextbox.SendKeys(TestData.updateEmailIds[1]);
            usernameTextbox.SendKeys(Keys.Enter);
            var emailid = driver.FindElement(By.XPath("//div[@class='bname']")).Text;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //! Enter Email to register
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@placeholder='Enter Email Address']")).Clear();
            driver.FindElement(By.XPath("//input[@placeholder='Enter Email Address']")).SendKeys(emailid);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("(//button[contains(text(),'Update')])[2]")).Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.FindElement(By.XPath("//button[@id='refresh']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='refresh']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='refresh']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='refresh']")).Click();
            Thread.Sleep(2000);
            driver.SwitchTo().Frame("ifmail");
            var emailMsg = driver.FindElement(By.XPath("//div[@id='mail']/div[1]/div[1]")).Text;
            int From = emailMsg.IndexOf("OTP :") + "OTP :".Length;
            string otpStr = emailMsg.Substring(From, 5);
            string otp = otpStr.Trim();
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@id='first']")).SendKeys(otp.Substring(0, 1));
            driver.FindElement(By.XPath("//input[@id='second']")).SendKeys(otp.Substring(1, 1));
            driver.FindElement(By.XPath("//input[@id='third']")).SendKeys(otp.Substring(2, 1));
            driver.FindElement(By.XPath("//input[@id='fourth']")).SendKeys(otp.Substring(3, 1));
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[contains(text(),'SUBMIT')]")).SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(1000);
            Assert.That(driver.FindElement(By.XPath("//input[@placeholder='Enter Email Address']")).GetAttribute("value").Equals(emailid));

        }
        [Test, Order(2)]
        public void UpdateEmailToOrigin()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            extent.test.Info("Login succesful");
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);

            driver.FindElement(By.CssSelector(".MuiIconButton-label > .sc-iwyWTf")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//li[2]")).Click();

            driver.SwitchTo().NewWindow(WindowType.Tab);
            //Random rnd = new Random();
            //int num = rnd.Next(100);
            //var emailName = "Thisismymail" + num;
            //var emailName = "Thisismymail";
            RegisterPage registerPage = new RegisterPage(Driver, extent);
            registerPage.OpenYopMailPage();
            var usernameTextbox = driver.FindElement(By.XPath("//input[@id='login']"));
            usernameTextbox.Clear();
            usernameTextbox.SendKeys(TestData.updateEmailIds[0]);
            usernameTextbox.SendKeys(Keys.Enter);
            var emailid = driver.FindElement(By.XPath("//div[@class='bname']")).Text;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //! Enter Email to register
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@placeholder='Enter Email Address']")).Clear();
            driver.FindElement(By.XPath("//input[@placeholder='Enter Email Address']")).SendKeys(emailid);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("(//button[contains(text(),'Update')])[2]")).Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.FindElement(By.XPath("//button[@id='refresh']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='refresh']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='refresh']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='refresh']")).Click();
            Thread.Sleep(2000);
            driver.SwitchTo().Frame("ifmail");
            var emailMsg = driver.FindElement(By.XPath("//div[@id='mail']/div[1]/div[1]")).Text;
            int From = emailMsg.IndexOf("OTP :") + "OTP :".Length;
            string otpStr = emailMsg.Substring(From, 5);
            string otp = otpStr.Trim();
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@id='first']")).SendKeys(otp.Substring(0, 1));
            driver.FindElement(By.XPath("//input[@id='second']")).SendKeys(otp.Substring(1, 1));
            driver.FindElement(By.XPath("//input[@id='third']")).SendKeys(otp.Substring(2, 1));
            driver.FindElement(By.XPath("//input[@id='fourth']")).SendKeys(otp.Substring(3, 1));
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[contains(text(),'SUBMIT')]")).SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(1000);
            Assert.That(driver.FindElement(By.XPath("//input[@placeholder='Enter Email Address']")).GetAttribute("value").Equals(emailid));

        }

        [Test, Order(3)]
        [Category("sanity")]
        //! Update password from account settings->password
        public void UpdatePassword()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            extent.test.Info("Login succesful");
            var newPage = loginPage.Login(TestData.userNames[4], "#TestDemo1234");

            driver.FindElement(By.CssSelector(".MuiIconButton-label > .sc-iwyWTf")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//li[2]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//a[contains(text(),'Password')]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@placeholder='Enter Current Password']")).SendKeys("#TestDemo1234");
            driver.FindElement(By.XPath("//input[@placeholder='Enter New Password']")).SendKeys("#ChangeTestDemo1234");
            driver.FindElement(By.XPath("//input[@placeholder='Confirm New Password']")).SendKeys("#ChangeTestDemo1234");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[@class='btn primary-btn-blk']")).SendKeys(Keys.Enter);

            Thread.Sleep(1000);
            Assert.That(driver.FindElement(By.XPath("//small[@class='text-success']")).Text.Equals("Password Changed Succesfully."));

        }
        [Test, Order(4)]
        [Category("sanity")]
        //! Update password from account settings->password
        public void UpdatePasswordToOrigin()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            extent.test.Info("Login succesful");
            var newPage = loginPage.Login(TestData.userNames[4], "#ChangeTestDemo1234");

            driver.FindElement(By.CssSelector(".MuiIconButton-label > .sc-iwyWTf")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//li[2]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//a[contains(text(),'Password')]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@placeholder='Enter Current Password']")).SendKeys("#ChangeTestDemo1234");
            driver.FindElement(By.XPath("//input[@placeholder='Enter New Password']")).SendKeys("#TestDemo1234");
            driver.FindElement(By.XPath("//input[@placeholder='Confirm New Password']")).SendKeys("#TestDemo1234");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[@class='btn primary-btn-blk']")).SendKeys(Keys.Enter);

            Thread.Sleep(1000);
            Assert.That(driver.FindElement(By.XPath("//small[@class='text-success']")).Text.Equals("Password Changed Succesfully."));

        }

    }
}
