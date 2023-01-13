using Aquality.Selenium.Browsers;
using NUnit.Framework;
using UITest.Pages;
using UITest.Utilities;
using static UITest.Steps.Steps;

namespace UITest.TestCases
{
    public class CreateAccountTest : BaseTest
    {
        private const string Avatar = @"\TestData\avatar.jpg";
        private static readonly Browser _browser = AqualityServices.Browser;
        
        [Test]
        public void Test()
        {
            _browser.GoTo(JsonBinderUtilities.ConfigBinder()?.AppUrl);
            var startPage = new StartPage();
            Assert.True(startPage.State.IsDisplayed, "Not a start page");
            startPage.GoToGamePage();
            var gamePage = new GamePage();
            Assert.True(gamePage.LoginCardForm.State.IsDisplayed, "Card number is not 1");
            var sameLetter = RandomUtilities.GetRandomString(1).ToUpper();
            var password = sameLetter + Utilities.Utilities.CreateRandomPassword(8) +
                           RandomUtilities.GetRandomInteger(1, 9);
            var emailName = sameLetter + Utilities.Utilities.CreateRandomEmailName(5);
            var domain = Utilities.Utilities.CreateRandomDomain(5);
            FirstLoginStep(password, emailName, domain);
            Assert.True(gamePage.InformationCardForm.State.IsDisplayed, "Card number is not 2");
            SecondLoginStep(Avatar);
            Assert.True(gamePage.ThirdCard.State.IsDisplayed, "Card number is not 3");
        }
    }
}