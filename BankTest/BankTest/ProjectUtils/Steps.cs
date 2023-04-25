using Aquality.Selenium.Browsers;
using BankTest.Configuration;
using BankTest.ProjectUtils.Pages;
using BankTest.TestingData;

namespace BankTest.ProjectUtils
{
    class Steps
    {
        private static TestData _testData;
        private static TestData GetTestData
        {
            get
            {
                if (_testData == null)
                    _testData = JsonBinderUtilities.TestDataBinder()!;
                return _testData;
            }
        }

        public static void AuthorizeStep()
        {
            var authPage = new AuthorizationPage();
            authPage.InputLogin(GetTestData.Login!);
            authPage.InputPassword(GetTestData.Password!);
            authPage.ClickLoginButton();
        }

        public static void AuthenticateStep() 
        { 
            var authPage = new AuthenticationPage();
            authPage.InputOtpCode(GetTestData.OtpCode!);
            authPage.SendOtpCode();
        }

        public static void ChoiceOptionStep()
        {
            var depositCreatingPage = new DepositCreatingPage();
            depositCreatingPage.ChooseRublesCurrency();
            depositCreatingPage.ChoosePeriodOneMonth();
        }

        public static void SpecifyDepositAmount()
        {
            var depositSetupPage = new DepositSetupPage();
            depositSetupPage.SpecifyDepositAmount(GetTestData.DepositAmount);
        }

        public static void AcceptAgreements()
        {
            var depositInfoPage = new DepositInfoPage();
            depositInfoPage.ConfirmRulesCheckBox();
            depositInfoPage.ConfirmStatementCheckBox();
        }
    }
}
