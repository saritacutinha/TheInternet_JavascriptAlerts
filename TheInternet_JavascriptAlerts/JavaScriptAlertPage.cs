using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheInternet_JavascriptAlerts
{
    public class JavaScriptAlertPage
    {
        private IWebDriver _driver;
        public IAlert alert;

        public JavaScriptAlertPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement JSAlert => _driver.FindElement(By.XPath("//div[@class='example']/ul/li/button"));
        public IWebElement JSConfirm => _driver.FindElement(By.XPath("//div[@class='example']/ul/li[2]/button"));
        public IWebElement JSPrompt => _driver.FindElement(By.XPath("//div[@class='example']/ul/li[3]/button"));
        public IWebElement Result => _driver.FindElement(By.Id("result"));

        public string GetResultMessage()
        {
            return Result.Text;
        }

        public string ClickForAlert()
        {
            JSAlert.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
            string text = alert.Text;
            alert.Accept();
            return text;
        }

        public string ClickToDismiss()
        {
            JSConfirm.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.AlertIsPresent());

            IAlert alert = _driver.SwitchTo().Alert();
            string text = alert.Text;
            alert.Dismiss();
            return text;
        }

        public string ClickToConfirm()
        {
            JSConfirm.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.AlertIsPresent());

            IAlert alert = _driver.SwitchTo().Alert();
            string text = alert.Text;
            alert.Accept();
            return text;
        }

        public string ClickForPrompt(string message)
        {
            JSPrompt.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
            string text = alert.Text;
            alert.SendKeys(message);
            alert.Accept();
            return text;
        }
    }
}
