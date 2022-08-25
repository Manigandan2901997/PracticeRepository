using AutomationFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationFramework.Tests
{
    internal class TownhallPostTest : BaseTest
    {        
        [Test]
        [Category("sanity")]
        public void PostTextonTownhall()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement textarea = Driver.FindElement(By.XPath("//textarea[@placeholder='Write your content here...']"));
            //textarea.Click();
            textarea.SendKeys("Heavy rain in pune...");            
            IWebElement Post = Driver.FindElement(By.XPath("//button[normalize-space()='POST']"));
            Post.Click();
            var alert_win = driver.SwitchTo().Alert();
            alert_win.Accept();
            Assert.IsTrue(driver.FindElement(By.XPath("//p[normalize-space()='Heavy rain in pune...']")).Displayed);
            
        }

        [Test]
        [Category("sanity")]
        public void PostImageonTownhall()
        {

            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var dirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var folderPath = dirPath.Substring(0, dirPath.IndexOf("bin"));
            var filePath = folderPath + "assets\\PVS_2086.JPG";
           // driver.FindElement(By.CssSelector(".MuiButtonBase-root:nth-child(2) > img")).Click();

            driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(2) > input")).SendKeys(filePath);
           // driver.FindElement(By.XPath("(//textarea[@placeholder='Write your content here...'])[2]")).Click();
            driver.FindElement(By.XPath("(//textarea[@placeholder='Write your content here...'])[2]")).SendKeys("Nature at its best !!");
            driver.FindElement(By.XPath("//button[normalize-space()='Post']")).Click();
          
            var alert_win = driver.SwitchTo().Alert();
            alert_win.Accept();            
            Assert.IsTrue(driver.FindElement(By.XPath("(//p[contains(text(),'Nature at its best !!')])[1]")).Displayed);
        }

        [Test]
        [Category("sanity")]
        public void PostPDFonTownhall()
        {

            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var dirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var folderPath = dirPath.Substring(0, dirPath.IndexOf("bin"));
            var filePath = folderPath + "assets\\Testingpdf.pdf";
            driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(3) > input")).SendKeys(filePath);
            // driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys(Keys.Enter);
            driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys("Testing basics");
            driver.FindElement(By.XPath("//button[normalize-space()='Post']")).Click();
            var alert_win = driver.SwitchTo().Alert();
            alert_win.Accept();
            Assert.IsTrue(driver.FindElement(By.XPath("//p[normalize-space()='Testingpdf.pdf']")).Displayed);
            extent.test.Info("Document posted on townhall");
        }
        [Test]
        [Category("sanity")]
        public void PostAudioOnTownhall()
        {

            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            var dirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var folderPath = dirPath.Substring(0, dirPath.IndexOf("bin"));
            var filePath = folderPath + "assets\\file_example_MP3_1MG.mp3";
            driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(4) > input")).SendKeys(filePath);
            driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).Click();            
            driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys("Song");
            driver.FindElement(By.CssSelector(".sc-kIeSZW:nth-child(1) > .MuiButton-root")).Click();
            Thread.Sleep(2000);
            var alert_win = driver.SwitchTo().Alert();
            alert_win.Accept();
            Thread.Sleep(2000);
            Assert.IsTrue(driver.FindElement(By.XPath("//p[normalize-space()='Song']")).Displayed);
            extent.test.Info("Audio posted on townhall");
        }
        [Test]
        [Category("sanity")]
        public void PostVideoOnTownhallTest()
        {

            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var dirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var folderPath = dirPath.Substring(0, dirPath.IndexOf("bin"));
            var filePath = folderPath + "assets\\testingvideo.mp4";

            driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(1) > input")).SendKeys(filePath);
           
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('my_video_player').playbackRate+=1.75");
            js.ExecuteScript("document.getElementById('my_video_player').play()");
            Thread.Sleep(10000);
          
            Thread.Sleep(4000);
            //driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys("Video upload");
            //driver.FindElement(By.CssSelector(".sc-kIeSZW:nth-child(1) > .MuiButton-root")).Click();
            //var alert_win = driver.SwitchTo().Alert();
            //alert_win.Accept();
            //Assert.That(driver.FindElement(By.XPath("((//button[@type='button'])//*[name()='svg'])[1]")).GetAttribute("class").Equals("icon icon_color"));
            //extent.test.Info("video posted on townhall");

        }

        [Test]
        public void SaveUnSaveDeleteTest()
        {

            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".MuiButtonBase-root:nth-child(2) > img")).Click();
            driver.FindElement(By.CssSelector(".icon_container > .MuiButtonBase-root:nth-child(2) > input")).SendKeys(@"C:\Users\Radhika y. Yewale\Downloads\PVS_2086.JPG");
            driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).Click();
            driver.FindElement(By.CssSelector(".MuiGrid-root .post-area")).SendKeys("Nature at its best !!");
            driver.FindElement(By.CssSelector(".sc-kIeSZW:nth-child(1) > .MuiButton-root")).Click();
            Thread.Sleep(2000);
            //save post
            driver.FindElement(By.XPath("//button[@id=\'basic-button\']/div/img")).Click();
            driver.FindElement(By.CssSelector(".MuiMenuItem-root:nth-child(1)")).Click();
            {
                var element = driver.FindElement(By.XPath("//button[@id=\'basic-button\']/div/img"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }

            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//button[@id=\'basic-button\']/div/img")).Click();
            {
                var element = driver.FindElement(By.TagName("body"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element, 0, 0).Perform();
            }
            driver.FindElement(By.CssSelector(".MuiMenuItem-root:nth-child(1)")).Click();
            {
                var element = driver.FindElement(By.XPath("//button[@id=\'basic-button\']/div/img"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            extent.test.Info("un saved post");
            driver.FindElement(By.XPath("//button[@id=\'basic-button\']/div/img")).Click();
            {
                var element = driver.FindElement(By.TagName("body"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element, 0, 0).Perform();
            }
            driver.FindElement(By.CssSelector(".MuiMenuItem-root:nth-child(3)")).Click();
            Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("Successfully Deleted"));
            extent.test.Info("Deleted post");

        }

        //!This test is written to check discard the video post before posting
       
        
        
        [Test]
        public void AlertPostCreated()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();
            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[4], TestData.password);
            //Driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            DateTime now = DateTime.Now;
            var postText = "This is test post(" + now +")";
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/div[1]/div[1]/span[1]/textarea[1]")).SendKeys(postText);
            driver.FindElement(By.XPath("//button[normalize-space()='POST']")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            var alert_win = driver.SwitchTo().Alert();
            var actualAlertText = "Your post has been created.";
            Assert.That(alert_win.Text.Equals(actualAlertText));
            alert_win.Accept();
        }
                    
       

        [Test]
        [Category("sanity")]
        public void MutePost()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[1], TestData.password);
            //Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#basic-button")).Click();
            driver.FindElement(By.CssSelector("li.MuiMenuItem-root:nth-child(5)")).Click();
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[1]/div[2]/button[1]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.CssSelector("li.MuiMenuItem-root:nth-child(3)")).Click();
            driver.FindElement(By.LinkText("Muted Accounts")).Click();
            driver.FindElement(By.CssSelector(".follow-button-small")).Click();
            driver.FindElement(By.CssSelector(".sc-bdfBQB")).Click();
        }

       

    }
}

