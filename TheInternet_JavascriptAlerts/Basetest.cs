using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheInternet_JavascriptAlerts
{
    public class BaseTest
    {
        protected Driver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new Driver("chrome");
            _driver.NavigateToUrl("http://the-internet.herokuapp.com/javascript_alerts");
        }

        [TearDown]
        public void CloseBrowser()
        {
            if (_driver != null)
            {
                _driver.CloseBrowser();
            }
                
        }
    }
}
