using AutomationFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace AutomationFramework.Tests
{
    public class CreateRoundTable : BaseTest
    {
        private IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;

        private IJavaScriptExecutor js1 = (IJavaScriptExecutor)Driver;

        //public string URL1 = "https://jitsi.konsultera.co.in/roundtable/listing";

        //public string URL2 = "https://jitsi.konsultera.co.in/roundtable/listing";

        //[Test]
        //public void CreatePublicRoundTable()
        //{
        //    LoginPage loginPage = new LoginPage(Driver, extent);
        //    loginPage.OpenFromPage();

        //    Assert.IsTrue(loginPage.VerifyTitle);
        //    var newPage = loginPage.Login(TestData.userNames[1], TestData.password);
        //    Thread.Sleep(3000);

        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    driver.FindElement(By.LinkText("RoundTable")).Click();
        //    driver.FindElement(By.CssSelector(".follow-button-small > span")).Click();
        //    driver.FindElement(By.CssSelector(".form-control-div > input")).Click();
        //    driver.FindElement(By.CssSelector(".form-control-div > input")).SendKeys("Test RT 1 ");
        //    driver.FindElement(By.CssSelector("textarea")).Click();
        //    driver.FindElement(By.CssSelector("textarea")).SendKeys("This is test roundtable");
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


        //    driver.FindElement(By.CssSelector(".btn")).SendKeys(Keys.Enter);
        //    Thread.Sleep(3000);

        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

        //    driver.FindElement(By.CssSelector(".px-3 > h6")).Click();
        //    driver.FindElement(By.CssSelector(".introCount:nth-child(3) > textarea")).Click();
        //    driver.FindElement(By.CssSelector(".introCount:nth-child(3) > textarea")).SendKeys("Ram is moderator");
        //    driver.FindElement(By.CssSelector("div:nth-child(6) .css-ackcql")).Click();
        //    driver.FindElement(By.CssSelector("#react-select-7-option-0 .px-3")).Click();
        //    driver.FindElement(By.CssSelector(".addpanelistbtn")).Click();
        //    driver.FindElement(By.CssSelector(".btn")).Click();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        //    driver.FindElement(By.CssSelector("div:nth-child(2) > .form-control-div > input")).SendKeys("politics");
        //    driver.FindElement(By.CssSelector("div:nth-child(2) > .form-control-div > input")).SendKeys(Keys.Enter);
        //    driver.FindElement(By.CssSelector("div:nth-child(4) > .form-control-div > input")).Click();
        //    driver.FindElement(By.CssSelector("div:nth-child(4) > .form-control-div > input")).SendKeys("public rt");
        //    driver.FindElement(By.CssSelector("div:nth-child(4) > .form-control-div > input")).SendKeys(Keys.Enter);
        //    driver.FindElement(By.CssSelector(".btn")).Click();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        //    driver.FindElement(By.CssSelector(".follow_detail:nth-child(3) span")).Click();
        //    driver.FindElement(By.CssSelector(".btn")).Click();
        //    js.ExecuteScript("window.scrollTo(0,0)");
        //    driver.FindElement(By.CssSelector(".proceed_btn")).Click();
        //    js.ExecuteScript("window.scrollTo(0,0)");

        //}
        [Test]

        public void Roundtable()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[5], TestData.password1);
            Thread.Sleep(3000);
        }


        [Test]
        public void CreatePublicRoundTable1()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[5], TestData.password1);
            Thread.Sleep(3000);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.LinkText("RoundTable")).Click();
            var currentULR = driver.Url;
            Assert.That(currentULR, Is.EqualTo("https://jitsi.konsultera.co.in/roundtable/listing"));
            driver.FindElement(By.CssSelector(".follow-button-small > span")).Click();
            driver.FindElement(By.CssSelector(".form-control-div > input")).Click();
            driver.FindElement(By.CssSelector(".form-control-div > input")).SendKeys("Test RT 1 ");
            driver.FindElement(By.CssSelector("textarea")).Click();
            driver.FindElement(By.CssSelector("textarea")).SendKeys("This is test roundtable");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.CssSelector("button.MuiButtonBase-root:nth-child(1)")).SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.CssSelector("div.css-mvmu1r:nth-child(5) > div:nth-child(4) > button:nth-child(1)")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            IWebElement autorec = Driver.FindElement(By.CssSelector(".switch"));
            Thread.Sleep(2000);
            autorec.Click();
            Thread.Sleep(2000);
            IWebElement starttime = driver.FindElement(By.XPath("//div[@id=\'root\']/div/div[2]/section[2]/section/div[6]/div/div[2]/div/div/div/div/div[2]"));
            var script1 = "arguments[0].scrollIntoView(true);";
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
            js1.ExecuteScript(script1, starttime);
            Thread.Sleep(2000);
            //start time hour selection
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[6]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]")).Click();
            driver.FindElement(By.XPath("//div[2]/div/div[3]")).Click();
            //start time minute selection
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[6]/div[1]/div[2]/div[2]/div[1]")).Click();
            driver.FindElement(By.XPath("//div[2]/div/div[3]")).Click();
            Thread.Sleep(2000);
            //PM to AM selection
            //driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[6]/div[1]/div[2]/div[3]/h6[1]")).Click();
            //end time hour selection
            driver.FindElement(By.XPath("//div[@id=\'root\']/div/div[2]/section[2]/section/div[6]/div[2]/div[2]/div/div/div/div/div/div[2]")).Click();
            driver.FindElement(By.XPath("//div[2]/div/div[4]")).Click();
            //end time minute selection
            driver.FindElement(By.XPath("//div[@id=\'root\']/div/div[2]/section[2]/section/div[6]/div[2]/div[2]/div/div[2]/div/div/div/div[2]")).Click();
            driver.FindElement(By.XPath("//div[2]/div/div[3]")).Click();
            Thread.Sleep(2000);
            //PM to AM selection
            //driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[6]/div[2]/div[2]/div[1]/div[3]/h6[1]")).Click();
            //check box click
            IWebElement checkBtn = driver.FindElement(By.XPath("//div[@id='root']/div/div[2]/section[2]/section/div[9]/input"));
            var script = "arguments[0].scrollIntoView(true);";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script, checkBtn);
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".mb-4 > input")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".btn")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            IWebElement Mod = driver.FindElement(By.Id("react-select-6-input"));
            Mod.SendKeys("TestUser15");
            Thread.Sleep(2000);
            Mod.SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.CssSelector(".introCount:nth-child(3) > textarea")).SendKeys("TestUser15 is moderator");
            IWebElement panelist = driver.FindElement(By.Id("react-select-7-input"));
            panelist.SendKeys("testKhulke");
            Thread.Sleep(2000);
            panelist.SendKeys(Keys.Enter);
            IWebElement panintro = driver.FindElement(By.CssSelector("div.introCount:nth-child(7) > textarea:nth-child(1)"));
            panintro.SendKeys("testKhulke is panelist");
            driver.FindElement(By.CssSelector(".addpanelistbtn")).SendKeys(Keys.Enter);
            driver.FindElement(By.CssSelector(".btn")).SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[2]/div[1]/div[1]/input[1]")).SendKeys("politics");
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[2]/div[1]/button[1]")).Click();
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[4]/div[1]/div[1]/input[1]")).Click();
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[4]/div[1]/div[1]/input[1]")).SendKeys("public rt");
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[4]/div[1]/button[1]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@accept='image/*']")).SendKeys(@"C:\UIAutomationAssets\Image1.jpg");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@accept='.doc,.docx,.pdf,.xlsx,.xls,.ppt,.pptx']")).SendKeys(@"C:\UIAutomationAssets\uploadexel.xlsx");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[contains(text(),'CONTINUE')]")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("(//img[@class='p-2'])[2]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("(//img[@class='p-2'])[3]")).Click();
            driver.FindElement(By.XPath("(//input[@type='checkbox'])[1]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".MuiDialogActions-root > button:nth-child(1)")).Click();
            IWebElement inv = driver.FindElement(By.CssSelector("#react-select-8-input"));
            inv.Click();
            Thread.Sleep(4000);
            inv.SendKeys("radhikayewale");
            Thread.Sleep(2000);
            inv.SendKeys(Keys.Enter);
            IWebElement invmob = driver.FindElement(By.XPath("//input[@placeholder='Add Mobile or Email ID to invite']"));
            invmob.Click();
            invmob.SendKeys("cofrufroyofei-9317@yopmail.com");
            Thread.Sleep(2000);
            invmob.SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("//button[@class='btn primary-btn-blk']")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            //to discard roundtable
            //driver.FindElement(By.CssSelector("#root > div > div.sc-dkaWRx.kTMoQF > section > section > section > div:nth-child(18) > button.sc-fiKUBa.gSzYF")).SendKeys(Keys.Enter);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //driver.FindElement(By.CssSelector("body > div.MuiModal-root.MuiDialog-root.css-126xj0f > div.MuiDialog-container.MuiDialog-scrollPaper.css-ekeie0 > div > div > div > h6 > div > button.sc-fiKUBa.gSzYF")).SendKeys(Keys.Enter);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //Thread.Sleep(3000);
            //js.ExecuteScript("window.scrollTo(0,0)");
            driver.FindElement(By.XPath("//button[@class='proceed_btn']")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            IWebElement errormessageID = driver.FindElement(By.XPath("//h2[contains(text(),'Awesome!')]"));
            string errormessage = errormessageID.Text;
            Assert.That(errormessage, Is.EqualTo("Awesome!"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //to delete roundtable
            //driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/section/section/div[2]/button")).SendKeys(Keys.Enter);
            //driver.FindElement(By.LinkText("RoundTable")).Click();
            //Thread.Sleep(3000);
            //driver.FindElement(By.CssSelector("button.MuiButtonBase-root:nth-child(1)")).Click();
            //Thread.Sleep(2000);
            //driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div[2]/div/div[1]/div/div")).Click();
            //Thread.Sleep(3000);
            //IWebElement Delbtn = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/section/section/section/div[12]/button"));
            //var script2 = "arguments[0].scrollIntoView(true);";
            //IJavaScriptExecutor js2 = (IJavaScriptExecutor)driver;
            //js2.ExecuteScript(script2, Delbtn);
            //Delbtn.SendKeys(Keys.Enter);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //driver.FindElement(By.CssSelector("div.justify-content-between:nth-child(2) > button:nth-child(1)")).Click();
            //js.ExecuteScript("window.scrollTo(0,0)");

        }

        [Test]

        public void CreatePrivateRT()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[5], TestData.password1);
            Thread.Sleep(3000);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.LinkText("RoundTable")).Click();
            var currentULR = driver.Url;
            Assert.That(currentULR, Is.EqualTo("https://jitsi.konsultera.co.in/roundtable/listing"));
            driver.FindElement(By.CssSelector(".follow-button-small > span")).Click();
            driver.FindElement(By.CssSelector(".form-control-div > input")).Click();
            driver.FindElement(By.CssSelector(".form-control-div > input")).SendKeys("Test RT 1 ");
            driver.FindElement(By.CssSelector("textarea")).Click();
            driver.FindElement(By.CssSelector("textarea")).SendKeys("This is test roundtable");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.CssSelector("button.MuiButtonBase-root:nth-child(1)")).SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.CssSelector("div.css-mvmu1r:nth-child(5) > div:nth-child(4) > button:nth-child(1)")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            IWebElement autorec = Driver.FindElement(By.CssSelector(".switch"));
            Thread.Sleep(2000);
            autorec.Click();
            Thread.Sleep(2000);
            IWebElement starttime = driver.FindElement(By.XPath("//div[@id=\'root\']/div/div[2]/section[2]/section/div[6]/div/div[2]/div/div/div/div/div[2]"));
            var script1 = "arguments[0].scrollIntoView(true);";
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
            js1.ExecuteScript(script1, starttime);
            Thread.Sleep(2000);
            //start time hour selection
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[6]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]")).Click();
            driver.FindElement(By.XPath("//div[2]/div/div[3]")).Click();
            //start time minute selection
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[6]/div[1]/div[2]/div[2]/div[1]")).Click();
            driver.FindElement(By.XPath("//div[2]/div/div[3]")).Click();
            Thread.Sleep(2000);
            //PM to AM selection
            //driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[6]/div[1]/div[2]/div[3]/h6[1]")).Click();
            //end time hour selection
            driver.FindElement(By.XPath("//div[@id=\'root\']/div/div[2]/section[2]/section/div[6]/div[2]/div[2]/div/div/div/div/div/div[2]")).Click();
            driver.FindElement(By.XPath("//div[2]/div/div[4]")).Click();
            //end time minute selection
            driver.FindElement(By.XPath("//div[@id=\'root\']/div/div[2]/section[2]/section/div[6]/div[2]/div[2]/div/div[2]/div/div/div/div[2]")).Click();
            driver.FindElement(By.XPath("//div[2]/div/div[3]")).Click();
            Thread.Sleep(2000);
            //PM to AM selection
            //driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[6]/div[2]/div[2]/div[1]/div[3]/h6[1]")).Click();
            //to select private roundtable
            driver.FindElement(By.XPath("(//button[@class='torbtn'])[2]")).Click();
            //check box click
            IWebElement checkBtn = driver.FindElement(By.XPath("//div[@id='root']/div/div[2]/section[2]/section/div[9]/input"));
            var script = "arguments[0].scrollIntoView(true);";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script, checkBtn);
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".mb-4 > input")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".btn")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            IWebElement Mod = driver.FindElement(By.Id("react-select-6-input"));
            Mod.SendKeys("TestUser15");
            Thread.Sleep(2000);
            Mod.SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.CssSelector(".introCount:nth-child(3) > textarea")).SendKeys("TestUser15 is moderator");
            IWebElement panelist = driver.FindElement(By.Id("react-select-7-input"));
            panelist.SendKeys("testKhulke");
            Thread.Sleep(2000);
            panelist.SendKeys(Keys.Enter);
            IWebElement panintro = driver.FindElement(By.CssSelector("div.introCount:nth-child(7) > textarea:nth-child(1)"));
            panintro.SendKeys("testKhulke is panelist");
            driver.FindElement(By.CssSelector(".addpanelistbtn")).SendKeys(Keys.Enter);
            driver.FindElement(By.CssSelector(".btn")).SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[2]/div[1]/div[1]/input[1]")).SendKeys("politics");
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[2]/div[1]/button[1]")).Click();
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[4]/div[1]/div[1]/input[1]")).Click();
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[4]/div[1]/div[1]/input[1]")).SendKeys("public rt");
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[4]/div[1]/button[1]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@accept='image/*']")).SendKeys(@"C:\UIAutomationAssets\Image1.jpg");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@accept='.doc,.docx,.pdf,.xlsx,.xls,.ppt,.pptx']")).SendKeys(@"C:\UIAutomationAssets\uploadexel.xlsx");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[contains(text(),'CONTINUE')]")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("(//img[@class='p-2'])[2]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("(//img[@class='p-2'])[3]")).Click();
            driver.FindElement(By.XPath("(//input[@type='checkbox'])[1]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".MuiDialogActions-root > button:nth-child(1)")).Click();
            IWebElement inv = driver.FindElement(By.CssSelector("#react-select-8-input"));
            inv.Click();
            Thread.Sleep(4000);
            inv.SendKeys("radhikayewale");
            Thread.Sleep(2000);
            inv.SendKeys(Keys.Enter);
            IWebElement invmob = driver.FindElement(By.XPath("//input[@placeholder='Add Mobile or Email ID to invite']"));
            invmob.Click();
            invmob.SendKeys("cofrufroyofei-9317@yopmail.com");
            Thread.Sleep(2000);
            invmob.SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("//button[@class='btn primary-btn-blk']")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            //to discard roundtable
            //driver.FindElement(By.CssSelector("#root > div > div.sc-dkaWRx.kTMoQF > section > section > section > div:nth-child(18) > button.sc-fiKUBa.gSzYF")).SendKeys(Keys.Enter);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //driver.FindElement(By.CssSelector("body > div.MuiModal-root.MuiDialog-root.css-126xj0f > div.MuiDialog-container.MuiDialog-scrollPaper.css-ekeie0 > div > div > div > h6 > div > button.sc-fiKUBa.gSzYF")).SendKeys(Keys.Enter);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //Thread.Sleep(3000);
            //js.ExecuteScript("window.scrollTo(0,0)");
            driver.FindElement(By.XPath("//button[@class='proceed_btn']")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            IWebElement errormessageID = driver.FindElement(By.XPath("//h2[contains(text(),'Awesome!')]"));
            string errormessage = errormessageID.Text;
            Assert.That(errormessage, Is.EqualTo("Awesome!"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //to delete roundtable
            //driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/section/section/div[2]/button")).SendKeys(Keys.Enter);
            //driver.FindElement(By.LinkText("RoundTable")).Click();
            //Thread.Sleep(3000);
            //driver.FindElement(By.CssSelector("button.MuiButtonBase-root:nth-child(1)")).Click();
            //Thread.Sleep(2000);
            //driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div[2]/div/div[1]/div/div")).Click();
            //Thread.Sleep(3000);
            //IWebElement Delbtn = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/section/section/section/div[12]/button"));
            //var script2 = "arguments[0].scrollIntoView(true);";
            //IJavaScriptExecutor js2 = (IJavaScriptExecutor)driver;
            //js2.ExecuteScript(script2, Delbtn);
            //Delbtn.SendKeys(Keys.Enter);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //driver.FindElement(By.CssSelector("div.justify-content-between:nth-child(2) > button:nth-child(1)")).Click();
            //js.ExecuteScript("window.scrollTo(0,0)");

        }

        [Test]

        public void CreateConfidentialRT()
        {
            LoginPage loginPage = new LoginPage(Driver, extent);
            loginPage.OpenFromPage();

            Assert.IsTrue(loginPage.VerifyTitle);
            var newPage = loginPage.Login(TestData.userNames[5], TestData.password1);
            Thread.Sleep(3000);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.LinkText("RoundTable")).Click();
            var currentULR = driver.Url;
            Assert.That(currentULR, Is.EqualTo("https://jitsi.konsultera.co.in/roundtable/listing"));
            driver.FindElement(By.CssSelector(".follow-button-small > span")).Click();
            driver.FindElement(By.CssSelector(".form-control-div > input")).Click();
            driver.FindElement(By.CssSelector(".form-control-div > input")).SendKeys("Test RT 1 ");
            driver.FindElement(By.CssSelector("textarea")).Click();
            driver.FindElement(By.CssSelector("textarea")).SendKeys("This is test roundtable");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.CssSelector("button.MuiButtonBase-root:nth-child(1)")).SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.CssSelector("div.css-mvmu1r:nth-child(5) > div:nth-child(4) > button:nth-child(1)")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            IWebElement autorec = Driver.FindElement(By.CssSelector(".switch"));
            Thread.Sleep(2000);
            autorec.Click();
            Thread.Sleep(2000);
            IWebElement starttime = driver.FindElement(By.XPath("//div[@id=\'root\']/div/div[2]/section[2]/section/div[6]/div/div[2]/div/div/div/div/div[2]"));
            var script1 = "arguments[0].scrollIntoView(true);";
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
            js1.ExecuteScript(script1, starttime);
            Thread.Sleep(2000);
            //start time hour selection
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[6]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]")).Click();
            driver.FindElement(By.XPath("//div[2]/div/div[3]")).Click();
            //start time minute selection
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[6]/div[1]/div[2]/div[2]/div[1]")).Click();
            driver.FindElement(By.XPath("//div[2]/div/div[3]")).Click();
            Thread.Sleep(2000);
            //PM to AM selection
            //driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[6]/div[1]/div[2]/div[3]/h6[1]")).Click();
            //end time hour selection
            driver.FindElement(By.XPath("//div[@id=\'root\']/div/div[2]/section[2]/section/div[6]/div[2]/div[2]/div/div/div/div/div/div[2]")).Click();
            driver.FindElement(By.XPath("//div[2]/div/div[4]")).Click();
            //end time minute selection
            driver.FindElement(By.XPath("//div[@id=\'root\']/div/div[2]/section[2]/section/div[6]/div[2]/div[2]/div/div[2]/div/div/div/div[2]")).Click();
            driver.FindElement(By.XPath("//div[2]/div/div[3]")).Click();
            Thread.Sleep(2000);
            //PM to AM selection
            //driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[6]/div[2]/div[2]/div[1]/div[3]/h6[1]")).Click();
            //to select confidential roundtable
            driver.FindElement(By.XPath("(//button[@class='torbtn'])[3]")).Click();
            //check box click
            IWebElement checkBtn = driver.FindElement(By.XPath("//div[@id='root']/div/div[2]/section[2]/section/div[9]/input"));
            var script = "arguments[0].scrollIntoView(true);";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script, checkBtn);
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".mb-4 > input")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".btn")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            IWebElement Mod = driver.FindElement(By.Id("react-select-6-input"));
            Mod.SendKeys("TestUser15");
            Thread.Sleep(2000);
            Mod.SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.CssSelector(".introCount:nth-child(3) > textarea")).SendKeys("TestUser15 is moderator");
            IWebElement panelist = driver.FindElement(By.Id("react-select-7-input"));
            panelist.SendKeys("testKhulke");
            Thread.Sleep(2000);
            panelist.SendKeys(Keys.Enter);
            IWebElement panintro = driver.FindElement(By.CssSelector("div.introCount:nth-child(7) > textarea:nth-child(1)"));
            panintro.SendKeys("testKhulke is panelist");
            driver.FindElement(By.CssSelector(".addpanelistbtn")).SendKeys(Keys.Enter);
            driver.FindElement(By.CssSelector(".btn")).SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[2]/div[1]/div[1]/input[1]")).SendKeys("politics");
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[2]/div[1]/button[1]")).Click();
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[4]/div[1]/div[1]/input[1]")).Click();
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[4]/div[1]/div[1]/input[1]")).SendKeys("public rt");
            driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[2]/section[2]/section[1]/div[4]/div[1]/button[1]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@accept='image/*']")).SendKeys(@"C:\UIAutomationAssets\Image1.jpg");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@accept='.doc,.docx,.pdf,.xlsx,.xls,.ppt,.pptx']")).SendKeys(@"C:\UIAutomationAssets\uploadexel.xlsx");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[contains(text(),'CONTINUE')]")).SendKeys(Keys.Enter);            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("(//img[@class='p-2'])[3]")).Click();
            driver.FindElement(By.XPath("(//input[@type='checkbox'])[1]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".MuiDialogActions-root > button:nth-child(1)")).Click();
            IWebElement inv = driver.FindElement(By.CssSelector("#react-select-8-input"));
            inv.Click();
            Thread.Sleep(4000);
            inv.SendKeys("radhikayewale");
            Thread.Sleep(2000);
            inv.SendKeys(Keys.Enter);
            IWebElement invmob = driver.FindElement(By.XPath("//input[@placeholder='Add Mobile or Email ID to invite']"));
            invmob.Click();
            invmob.SendKeys("cofrufroyofei-9317@yopmail.com");
            Thread.Sleep(2000);
            invmob.SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("//button[@class='btn primary-btn-blk']")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            //to discard roundtable
            //driver.FindElement(By.CssSelector("#root > div > div.sc-dkaWRx.kTMoQF > section > section > section > div:nth-child(18) > button.sc-fiKUBa.gSzYF")).SendKeys(Keys.Enter);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //driver.FindElement(By.CssSelector("body > div.MuiModal-root.MuiDialog-root.css-126xj0f > div.MuiDialog-container.MuiDialog-scrollPaper.css-ekeie0 > div > div > div > h6 > div > button.sc-fiKUBa.gSzYF")).SendKeys(Keys.Enter);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //Thread.Sleep(3000);
            //js.ExecuteScript("window.scrollTo(0,0)");
            driver.FindElement(By.XPath("//button[@class='proceed_btn']")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            IWebElement errormessageID = driver.FindElement(By.XPath("//h2[contains(text(),'Awesome!')]"));
            string errormessage = errormessageID.Text;
            Assert.That(errormessage, Is.EqualTo("Awesome!"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //to delete roundtable
            //driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/section/section/div[2]/button")).SendKeys(Keys.Enter);
            //driver.FindElement(By.LinkText("RoundTable")).Click();
            //Thread.Sleep(3000);
            //driver.FindElement(By.CssSelector("button.MuiButtonBase-root:nth-child(1)")).Click();
            //Thread.Sleep(2000);
            //driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div[2]/div/div[1]/div/div")).Click();
            //Thread.Sleep(3000);
            //IWebElement Delbtn = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/section/section/section/div[12]/button"));
            //var script2 = "arguments[0].scrollIntoView(true);";
            //IJavaScriptExecutor js2 = (IJavaScriptExecutor)driver;
            //js2.ExecuteScript(script2, Delbtn);
            //Delbtn.SendKeys(Keys.Enter);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //driver.FindElement(By.CssSelector("div.justify-content-between:nth-child(2) > button:nth-child(1)")).Click();
            //js.ExecuteScript("window.scrollTo(0,0)");
        }

    }
}

