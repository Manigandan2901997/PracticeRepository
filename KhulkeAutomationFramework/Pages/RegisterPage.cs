using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ReportingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace AutomationFramework.Pages
{
    internal class RegisterPage
    {
        public ExtentReportsHelper extentHelper;
        public IWebDriver Driver { get; set; }

        public RegisterPage(IWebDriver driver, ExtentReportsHelper extentReportHelper)
        {
            extentHelper = extentReportHelper;
            Driver = driver;
        }
        
        public IWebElement createNewAccBtn => Driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/form[1]/div[3]/small[1]/a[1]"));
        public IWebElement mobileTextBox => Driver.FindElement(By.XPath("//input[@type='tel']")); 
        public IWebElement emailTextBox => Driver.FindElement(By.XPath("//input[@type='email']")); 
        public IWebElement mobileLink => Driver.FindElement(By.XPath("//div[contains(text(),'Use phone instead')]"));
        public IWebElement emailLink => Driver.FindElement(By.XPath("//div[contains(text(),'Use email Id instead')]"));
        public IWebElement getOTPBtn => Driver.FindElement(By.XPath("//button[contains(@class,'loginBtn')]"));
        public IWebElement continueDiv => Driver.FindElement(By.XPath("//div[@class='buttonCont']"));
        public IWebElement continueBtn => Driver.FindElement(By.XPath("//div[@type='submit']"));
        public IWebElement verifyHeader => Driver.FindElement(By.XPath("//h1[contains(text(),'Verify')]"));
        public IWebElement mobileErrorMesage => Driver.FindElement(By.XPath("//small[contains(text(),'Please enter a valid no.')]"));
        public IWebElement emailErrorMesage => Driver.FindElement(By.XPath("//small[contains(text(),'Enter a valid Email Id.')]"));       

        public bool checkVerifyHeader => verifyHeader.Displayed;
        public bool checkMobileErrorMessage => mobileErrorMesage.Displayed;
        public bool checkEmailErrorMessage => emailErrorMesage.Displayed;

        public object SeleniumExtras { get; private set; }

        public void RegisterWithMobile(string mobileNo)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //IWebElement newAccBtn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/form[1]/div[3]/small[1]/a[1]")));
            //newAccBtn.Click(); 
            Thread.Sleep(1000);
            mobileLink.Click();
            mobileTextBox.Click();
            mobileTextBox.SendKeys(mobileNo);
            getOTPBtn.Click();
        }
        public void RegisterWithEmail(string email)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //IWebElement newAccBtn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/form[1]/div[3]/small[1]/a[1]")));
            //newAccBtn.Click();
            emailTextBox.SendKeys(email);
            getOTPBtn.Click();                      
        }
       

        public void OpenYopMailPage()
        {            
            string url = "https://yopmail.com/en/";
            Driver.Navigate().GoToUrl(url);
            extentHelper.test.Info($"Opened the url => {url}");
        }
        
       
    }
}
