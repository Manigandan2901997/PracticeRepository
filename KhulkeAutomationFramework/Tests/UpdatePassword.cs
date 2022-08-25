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
    internal class UpdatePassword:BaseTest
    {
        [Test]
        public void UpdatePasswordWithEmail()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            driver.FindElement(By.XPath("//a[contains(text(),'Forgot Password?')]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.XPath("//input[@placeholder='Email / Mobile']")).SendKeys(TestData.emailIds[0]);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[contains(text(),'CONTINUE')]")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            Assert.That(driver.Url.Equals("https://jitsi.konsultera.co.in/verify_fp"));
            RegisterPage registerPage = new RegisterPage(Driver, extent);
            //! This is used to create email id to check otp
            driver.SwitchTo().NewWindow(WindowType.Tab);
            registerPage.OpenYopMailPage();
            var usernameTextbox = driver.FindElement(By.XPath("//input[@id='login']"));
            usernameTextbox.Clear();
            usernameTextbox.SendKeys("hithisis");
            usernameTextbox.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='refresh']")).Click();
            driver.FindElement(By.XPath("//button[@id='refresh']")).Click();
            Thread.Sleep(2000);
            driver.SwitchTo().Frame("ifmail");
            var emailMsg = driver.FindElement(By.XPath("//div[@id='mail']/div[1]/div[1]")).Text;
            int From = emailMsg.IndexOf("OTP :") + "OTP :".Length;
            string otpStr = emailMsg.Substring(From, 5);
            string otp = otpStr.Trim();
            Thread.Sleep(2000);
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@id='first']")).SendKeys(otp.Substring(0, 1));
            driver.FindElement(By.XPath("//input[@id='second']")).SendKeys(otp.Substring(1, 1));
            driver.FindElement(By.XPath("//input[@id='third']")).SendKeys(otp.Substring(2, 1));
            driver.FindElement(By.XPath("//input[@id='fourth']")).SendKeys(otp.Substring(3, 1));
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[contains(text(),'CONTINUE')]")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            Assert.That(driver.FindElement(By.XPath("//h1[contains(text(),'Reset your password')]")).Displayed);
            driver.FindElement(By.XPath("//input[@placeholder='Enter New Password']")).SendKeys("#TestDemo123");
            driver.FindElement(By.XPath("//input[@placeholder='Retype your password.']")).SendKeys("#TestDemo123");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[contains(text(),'CONTINUE')]")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            Assert.That(driver.Url.Equals("https://jitsi.konsultera.co.in/verify_fp"));
            extent.test.Info("password updated with email id");
        }
        [Test]
        public void UpdatePasswordWithInvalidEmail()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            driver.FindElement(By.XPath("//a[contains(text(),'Forgot Password?')]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.XPath("//input[@placeholder='Email / Mobile']")).SendKeys(TestData.invalidEmailIds[3]);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[contains(text(),'CONTINUE')]")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            Assert.That(driver.FindElement(By.XPath("//small[contains(text(),'Email/Phone number was invalid!')]")).Displayed);
            extent.test.Info("password not updated with invalid email");
        }
        [Test]
        public void UpdatePasswordWithMobile()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            driver.FindElement(By.XPath("//a[contains(text(),'Forgot Password?')]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.XPath("//input[@placeholder='Email / Mobile']")).SendKeys(TestData.mobileNo[0]);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[contains(text(),'CONTINUE')]")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            Assert.That(driver.FindElement(By.XPath("//small[contains(text(),'Email/Phone number was invalid!')]")).Displayed);
            extent.test.Info("Password updated with mobile number");
        }
        [Test]
        public void UpdatePasswordWithInvalidMobile()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            driver.FindElement(By.XPath("//a[contains(text(),'Forgot Password?')]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.XPath("//input[@placeholder='Email / Mobile']")).SendKeys(TestData.invalidMobileNo[3]);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[contains(text(),'CONTINUE')]")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            Assert.That(driver.FindElement(By.XPath("//small[contains(text(),'Email/Phone number was invalid!')]")).Displayed);
            extent.test.Info("Password not updated with invalid mobile no.");
        }
    }
}
