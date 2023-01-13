using VKApi.Framework.Utils;
using VKApi.ProjectUtils.Pages;

namespace VKApi.ProjectUtils.Steps;

public class AuthSteps
{
    public static NewsPage SignIn()
    {
        var registrationPage = new RegistrationPage();
        Assert.That(registrationPage.State.IsDisplayed, Is.True);
        registrationPage.InputPhoneNumber(JsonBinderUtilities.TestDataBinder()?.Login!);
        registrationPage.SubmitPhoneNumber();
        var passwordPage = new PasswordPage();
        Assert.True(passwordPage.State.WaitForEnabled());
        passwordPage.InputPassword(JsonBinderUtilities.TestDataBinder()?.Password!);
        passwordPage.SubmitPassword();
        var newsPage = new NewsPage();
        Assert.True(newsPage.State.WaitForDisplayed());
        return newsPage;
    }
}