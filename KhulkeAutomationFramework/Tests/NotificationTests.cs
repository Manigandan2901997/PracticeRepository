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
    
    public class NotificationTests: BaseTest
    {
        [Test]
        [Category("sanity")]

        public void NavigateToNotificationTabs()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            NotificationPage notificationPage = new NotificationPage(Driver, extent);

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], "#TestDemo1234");
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            notificationPage.ClickonNotification();
            extent.test.Info("Navigated to notification interaction tab");
            Thread.Sleep(2000);
            notificationPage.ClickonNetworkTab();
            extent.test.Info("Navigated to network tab");
            Thread.Sleep(1000);
            notificationPage.ClickonRoundTableTab();
            extent.test.Info("Navigated to roundtable notifications tab");

            Thread.Sleep(1000);
        }

        //!This test checks Network Notification
        [Test]
        [Category("sanity")]
        public void CheckNetworkNotification()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[0], "#TestDemo1234");
            //!Firts search user and follow/unfollow using first user
            var search = driver.FindElement(By.XPath("//input[@placeholder='Search']"));
            search.Click();
            search.SendKeys("Radhikayewale");
            search.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            var followBtn = driver.FindElement(By.XPath("//button[contains(text(),'follow')]"));
            if(followBtn.GetAttribute("class") == "follow-button ")
            {
                followBtn.Click();
            }
            else
            {
                driver.FindElement(By.XPath("//button[contains(text(),'follow')]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//button[contains(text(),'follow')]")).Click();
               
            }

            //!Logout from first user 
            Thread.Sleep(2000);
            loginPage.Logout();
            Thread.Sleep(2000);
            //!Login with first user to check network notification showing or not       
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            loginPage.Login(TestData.userNames[4], "#TestDemo1234");
            NotificationPage notificationPage = new NotificationPage(Driver, extent);
            notificationPage.ClickonNotification();
            Thread.Sleep(2000);
            notificationPage.ClickonNetworkTab();
            Thread.Sleep(2000);
            Assert.That(driver.FindElement(By.XPath("//small[normalize-space()='@" + TestData.userNames[0] + "']")).Displayed);
            extent.test.Info("Notification of network showing");
        }

        //!This test is used to check interaction notifications are comning or not
        [Test]
        [Category("sanity")]
        public void CheckInteractionNotification()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], "#TestDemo1234");
            //!Firts post text in townhall from first user
            IWebElement textarea = Driver.FindElement(By.XPath("//textarea[@placeholder='Write your content here...']"));
            textarea.Click();
            textarea.SendKeys("Reading corporate culture from the outside...");
            IWebElement Post = Driver.FindElement(By.XPath("//button[normalize-space()='POST']"));
            Post.Click();
            Thread.Sleep(2000);
            //!Logout from first user 
            Thread.Sleep(2000);
            loginPage.Logout();
            Thread.Sleep(2000);
            //!Login with second user to like post           
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            loginPage.Login(TestData.userNames[0], "#TestDemo1234");

            //!Like the post and logout
            driver.FindElement(By.XPath("//div[@class='sc-jmhFuu gaQLbL']//div[2]//div[2]//div[2]//div[2]//div[1]//div[3]//button[1]//*[name()='svg']")).Click();
            Thread.Sleep(2000);
            loginPage.Logout();
            Thread.Sleep(2000);

            //!Login with first user to check notification showing or not
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            loginPage.Login(TestData.userNames[4], "#TestDemo1234");
            NotificationPage notificationPage = new NotificationPage(Driver, extent);
            notificationPage.ClickonNotification();
            Thread.Sleep(2000);
            Assert.That(driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/span[2][contains(text(),'Liked your post')]")).Displayed);
            extent.test.Info("Notification of interaction showing");
        }

        //!Test to check round table notification
        [Test]
        [Category("sanity")]
        public void CheckRTNotification()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            Thread.Sleep(2000);
            CreatePublicRT createPublicRT = new CreatePublicRT(Driver, extent);
            createPublicRT.CreateNewPublicRT();

            //js.ExecuteScript("window.scrollTo(0,0)");
            driver.FindElement(By.CssSelector(".proceed_btn")).SendKeys(Keys.Enter);
            Thread.Sleep(4000);
            IWebElement errormessageID = driver.FindElement(By.CssSelector("#root > div > div.sc-dkaWRx.kTMoQF > section > section > section > div:nth-child(2) > h2"));
            string errormessage = errormessageID.Text;
            Assert.That(errormessage, Is.EqualTo("Awesome!"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //!Logout from first user 
            Thread.Sleep(2000);
            loginPage.Logout();
            Thread.Sleep(2000);
            //!Login with first user to check network notification showing or not       
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            loginPage.Login(TestData.userNames[0], "#TestDemo1234");
            NotificationPage notificationPage = new NotificationPage(Driver, extent);
            notificationPage.ClickonNotification();
            Thread.Sleep(2000);
            notificationPage.ClickonRoundTableTab();
            Thread.Sleep(2000);
            Assert.That(driver.FindElement(By.XPath("//p[contains(text(),'Test RT 1')]")).Displayed);
            extent.test.Info("Notification of RT showing");
        }


    }
}
