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
    internal class Account_ProfileTest : BaseTest
    {

        [Test]
        public void Editprofile()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            Driver.Navigate().Refresh();
            IWebElement UserButton = driver.FindElement(By.CssSelector(".MuiIconButton-label > .sc-iwyWTf"));
            UserButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            IWebElement Profile = driver.FindElement(By.CssSelector(".MuiMenuItem-root:nth-child(1)"));
            Profile.Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//button[contains(.,'Edit Profile')]")).Displayed);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            IWebElement Editprof = driver.FindElement(By.XPath("//button[contains(.,'Edit Profile')]"));
            Editprof.Click();
            Thread.Sleep(2000);

            IWebElement Bio = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[1]/div/textarea"));
            Bio.Click();
            Bio.Clear();
            Bio.SendKeys("Radhikaaaa");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


            IWebElement FullName = driver.FindElement(By.CssSelector("div.d-flex:nth-child(4) > div:nth-child(1) > div:nth-child(2) > input:nth-child(1)"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            FullName.Clear();
            FullName.SendKeys(Keys.Enter);
            FullName.SendKeys("Radhika Godase");
            extent.test.Info("Profile updated");
            Thread.Sleep(3000);

            IWebElement Gender = driver.FindElement(By.Id("react-select-2-input"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Gender.Clear();
            Gender.SendKeys("Male");
            IWebElement Genderlistbox = driver.FindElement(By.Id("react-select-2-option-Male"));
            Genderlistbox.Click();

            IWebElement GenderF = driver.FindElement(By.Id("react-select-2-input"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            GenderF.Clear();
            GenderF.SendKeys("Female");
            IWebElement GenderlistboxF = driver.FindElement(By.Id("react-select-2-option-Female"));
            Genderlistbox.Click();

            IWebElement GenderO = driver.FindElement(By.Id("react-select-2-input"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            GenderO.Clear();
            GenderO.SendKeys("Other");
            IWebElement GenderlistboxO = driver.FindElement(By.Id("react-select-2-option-Other"));
            Genderlistbox.Click();

            IWebElement Website = driver.FindElement(By.XPath("//div[4]/div/div/input[1]"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Website.Clear();
            Website.SendKeys(Keys.Enter);
            Website.SendKeys("www.kalgi.com");

            IWebElement Location = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[4]/div[2]/div/input"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Location.Clear();
            Location.SendKeys(Keys.Enter);
            Location.SendKeys("Pune");

            IWebElement Savechanges = driver.FindElement(By.CssSelector(".btn"));
            Savechanges.SendKeys(Keys.Enter);
            Thread.Sleep(4000);
            Assert.IsTrue(driver.FindElement(By.XPath("//small[@class='text-success' and contains(text(),'Your changes have been saved!')]")).Displayed);


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void NavigateAccountSettingsTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            extent.test.Info("Login succesful");
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);

            IWebElement UserButton = driver.FindElement(By.CssSelector(".MuiIconButton-label > .sc-iwyWTf"));
            UserButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
           
            IWebElement Profile = driver.FindElement(By.CssSelector(".MuiMenuItem-root:nth-child(1)"));
            Profile.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement UserButton1 = driver.FindElement(By.CssSelector(".MuiIconButton-label > .sc-iwyWTf"));
            UserButton1.Click();
            Thread.Sleep(2000);
            IWebElement Accountsetting = driver.FindElement(By.CssSelector(".MuiMenuItem-root:nth-child(3)"));
            Accountsetting.Click();
            Thread.Sleep(2000);
            String accSettingURL = driver.Url;
            Assert.That(accSettingURL, Is.EqualTo("https://jitsi.konsultera.co.in/account_settings"));
            Thread.Sleep(2000);

            IWebElement Logout = driver.FindElement(By.XPath("//p[normalize-space()='Logout']"));
            Logout.Click();
            Thread.Sleep(2000);
            String startURL = driver.Url;
            Assert.That(startURL, Is.EqualTo("https://jitsi.konsultera.co.in/"));

        }

        [Test]
        [Category("sanity")]
        //navigate to all pages in account settings and log out
        public void checkback()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            Thread.Sleep(4000);

            IWebElement menu = Driver.FindElement(By.CssSelector(".MuiIconButton-label > .sc-iwyWTf"));
            menu.Click();
            Thread.Sleep(3000);

            IWebElement accsetting = Driver.FindElement(By.CssSelector(".MuiMenuItem-root:nth-child(3)"));
            accsetting.Click();
            Thread.Sleep(3000);
            String accSttingUrl = driver.Url;
            Assert.That(accSttingUrl, Is.EqualTo("https://jitsi.konsultera.co.in/account_settings"));


            IWebElement InviteFriends = driver.FindElement(By.LinkText("Invite Friends"));
            InviteFriends.Click();
            Thread.Sleep(3000);
            String inviteFriendUrl = driver.Url;
            Assert.That(inviteFriendUrl, Is.EqualTo("https://jitsi.konsultera.co.in/invite_friends"));

            IWebElement Privacy = driver.FindElement(By.LinkText("Privacy"));
            Privacy.Click();
            Thread.Sleep(3000);
            String privacyUrl = driver.Url;
            Assert.That(privacyUrl, Is.EqualTo("https://jitsi.konsultera.co.in/privacy_settings"));

            IWebElement Password = driver.FindElement(By.LinkText("Password"));
            Password.Click();
            Thread.Sleep(3000);
            String passwordUrl = driver.Url;
            Assert.That(passwordUrl, Is.EqualTo("https://jitsi.konsultera.co.in/change_password"));

            IWebElement MutedWords = driver.FindElement(By.LinkText("Muted Words"));
            MutedWords.Click();
            Thread.Sleep(3000);
            String mutedWordsUrl = driver.Url;
            Assert.That(mutedWordsUrl, Is.EqualTo("https://jitsi.konsultera.co.in/muted_words"));

            IWebElement MutedAccounts = driver.FindElement(By.LinkText("Muted Accounts"));
            MutedAccounts.Click();
            Thread.Sleep(3000);
            String mutedAccountUrl = driver.Url;
            Assert.That(mutedAccountUrl, Is.EqualTo("https://jitsi.konsultera.co.in/muted_accounts"));


            IWebElement BlockPage = Driver.FindElement(By.LinkText("Blocked Accounts"));
            BlockPage.Click();
            Thread.Sleep(3000);
            String blockpageUrl = driver.Url;
            Assert.That(blockpageUrl, Is.EqualTo("https://jitsi.konsultera.co.in/blocked_accounts"));
            extent.test.Info("successfully navigated to all pages in account settings");


        }

        [Test]
        [Category("sanity")]

        public void NaviagteAccountSettingsSupportSection()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            // Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement UserButton = driver.FindElement(By.CssSelector(".MuiIconButton-label > .sc-iwyWTf"));
            UserButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement Accountsetting = driver.FindElement(By.CssSelector(".MuiMenuItem-root:nth-child(3)"));
            Accountsetting.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            String accSttingUrl = driver.Url;
            Assert.That(accSttingUrl, Is.EqualTo("https://jitsi.konsultera.co.in/account_settings"));
            //!Check FAQ page open or not
            IWebElement FAQ = driver.FindElement(By.LinkText("FAQ"));
            FAQ.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var browserTabsFAQ = driver.WindowHandles;
            driver.SwitchTo().Window(browserTabsFAQ[1]);
            Assert.That(driver.FindElement(By.XPath("//h2[contains(text(),'FAQ')]")).Displayed);
            driver.Close();
            driver.SwitchTo().Window(browserTabsFAQ[0]);
            extent.test.Info("Navigate to FAQ page");

            //!Check Privacy page open or not
            IWebElement Privacy = driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/a[1]"));
            Privacy.Click();
            Thread.Sleep(4000);
            var browserTabsPrivacy = driver.WindowHandles;
            driver.SwitchTo().Window(browserTabsPrivacy[1]);
            Assert.That(driver.FindElement(By.XPath("//h2[contains(text(),'Privacy Policy')]")).Displayed);
            driver.Close();
            driver.SwitchTo().Window(browserTabsPrivacy[0]);
            extent.test.Info("Navigate to Privacy page");

            //!Check Community Guidlines page open or not
            IWebElement CommunityGuidelines = driver.FindElement(By.LinkText("Community Guidelines"));
            CommunityGuidelines.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var browserTabsCommunity = driver.WindowHandles;
            driver.SwitchTo().Window(browserTabsCommunity[1]);
            Assert.That(driver.FindElement(By.XPath("//h2[contains(text(),'Community Guidelines')]")).Displayed);
            driver.Close();
            driver.SwitchTo().Window(browserTabsCommunity[0]);
            extent.test.Info("Navigate to Community Guidelines page");

            //!Check Disclaimers page open or not
            IWebElement Disclaimers = driver.FindElement(By.LinkText("Disclaimers"));
            Disclaimers.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var browserTabsDisclaimers = driver.WindowHandles;
            driver.SwitchTo().Window(browserTabsDisclaimers[1]);
            Assert.That(driver.FindElement(By.XPath("//h2[contains(text(),'Disclaimers')]")).Displayed);
            driver.Close();
            driver.SwitchTo().Window(browserTabsDisclaimers[0]);
            extent.test.Info("Navigate to Disclaimers page");

            //!Check Support page open or not
            IWebElement Support = driver.FindElement(By.LinkText("Support"));
            Support.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var browserTabsSupport = driver.WindowHandles;
            driver.SwitchTo().Window(browserTabsSupport[1]);
            Assert.That(driver.FindElement(By.XPath("//h2[contains(text(),'Support')]")).Displayed);
            driver.Close();
            driver.SwitchTo().Window(browserTabsSupport[0]);
            extent.test.Info("Navigate to support page");

            //!Check Terms and Conditions page open or not
            IWebElement TermsandConditions = driver.FindElement(By.LinkText("Terms & Conditions"));
            TermsandConditions.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var browserTabsTerms = driver.WindowHandles;
            driver.SwitchTo().Window(browserTabsTerms[1]);
            Assert.That(driver.FindElement(By.XPath("//h2[contains(text(),'Terms & Conditions')]")).Displayed);           
            driver.Close();
            driver.SwitchTo().Window(browserTabsTerms[0]);
            extent.test.Info("Navigate to Terms and Conditions page");
        }


    }
}
