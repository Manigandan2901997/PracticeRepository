using OpenQA.Selenium;
using ReportingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhulkeAutomationFramework.Pages
{
    public class AccountSettingsPage
    {

        ExtentReportsHelper extentHelper;
        IWebDriver Driver;


        public AccountSettingsPage(IWebDriver driver, ExtentReportsHelper extentReportHelper)
        {
            Driver = driver;
            extentHelper = extentReportHelper;
        }

        public IWebElement UserButton => Driver.FindElement(By.CssSelector(".MuiIconButton-label > .sc-iwyWTf"));
        public IWebElement Profile => Driver.FindElement(By.CssSelector(".MuiMenuItem-root:nth-child(1)"));
        public IWebElement Editprof => Driver.FindElement(By.XPath("//button[contains(.,'Edit Profile')]"));
        public IWebElement Bio => Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[1]/div/textarea"));
        public IWebElement Accountsetting => Driver.FindElement(By.CssSelector(".MuiMenuItem-root:nth-child(3)"));
        public IWebElement InviteFriends => Driver.FindElement(By.LinkText("Invite Friends"));
        public IWebElement Privacy => Driver.FindElement(By.LinkText("Privacy"));
        public IWebElement Password => Driver.FindElement(By.LinkText("Password"));

        public IWebElement MutedWords => Driver.FindElement(By.LinkText("Muted Words"));

        public IWebElement MutedAccounts => Driver.FindElement(By.LinkText("Muted Accounts"));
        public IWebElement BlockedAccounts => Driver.FindElement(By.LinkText("Blocked Accounts"));
        public IWebElement FAQ => Driver.FindElement(By.LinkText("FAQ"));

        public IWebElement Support => Driver.FindElement(By.LinkText("Support"));

        public IWebElement CommunityGuidelines => Driver.FindElement(By.LinkText("Community Guidelines"));

        public IWebElement Disclaimers => Driver.FindElement(By.LinkText("Disclaimers"));


        public IWebElement TermsnConditions => Driver.FindElement(By.LinkText("Terms & Conditions"));


        public IWebElement FullName => Driver.FindElement(By.CssSelector("div.d-flex:nth-child(4) > div:nth-child(1) > div:nth-child(2) > input:nth-child(1)"));
    }
}
