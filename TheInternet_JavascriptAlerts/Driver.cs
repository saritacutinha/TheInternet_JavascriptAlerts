using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheInternet_JavascriptAlerts
{
   public class Driver
    {
       
            private int pageLoadTimeout;
            private int elementDetectionTimeout;
            public IWebDriver driver;

            public Driver(string browserType)
            {
                browserType = browserType.Trim();
                pageLoadTimeout = 60;
                elementDetectionTimeout = 10;

                if (browserType.Equals("chrome"))
                {
               
                driver = new ChromeDriver();
                }
                else
                    throw new Exception("Invalid browser Type " + browserType);
            }        
            public void CloseBrowser()
            {
                driver.Close();
                driver.Quit();           
            }
            public void NavigateToUrl(string url)
            {
                url = url.Trim();
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadTimeout);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(elementDetectionTimeout);
                driver.Url = url;
            }
        }
    }

