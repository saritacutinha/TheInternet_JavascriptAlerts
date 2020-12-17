using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace TheInternet_JavascriptAlerts
{
    public class Alert_Test : BaseTest
    {
        private JavaScriptAlertPage jsAlertPage;

        [SetUp]
        public void Setup()
        {
            jsAlertPage = new JavaScriptAlertPage(_driver.driver);

        }

        [Test]
        public void ClickToGetJSAlert_AlertShouldBeDisplayed()
        {
            Assert.That(jsAlertPage.ClickForAlert(), Is.EqualTo("I am a JS Alert"));
            Assert.That(jsAlertPage.GetResultMessage(), Is.EqualTo("You successfuly clicked an alert"));
        }

        [Test]
        public void ClickToDismissJSAlert_ShouldDisplayYouClickedCancel()
        {
            Assert.That(jsAlertPage.ClickToDismiss(), Is.EqualTo("I am a JS Confirm"));
            Assert.That(jsAlertPage.GetResultMessage(), Is.EqualTo("You clicked: Cancel"));
        }
        [Test]
        public void ClickToAcceptJSAlert_ShouldDisplayYouClickedOk()
        {
            Assert.That(jsAlertPage.ClickToConfirm(), Is.EqualTo("I am a JS Confirm"));
            Assert.That(jsAlertPage.GetResultMessage(), Is.EqualTo("You clicked: Ok"));
        }

        [Test]
        [TestCase("Merry Christmas", "You entered: Merry Christmas")]
        [TestCase("", "You did not enter a message")]
        [TestCase("QQQQQQQQQQQQQQQQQQQQQQQQQQ...", "You should enter message of a specific length")]

        
        public void ClickForPrompt_ShouldDisplayPromptMessage(string message, string expectedMessage)
        {
            Assert.That(jsAlertPage.ClickForPrompt(message), Is.EqualTo("I am a JS prompt"));
            Assert.That(jsAlertPage.GetResultMessage(), Is.EqualTo(expectedMessage));           
        }

      


    }
}