using AventStack.ExtentReports;
using NLog;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using ReportingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationFramework.Pages
{
    internal class LoginPage
    {
        ExtentReportsHelper extentHelper;
        IWebDriver Driver;    
        
        public LoginPage(IWebDriver driver, ExtentReportsHelper extentReportHelper)
        {
            Driver = driver;
            extentHelper = extentReportHelper;
        }

        public IWebElement usernameTextBox => Driver.FindElement(By.Id("fname"));
        public IWebElement passwordradio => Driver.FindElement(By.Id("password"));
        //public IWebElement OTPradio => Driver.FindElement(By.Id("otp"));
        public IWebElement contbtn => Driver.FindElement(By.CssSelector(".loginBtn"));
        public IWebElement passwordTextBox => Driver.FindElement(By.XPath("//input[@type='password']"));
        public IWebElement BtnSubmit => Driver.FindElement(By.CssSelector(".btn"));
        public IWebElement menu => Driver.FindElement(By.CssSelector(".MuiIconButton-label > .sc-iwyWTf"));       
        public IWebElement logout => Driver.FindElement(By.XPath("//li[normalize-space()='Logout']"));
        public bool VerifyTitle
        {
            get
            {
                return Driver.Title.Contains("Khul Ke");
            }

            set { }
        }

        public void OpenFromPage()
        {
            //string url = "https://khulke.com/login";
            string url = "https://jitsi.konsultera.co.in/login";
            Driver.Navigate().GoToUrl(url);
           extentHelper.test.Info($"Opened the url => {url}");
        }

        public void OpenFromPage1()
        {
            string url = "https://qaweb.khulke.com/login";

            Driver.Navigate().GoToUrl(url);
            extentHelper.test.Info($"Opened the url => {url}");
        }

        public void Logout()
        {            
            menu.Click();
            logout.Click();
        }

        public HomePage Login(string username, string password)
        {
            extentHelper.test.Info("Login test started");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            usernameTextBox.SendKeys(username);
            extentHelper.test.Info(Environment.NewLine + $"Entered the name in the user name field with value => {username}");
            passwordradio.Click();
            contbtn.Click();
            Thread.Sleep(1000);
            string newUrl = Driver.Url;
            if(newUrl == "https://jitsi.konsultera.co.in/loginp")
            {
                passwordTextBox.SendKeys(password);
                extentHelper.test.Info(Environment.NewLine + $"Entered the password value => {password}");
                BtnSubmit.Click();
            }            
            extentHelper.test.Info(Environment.NewLine + $"Login completed");
            return new HomePage(Driver,extentHelper);
        }

       

    }
}
