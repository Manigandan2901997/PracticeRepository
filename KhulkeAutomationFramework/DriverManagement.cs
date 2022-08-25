﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace AutomationFramework
{
    public class DriverManagement
    {
        public static IWebDriver GetChromeDriver()
        {
            var outputDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputDir + @"\Utilities");
        }

        public static IWebDriver GetFireFoxDriver()
        {
            throw new NotImplementedException();
        }

        public static IWebDriver GetIEDriver()
        {
            throw new NotImplementedException();
        }

        public static void MaximizeBrowser(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }

        public static void KillDriver(IWebDriver driver)
        {
            driver.Close();
            driver.Quit();
        }
    }
}