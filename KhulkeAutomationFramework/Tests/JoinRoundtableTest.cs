//using AutomationFramework.Pages;
//using OpenQA.Selenium;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;
//using System.Threading;

//namespace AutomationFramework.Tests
//{
//    internal class JoinRoundtableTest: BaseTest
//    {

//        [Test]
//        [Category("sanity")]
        
//        public void JoinRT()
//        {
//            LoginPage loginPage = new LoginPage(Driver, extent);
//            loginPage.OpenFromPage1();

//            Assert.IsTrue(loginPage.VerifyTitle);


//            var newPage = loginPage.Login("perftest410", "#TestDemo1234");
//            //Driver.Navigate().Refresh();
//            Thread.Sleep(2000);


//            IWebElement roundatable = Driver.FindElement(By.LinkText("RoundTable"));
//            roundatable.Click();
//            Thread.Sleep(4000);


//            IWebElement Joinnow = Driver.FindElement(By.Id("join_button"));
//            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(3000);
//            Joinnow.Click();
//            Thread.Sleep(4000);

//        }
//    }
//}
