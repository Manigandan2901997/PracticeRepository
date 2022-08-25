//using NLog;
using OpenQA.Selenium;
using System.Threading;

namespace AutomationFramework.Pages
{
    internal class RoundTablePage
    {
        //private static Logger loggerObj = LogManager.GetCurrentClassLogger();
       
        public IWebDriver Driver { get; set; }

        public IWebElement RoundtableLink => Driver.FindElement(By.LinkText("RoundTable"));
        public IWebElement PastRoundtableTab => Driver.FindElement(By.XPath("//button[contains(.,'Past')]"));
        public IWebElement NotificationLink => Driver.FindElement(By.LinkText("Notifications"));
        
        public bool checkRoundTableLink => RoundtableLink.Displayed;
        public bool checkPastRoundTableTab => PastRoundtableTab.Displayed;

        public void NavigateToRoundTable()
        {
            RoundtableLink.Click();
            Thread.Sleep(2000);
        }
        public void NavigateToNotification()
        {
            NotificationLink.Click();
            Thread.Sleep(2000);
        }

        

    }
}
