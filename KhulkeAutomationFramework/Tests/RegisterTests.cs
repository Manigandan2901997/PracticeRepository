using AutomationFramework.Pages;
using AutomationFramework.HelperMethods;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace AutomationFramework.Tests
{
    public class RegisterTests : BaseTest
    {
        [Test]
        [Category("sanity")]
        public void RegisterWithValidMobTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            RegisterPage registerPage = new RegisterPage(Driver, extent);
            loginPage.OpenFromPage();
            Thread.Sleep(2000);
            registerPage.RegisterWithMobile(TestData.mobileNo[0]);
            var newUrl = driver.Url;
            Assert.That(newUrl.Equals("https://jitsi.konsultera.co.in/signup22"));
            extent.test.Info("Registration with valid mobile number");
        }

        [Test]
        public void RegisterWithInvalidMobTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            RegisterPage registerPage = new RegisterPage(Driver, extent);
            loginPage.OpenFromPage();
            Thread.Sleep(2000);
            registerPage.RegisterWithMobile(TestData.invalidMobileNo[0]);
            Thread.Sleep(2000);
            Assert.That(driver.FindElement(By.XPath("//small[contains(text(),'"+ AlertsData.allAlerts["MobileValidationAlert"] +"')]")).Displayed);
            extent.test.Info("Registration with invalid mobile number");
        }

        [Test]
        public void RegisterWithBlankMobTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            RegisterPage registerPage = new RegisterPage(Driver, extent);
            loginPage.OpenFromPage();
            Thread.Sleep(2000);
            registerPage.RegisterWithMobile(TestData.invalidMobileNo[5]);
            Thread.Sleep(2000);
            string messagetoVerify = "Please fill out this field.";
            string myValidationmsg = driver.FindElement(By.XPath("//input[@type='tel']")).GetAttribute("validationMessage");

            Assert.That(myValidationmsg, Is.EqualTo(messagetoVerify));
            extent.test.Info("Registration with blank mobile");

        }
        [Test]
        public void RegisterWithValidEmailTest()
        {

            LoginPage loginPage = new LoginPage(Driver, extent);
            RegisterPage registerPage = new RegisterPage(Driver, extent);
            loginPage.OpenFromPage();
            //! This is used to create email id to check otp
            driver.SwitchTo().NewWindow(WindowType.Tab);
            registerPage.OpenYopMailPage();
            var usernameTextbox = driver.FindElement(By.XPath("//input[@id='login']"));
            usernameTextbox.Clear();
            Random rd = new Random();
            int rand_num = rd.Next(100, 200);
            usernameTextbox.SendKeys("hithisismyemail_"+ rand_num);
            usernameTextbox.SendKeys(Keys.Enter);
            var emailid = driver.FindElement(By.XPath("//div[@class='bname']")).Text;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                          
            //! Enter Email to register
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            registerPage.RegisterWithEmail(emailid);
            Thread.Sleep(2000);
            //!Enter OTP to continue
            driver.SwitchTo().Window(driver.WindowHandles[1]);
           // driver.Navigate().GoToUrl(driver.Url);
            driver.FindElement(By.XPath("//button[@id='refresh']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='refresh']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='refresh']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='refresh']")).Click();
            Thread.Sleep(2000);           
            driver.SwitchTo().Frame("ifmail");
            var emailMsg = driver.FindElement(By.XPath("//div[@id='mail']/div[1]/div[3]")).Text;
            int From = emailMsg.IndexOf("OTP") + "OTP".Length;
            int To = emailMsg.LastIndexOf("to");
            string otpStr = emailMsg.Substring(From, To - From);
            string otp = otpStr.Trim();
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@id='first']")).SendKeys(otp.Substring(0, 1));
            driver.FindElement(By.XPath("//input[@id='second']")).SendKeys(otp.Substring(1, 1));
            driver.FindElement(By.XPath("//input[@id='third']")).SendKeys(otp.Substring(2, 1));
            driver.FindElement(By.XPath("//input[@id='fourth']")).SendKeys(otp.Substring(3, 1));
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[@type='submit']")).SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.That(driver.FindElement(By.XPath("//p[@class='pWelcome']")).Displayed);
            extent.test.Info("navigated to welcome page");

            //! update account setting
            driver.FindElement(By.XPath("//a[@href='/account_settings']")).Click();
            Assert.That(driver.Url.Equals("https://jitsi.konsultera.co.in/account_settings"));
            extent.test.Info("navigated to account setting from register welcome page");
            string userName = "Testuser" + rand_num;
            driver.FindElement(By.XPath("//input[@placeholder='Enter Username']")).SendKeys(userName);
            driver.FindElement(By.XPath("(//button[contains(text(),'Update')])[1]")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("//button[normalize-space()='YES']")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("//html")).Click();
            extent.test.Info(Environment.NewLine + $"Entered the name in the user name field with value => {userName}");
            driver.Navigate().Back();
            //driver.FindElement(By.XPath("//div[@alt='back button']")).Click();

            //! update personal details
            driver.FindElement(By.XPath("//a[@href='/personal_details']")).Click();
            Assert.That(driver.Url.Equals("https://jitsi.konsultera.co.in/personal_details"));
            extent.test.Info("navigated to personal details from register welcome page");
            driver.Navigate().Back();
            //driver.FindElement(By.XPath("//img[@alt='back button']")).Click();

            //! update create password
            driver.FindElement(By.XPath("//a[@href='/createpass']")).Click();
            Assert.That(driver.Url.Equals("https://jitsi.konsultera.co.in/createpass"));
            extent.test.Info("navigated to password set from register welcome page");
            driver.FindElement(By.XPath("(//input[@type='password'])[1]")).SendKeys("#TestDemo1234");
            driver.FindElement(By.XPath("(//input[@type='password'])[2]")).SendKeys("#TestDemo1234");
            driver.FindElement(By.XPath("//button[normalize-space()='UPDATE']")).SendKeys(Keys.Enter);
            extent.test.Info(Environment.NewLine + $"Entered the password  => {userName}");
            Assert.That(driver.FindElement(By.XPath("//small[contains(text(),'Password Set Succesfully.')]")).Displayed);
            driver.Navigate().Back();
            //driver.FindElement(By.XPath("//img[@alt='back button']")).Click();

            //! Create account Info
            //driver.FindElement(By.XPath("//input[@placeholder='Your Full Name']")).SendKeys("Anushka Sharma");           
            //driver.FindElement(By.XPath("//input[@placeholder='Create Username']")).SendKeys("anushkasharma");           
            //driver.FindElement(By.XPath("//input[@placeholder='Create Password']")).SendKeys("Anushka@123");            
            //driver.FindElement(By.XPath("//input[@placeholder='Re-type Password']")).SendKeys("Anushka@123");            
            //driver.FindElement(By.XPath("//button[contains(text(),'CONTINUE')]")).SendKeys(Keys.Enter);

            //Assert.That(driver.Url.Equals("https://jitsi.konsultera.co.in/home"));
            driver.FindElement(By.XPath("//button[normalize-space()='CONTINUE']")).SendKeys(Keys.Enter);
            Assert.That(driver.Url.Equals("https://jitsi.konsultera.co.in/home"));
            extent.test.Info("Register with valid email");

        }

        [Test]
        public void RegisterWithInvalidEmailWithoutAmpersandTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            RegisterPage registerPage = new RegisterPage(Driver, extent);
            loginPage.OpenFromPage();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/form[1]/div[3]/small[1]/a[1]")).Click();
            Thread.Sleep(2000);
            var invalidEmail = "ayz.com"; //!without @
            registerPage.RegisterWithEmail(invalidEmail);
            string messagetoVerify = "Please include an '@' in the email address. '"+ invalidEmail +"' is missing an '@'.";
            string myValidationmsg = driver.FindElement(By.XPath("//input[@type='email']")).GetAttribute("validationMessage");

            Assert.That(myValidationmsg,Is.EqualTo(messagetoVerify));
            extent.test.Info("Registration with invalid email without @");
        }

        [Test]
        public void RegisterWithInvalidEmailWithoutDotComTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            RegisterPage registerPage = new RegisterPage(Driver, extent);
            loginPage.OpenFromPage();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/form[1]/div[3]/small[1]/a[1]")).Click();
            Thread.Sleep(2000);
            var invalidEmail = "ayz@com"; //!without @
            registerPage.RegisterWithEmail(invalidEmail);
            string messagetoVerify = "invalid data";           
            Thread.Sleep(2000);
            Assert.That(driver.FindElement(By.XPath("//small[@class='erorPhonmail']")).Text, Is.EqualTo(messagetoVerify));
            extent.test.Info("Registration with invalid email without .com");
        }

        [Test]
        public void RegisterWithBlankEmailTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            RegisterPage registerPage = new RegisterPage(Driver, extent);
            loginPage.OpenFromPage();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/form[1]/div[3]/small[1]/a[1]")).Click();
            Thread.Sleep(2000);
            var invalidEmail = "ayz@com"; //!without @
            registerPage.RegisterWithEmail(invalidEmail);
            string messagetoVerify = "Please fill out this field.";
            string myValidationmsg = driver.FindElement(By.XPath("//input[@type='email']")).GetAttribute("validationMessage");

            Assert.That(myValidationmsg, Is.EqualTo(messagetoVerify));
            extent.test.Info("Registration with blank email");
            
        }


    }
}
