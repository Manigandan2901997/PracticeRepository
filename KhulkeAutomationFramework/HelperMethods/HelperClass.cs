using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.HelperMethods
{
    internal class HelperClass
    {
        public static object SeleniumExtras { get; private set; }

        //IWebDriver Driver;

        //private bool IsElementPresent(IWebDriver driver, By by)
        //{
        //    try
        //    {
        //        driver.FindElement(by);
        //        return true;
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        return false;
        //    }
        //}

        public static bool IsAlertShown(WebDriver driver)
        {
            try
            {
                driver.SwitchTo().Alert();
            }
            catch (NoAlertPresentException e)
            {
                return false;
            }
            return true;
        }

        //public static IWebElement WaitForElement(WebDriver driver, string path)
        //{
        //    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //    var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(path)));
        //    return element;
        //}

        public static string GetPath(string fileName)
        {
            var dirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string sFile = System.IO.Path.Combine(dirPath, "..\\..\\..\\assets\\" + fileName);
            string sFilePath = Path.GetFullPath(sFile);
            return sFilePath;
        }

    }
}
