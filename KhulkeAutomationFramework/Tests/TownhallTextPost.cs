using AutomationFramework.HelperMethods;
using AutomationFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AutomationFramework.Tests
{
    internal class TownhallTextPost: BaseTest
    {
        [Test,Order(1)]
        [Category("sanity")]
        public void PostTextonTownhallTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement textarea = Driver.FindElement(By.XPath("//textarea[@placeholder='Write your content here...']"));
            //textarea.Click();
            textarea.SendKeys(TestData.textPost);
            IWebElement Post = Driver.FindElement(By.XPath("//button[normalize-space()='POST']"));
            Post.Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => HelperClass.IsAlertShown((WebDriver)driver));
            var alert_win = driver.SwitchTo().Alert();
            alert_win.Accept();
            Thread.Sleep(1000);
            Assert.IsTrue(driver.FindElement(By.XPath("//p[normalize-space()='"+ TestData.textPost + "']")).Displayed);

        }

        [Test, Order(2)]
        public void FollowUserTest()
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
            Assert.That(driver.FindElement(By.XPath("//button[@class='following-button']")).Displayed);
            extent.test.Info("Follow user");
        }
        [Test, Order(3)]
        public void CommentPostTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[0], TestData.password);
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            IWebElement commentBtn = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[1]/button)[1]"));
            commentBtn.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@placeholder='Write what you feel about this...']")).SendKeys("This is testing comment posted on self post");
            driver.FindElement(By.XPath("//button[normalize-space()='Post']")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            Assert.That(driver.FindElement(By.XPath("(//div[@id='townhall_post_body'])[1]/p")).Text.Equals("This is testing comment posted on self post"));

            extent.test.Info("post Commented");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            TownhallPage townhallPage = new TownhallPage(driver, extent);
            string elementpath = "(//div[@id='townhall_post_container']//p[contains(text(),'This is testing comment posted on self post')]//ancestor::div[@id='townhall_post_container']//div[@id='post_header_container']//div[2]/button[@id='basic-button'])[1]";
            townhallPage.DeletePost(elementpath);
            extent.test.Info("Another user commented post deleted");
        }

        [Test, Order(4)]
        public void LikePostTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[0], TestData.password);
            var username = TestData.userNames[4];
            //Driver.Navigate().Refresh();
            Thread.Sleep(1000);
            //var likeCount = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//a[not(contains(@href,'" + username + "'))]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[3]/button//following-sibling::p)[1]")).Text;
            var likeCount = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'"+ TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[3]/button//following-sibling::p)[1]")).Text;
            // driver.FindElement(By.XPath("//div[4]//div[2]//div[2]//div[2]//div[1]//div[3]")).Click();
            IWebElement dislikeBtnSvg = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[4]/button/*[name()='svg'])[1]"));
            var dataNameAttr = dislikeBtnSvg.GetAttribute("data-name");
            if (dataNameAttr == null || dataNameAttr == "" || dataNameAttr == "undefined")
            {
                var divLike = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container'])[1]"));
                //!code to scroll 
                var script = "arguments[0].scrollIntoView(true);";
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript(script, divLike);

                IWebElement likeBtn = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[3]/button)[1]"));
                likeBtn.SendKeys(Keys.Enter);
            }
            else
            {
                var divLike = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container'])[1]"));
                var script = "arguments[0].scrollIntoView(true);";
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript(script, divLike);
                IWebElement dislikeBtn = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[4]/button)[1]"));
                dislikeBtn.SendKeys(Keys.Enter);
                IWebElement likeBtn = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[3]/button)[1]"));
                Thread.Sleep(1000);
                likeBtn.SendKeys(Keys.Enter);
                //likeBtn.Click();

            }
            Thread.Sleep(1000);
            var likeCountafter = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//a[contains(@href,'" + username + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[3]/button//following-sibling::p)[1]")).Text;
            Thread.Sleep(3000);
            Assert.That(likeCountafter, Is.EqualTo(likeCount));
            extent.test.Info("Test of like post of login user");
        }

        [Test, Order(5)]
        public void DislikePostTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[0], TestData.password);
            Thread.Sleep(1000);
            IWebElement likeBtnSvg = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[3]/button/*[name()='svg'])[1]"));
            var dataNameAttr = likeBtnSvg.GetAttribute("data-name");
            if (dataNameAttr == null || dataNameAttr == "" || dataNameAttr == "undefined")
            {
                //driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//a[not(contains(@href,'" + TestData.userNames[4] + "'))]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[4]/button)[1]")).SendKeys(Keys.Enter);
                driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[4]/button)[1]")).Click();
            }
            else
            {
                IWebElement likeBtn = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[3]/button)[1]"));
                Thread.Sleep(1000);
                //likeBtn.SendKeys(Keys.Enter);
                likeBtn.Click();
                driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[4]/button)[1]")).SendKeys(Keys.Enter);
            }

            Thread.Sleep(3000);
            var dislikeSvg = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[4]/button/*[name()='svg'])[1]"));
            var afterDataNameAttr = dislikeSvg.GetAttribute("data-name");
            Thread.Sleep(3000);
            Assert.That(afterDataNameAttr, Is.Not.Null);

            extent.test.Info("Test of dislike post of other user");

        }

        [Test, Order(6)]
        public void CirculateTest()
        {

            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement CirculateImage = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[2]/button)[1]"));
            var script = "arguments[0].scrollIntoView(true);";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script, CirculateImage);
            CirculateImage.SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("//li[contains(text(),'Circulate')]")).Click();
            IWebElement circulateSVG = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'This is test of test post...')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[2]/button/*[name()='svg'])[1]"));
            var svgClassName = circulateSVG.GetAttribute("class");
            Assert.That(svgClassName, Is.EqualTo("icon icon_color"));
            //Assert.That(driver.FindElement(By.XPath("(//body/div/div/div/div[2]/div[1]/span[2])[1]")).Text,Is.EqualTo("circulated your post"));
            extent.test.Info("post circualted");

        }

        [Test, Order(7)]
        public void UncirculateTest()
        {

            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement CirculateImage = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[2]/button)[1]"));
            var script = "arguments[0].scrollIntoView(true);";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script, CirculateImage);
            CirculateImage.SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("//li[contains(text(),'Uncirculate')]")).Click();
            IWebElement circulateSVG = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[2]/button/*[name()='svg'])[1]"));
            var svgClassName = circulateSVG.GetAttribute("class");
            Thread.Sleep(1000);
            Assert.That(svgClassName, Is.EqualTo("icon false"));
            // Assert.That(!driver.FindElement(By.XPath("(//span[contains(text(),'Circulated')])[1]")).Displayed);
            extent.test.Info("post uncircualted");

        }

        [Test, Order(8)]
        public void QuoteTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Quote 
            IWebElement CirculateImage = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[2]/button)[1]"));           
            CirculateImage.SendKeys(Keys.Enter);           
            driver.FindElement(By.XPath("//li[contains(text(),'Quote')]")).Click();
            driver.FindElement(By.XPath("//textarea[@placeholder='Write what you feel about this...']")).SendKeys("This is testing of quote");
            driver.FindElement(By.XPath("//button[normalize-space()='Post']")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            Assert.That(driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/p[1]")).Text.Equals("This is testing of quote"));
            extent.test.Info("post quoted");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            TownhallPage townhallPage = new TownhallPage(driver, extent);
            string elementpath = "(//div[@id='townhall_post_container']//p[contains(text(),'This is testing of quote')]//ancestor::div[@id='townhall_post_container']//div[@id='post_header_container']//div[2]/button[@id='basic-button'])[1]";
            townhallPage.DeletePost(elementpath);
            extent.test.Info("Quoted post deleted");
        }

        [Test, Order(9)]
        public void SavePostTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement saveBtn = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']//div[@id='post_header_container']//div[2]/button[@id='basic-button'])[1]"));
            saveBtn.SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("//li[normalize-space()='Save']")).Click();
            Assert.That(driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']//div[@id='post_header_container']//div[2]/button[1]//*[name()='svg'])[1]")).Displayed);

            //! check in profile save post
            Thread.Sleep(2000);
            IWebElement UserButton = driver.FindElement(By.XPath("//button[@class='MuiButtonBase-root MuiIconButton-root']"));
            UserButton.Click();
            IWebElement Profile = driver.FindElement(By.XPath("//li[contains(text(),'Profile')]"));
            Profile.Click();
            driver.FindElement(By.XPath("//button[contains(text(),'Saved')]")).Click();
            Assert.That(driver.FindElement(By.XPath("//div[@id='townhall_post_body']/p[contains(text(),'"+TestData.textPost+"')]")).Displayed);
            extent.test.Info("post saved");
        }

        [Test, Order(10)]
        public void UnsavePostTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement saveBtn = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']//div[@id='post_header_container']//div[2]/button[@id='basic-button'])[1]"));
            saveBtn.SendKeys(Keys.Enter);
            IWebElement unsaveBtn =  driver.FindElement(By.XPath("//li[normalize-space()='Unsave']"));
            unsaveBtn.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
           // var t = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']//div[@id='post_header_container']//div[2]/button[1]//*[name()='svg'])[1]")).Size;
            Assert.That(!driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']//div[@id='post_header_container']//div[2]/button[1]//*[name()='svg'])[1]")).Displayed);

            //! check in profile save post
            Thread.Sleep(2000);
            IWebElement UserButton = driver.FindElement(By.XPath("//button[@class='MuiButtonBase-root MuiIconButton-root']"));
            UserButton.Click();
            IWebElement Profile = driver.FindElement(By.XPath("//li[contains(text(),'Profile')]"));
            Profile.Click();
            driver.FindElement(By.XPath("//button[contains(text(),'Saved')]")).Click();
            Assert.That(!driver.FindElement(By.XPath("//div[@id='townhall_post_body']/p[contains(text(),'" + TestData.textPost + "')]")).Displayed);
            extent.test.Info("post saved");
        }
        [Test, Order(11)]
        public void SharePost()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[2]/div[2]/div[2]/div[2]/div[2]/button[1]")).Click();
            var alert_win = driver.SwitchTo().Alert();
            Assert.That(alert_win.Text.Equals(AlertsData.allAlerts["SharePostAlert"]));
            alert_win.Accept();
        }
        [Test, Order(12)]
        public void CommentPostSelfTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            IWebElement commentBtn = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//a[contains(@href,'" + TestData.userNames[4] + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[1]/button)[1]"));
            commentBtn.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@placeholder='Write what you feel about this...']")).SendKeys("This is testing comment posted on self post");
            driver.FindElement(By.XPath("//button[normalize-space()='Post']")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            Assert.That(driver.FindElement(By.XPath("(//div[@id='townhall_post_body'])[1]/p")).Text.Equals("This is testing comment posted on self post"));

            extent.test.Info("post Commented");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            TownhallPage townhallPage = new TownhallPage(driver, extent);
            string elementpath = "(//div[@id='townhall_post_container']//p[contains(text(),'This is testing comment posted on self post')]//ancestor::div[@id='townhall_post_container']//div[@id='post_header_container']//div[2]/button[@id='basic-button'])[1]";
            townhallPage.DeletePost(elementpath);            
            extent.test.Info("Commented post deleted");


        }
        [Test, Order(13)]
        public void LikePostSelfTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            var username = TestData.userNames[4];
            //Driver.Navigate().Refresh();
            Thread.Sleep(1000);
            //var likeCount = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//a[not(contains(@href,'" + username + "'))]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[3]/button//following-sibling::p)[1]")).Text;
            var likeCount = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//a[contains(@href,'" + username + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[3]/button//following-sibling::p)[1]")).Text;
            // driver.FindElement(By.XPath("//div[4]//div[2]//div[2]//div[2]//div[1]//div[3]")).Click();
            var divLike = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//a[contains(@href,'" + username + "')]//ancestor::div[@id='townhall_post_container'])[1]"));
            //!code to scroll 
            var script = "arguments[0].scrollIntoView(true);";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script, divLike);

            IWebElement likeBtn = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//a[contains(@href,'" + username + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[3]/button)[1]"));
            likeBtn.SendKeys(Keys.Enter);

            // likeBtn.Click();
            Thread.Sleep(1000);
            var likeCountafter = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//a[contains(@href,'" + username + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[3]/button//following-sibling::p)[1]")).Text;
            Thread.Sleep(3000);
            Assert.That(likeCountafter, Is.EqualTo(likeCount));
            extent.test.Info("Test of like post of login user");

        }
        [Test, Order(14)]
        public void DislikePostSelf()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            var username = TestData.userNames[4];
            //Driver.Navigate().Refresh();
            Thread.Sleep(1000);

            var divLike = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//a[contains(@href,'" + username + "')]//ancestor::div[@id='townhall_post_container'])[1]"));
            //!code to scroll 
            var script = "arguments[0].scrollIntoView(true);";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script, divLike);

            IWebElement dislikeBtn = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//a[contains(@href,'" + username + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[4]/button)[1]"));
            dislikeBtn.SendKeys(Keys.Enter);

            var dislikeSvg = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//a[contains(@href,'" + TestData.userNames[4] + "')]//ancestor::div[@id='townhall_post_container']/div/following-sibling::div/div[2]/div[2]/div/div[4]/button/*[name()='svg'])[1]"));
            var afterDataNameAttr = dislikeSvg.GetAttribute("data-name");
            Thread.Sleep(3000);
            Assert.That(afterDataNameAttr, Is.Null);
            extent.test.Info("Test of dislike post of login user");

        }

        [Test, Order(15)]
        public void DeletePostTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            TownhallPage townhallPage = new TownhallPage(driver, extent);
            string elementpath = "(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']//div[@id='post_header_container']//div[2]/button[@id='basic-button'])[1]";
            townhallPage.DeletePost(elementpath);
            //IWebElement saveBtn = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//p[contains(text(),'" + TestData.textPost + "')]//ancestor::div[@id='townhall_post_container']//div[@id='post_header_container']//div[2]/button[@id='basic-button'])[1]"));
            //saveBtn.SendKeys(Keys.Enter);
            //driver.FindElement(By.XPath("//li[normalize-space()='Delete']")).Click();
            //Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("Successfully Deleted"));
            extent.test.Info("post deleted");
        }

        [Test, Order(16)]
        public void UnfollowUserTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[0], "#TestDemo1234");
            //!Firts search user and follow/unfollow using first user
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var search = driver.FindElement(By.XPath("//input[@placeholder='Search']"));
            search.Click();
            search.SendKeys("Radhikayewale");
            search.SendKeys(Keys.Enter);
            var followBtn = driver.FindElement(By.XPath("//button[contains(text(),'follow')]"));
            if (followBtn.GetAttribute("class") == "following-button")
            {
                followBtn.Click();
            }
            Assert.That(driver.FindElement(By.XPath("//button[@class='follow-button ']")).Displayed);
            extent.test.Info("Unfollow user");

        }

        //!Negative test cases
        [Test]
        public void BlankPostTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }
        [Test]
        public void UploadMoreTextTest()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement textarea = Driver.FindElement(By.XPath("//textarea[@placeholder='Write your content here...']"));
            //textarea.Click();
            textarea.SendKeys(TestData.textPostMore);
            IWebElement Post = Driver.FindElement(By.XPath("//button[normalize-space()='POST']"));
            Post.Click();
            Thread.Sleep(1000);
            var alert_win = driver.SwitchTo().Alert();
            alert_win.Accept();
            string textPost = TestData.textPostMore.Substring(0, 300);
            textPost = textPost.TrimEnd();
            int textLength = textPost.Length;
            string postedText = driver.FindElement(By.XPath("(//div[@id='townhall_post_container']//a[contains(@href,'radhikayewale')]//ancestor::div[@id='townhall_post_container']//div[@id='townhall_post_body']/p)[1]")).Text;
            int postedStrLength = postedText.Length;
            Assert.That(postedStrLength, Is.EqualTo(textLength));

            //! delete post
            TownhallPage townhallPage = new TownhallPage(driver, extent);
            string elementpath = "(//div[@id='townhall_post_container']//p[contains(text(),'" + textPost + "')]//ancestor::div[@id='townhall_post_container']//div[@id='post_header_container']//div[2]/button[@id='basic-button'])[1]";
            townhallPage.DeletePost(elementpath);

        }
        
    }
}
