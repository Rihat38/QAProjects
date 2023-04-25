using BankTest.ProjectUtils.Pages;

namespace BankTest.TestCases;
public class HeaderCheckTestCase : BaseTest
{
    [Test]
    public void TestingHeaderTest()
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

        Assert.That(header.IsBankNameDisplayed(), Is.True, "Bank name is not displayed");
        Assert.That(header.IsChatButtonDisplayed(), Is.True, "Chat button is not displayedd");
        Assert.That(header.IsSettingButtonDisplayed, Is.True, "Settings button is not displayed");
        Assert.That(header.IsPersonalOffersButtonDisplayed(), Is.True, "Personal offers button is not displayed");
        Assert.That(header.IsUserNameDisplayed(), Is.True, "User name is not displayed");
        Assert.That(header.IsBankContactsButtonDisplayed(), Is.True, "Bank contacts button is not displayed");
        Assert.That(header.IsLanguageSwitcherButtonDisplayed(), Is.True, "Language switcher is not displayed");
    }
}