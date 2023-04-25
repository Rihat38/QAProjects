using BankTest.Configuration;
using BankTest.ProjectUtils.Pages;

namespace BankTest.TestCases;

class DepositOpeningTestCase : BaseTest
{
    [Test]
    public void DepositOpeningTest()
    {
        Browser!.GoTo(Config.AppUrl);
        var authorizePage = new AuthorizationPage();
        Assert.That(authorizePage.State.WaitForDisplayed(), Is.True, "Authorization page didn't load");

        ProjectUtils.Steps.AuthorizeStep();
        var authenticatePage = new AuthenticationPage();
        Assert.That(authenticatePage.State.WaitForDisplayed(), Is.True, "Authentication page didn't load");

        ProjectUtils.Steps.AuthenticateStep();
        var header = new Header();
        Assert.That(header.State.WaitForDisplayed(), Is.True, "Page with header didn't load");

        var mainPage = new MainPage();
        Assert.That(mainPage.State.WaitForDisplayed(), Is.True, "Main page didn't load");
        mainPage.ClickDepositButton();
        var depositPage = new DepositPage();
        Assert.That(depositPage.State.WaitForDisplayed(), Is.True, "Deposit page didn't load");
        Assert.That(depositPage.IsDepositOpeningButtonDisplayed(), Is.True, "Button for opening deposit isn't displayed");
        Assert.That(depositPage.IsDepositHistoryDisplayed, Is.True, "Deposits history isn't displayed");
        depositPage.ClickOpenDepositButton();

        var depositCreatingPage = new DepositCreatingPage();
        Assert.That(depositCreatingPage.State.WaitForDisplayed(), Is.True, "Deposit creating page didn't load");
        depositCreatingPage.ChooseRublesCurrency();
        depositCreatingPage.ChoosePeriodOneMonth();
        depositCreatingPage.ClickOpenWinterPeterburgDepositButton();

        var depositSetupPage = new DepositSetupPage();
        Assert.That(depositSetupPage.State.WaitForDisplayed(), Is.True, "Deposit setup page didn't load");
        ProjectUtils.Steps.SpecifyDepositAmount();
        Assert.That(depositSetupPage.IsDepositRateCorrect(TestData.DepositRate!), Is.True, "Calculated rate is incorrect");
        depositSetupPage.ClickSubmitButton();

        var depositInfoPage = new DepositInfoPage();
        Assert.That(depositInfoPage.State.WaitForDisplayed(), Is.True, "Deposit info page didn't load");
        depositInfoPage.OpenTariffPdf();
        Assert.That(Browser.Driver.WindowHandles.Count == 2, Is.True, "New tab didn't open");
        Browser.Driver.SwitchTo().Window(Browser.Driver.WindowHandles[1]);
        Browser.Driver.Close();
        Browser.Driver.SwitchTo().Window(Browser.Driver.WindowHandles[0]);
        Assert.That(depositInfoPage.State.WaitForDisplayed(), Is.True, "Deposit info page didn't load");

        ProjectUtils.Steps.AcceptAgreements();
        depositInfoPage.ScrollModalWindow(Browser);
        depositInfoPage.AcceptAplication();
        depositInfoPage.ConfirmDeposit();

        header.ClickOnLogo();
        Assert.That(mainPage.State.WaitForDisplayed(), Is.True, "Main page didn't load");
    }
}
