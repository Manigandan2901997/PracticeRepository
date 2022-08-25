using AutomationFramework.Pages;
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
    public class TownhallPollTest :BaseTest
    {
        [Test]
        public void CreatePoll()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//img[@alt='poll-icon']")).Click();
            // driver.FindElement(By.Id("mui-54")).Click();
            driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).Click();
            driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys("Who is best batsmen in world ?");
            driver.FindElement(By.XPath("//div/div/div/div/div/div/input")).Click();
            driver.FindElement(By.XPath("//div/div/div/div/div/div/input")).SendKeys("Virat Kohli");
            driver.FindElement(By.XPath("//div/div/div/div[3]/div/div/input")).Click();
            driver.FindElement(By.XPath("//div/div/div/div[3]/div/div/input")).SendKeys("Joe Root");
            driver.FindElement(By.XPath("//select")).Click();
            {
                var dropdown = driver.FindElement(By.CssSelector(".Mui-focused > .MuiNativeSelect-select"));
                dropdown.FindElement(By.XPath("//option[. = '2']")).Click();
            }
            driver.FindElement(By.CssSelector(".Mui-focused > .MuiNativeSelect-select")).Click();
            {
                var dropdown = driver.FindElement(By.CssSelector(".Mui-focused > .MuiNativeSelect-select"));
                dropdown.FindElement(By.XPath("//option[. = '2']")).Click();
            }
            driver.FindElement(By.CssSelector(".Mui-focused > .MuiNativeSelect-select")).Click();
            driver.FindElement(By.CssSelector(".sc-kIeSZW:nth-child(1) > .MuiButton-root")).Click();
            Thread.Sleep(3000);
            Assert.That(driver.FindElement(By.XPath("//span[normalize-space()='Who is best batsmen in world ?']")).Displayed);
        }

        [Test]
        public void RespondToPoll()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[0], TestData.password);
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            //driver.FindElement(By.XPath("//span[contains(text(),'Who is best batsmen in world ?')]//following::span[contains(text(),'Virat Kohli')]")).Click();
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[1]/span[1]")).Click();
            Thread.Sleep(4000);
            {
                var element = driver.FindElement(By.CssSelector(".MuiButtonBase-root.MuiButton-root.MuiButton-contained"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            driver.FindElement(By.CssSelector(".MuiButtonBase-root.MuiButton-root.MuiButton-contained")).Click();
            {
                var element = driver.FindElement(By.TagName("body"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element, 0, 0).Perform();
            }
            Thread.Sleep(2000);
            Assert.That(driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[1]/span[1]/img[1]")).Displayed);
            //driver.FindElement(By.CssSelector(".MuiButtonBase-root:nth-child(5) > img")).Click();
            //driver.FindElement(By.Id("mui-54")).Click();
            //driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).Click();
            //driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys("Who is best batsmen in world ?");
            //driver.FindElement(By.Id("mui-54")).Click();
            //driver.FindElement(By.Id("mui-54")).SendKeys("Virat Kohli");
            //driver.FindElement(By.Id("mui-55")).Click();
            //driver.FindElement(By.Id("mui-55")).SendKeys("Joe Root");
            //driver.FindElement(By.CssSelector(".Mui-focused > .MuiNativeSelect-select")).Click();
            //{
            //    var dropdown = driver.FindElement(By.CssSelector(".Mui-focused > .MuiNativeSelect-select"));
            //    dropdown.FindElement(By.XPath("//option[. = '0']")).Click();
            //}
            //driver.FindElement(By.CssSelector(".Mui-focused > .MuiNativeSelect-select")).Click();
            //{
            //    var dropdown = driver.FindElement(By.CssSelector(".Mui-focused > .MuiNativeSelect-select"));
            //    dropdown.FindElement(By.XPath("//option[. = '1']")).Click();
            //}
        }
    }
}
