using Aquality.Selenium.Browsers;
using BankTest.Configuration;
using BankTest.ProjectUtils;
using BankTest.TestingData;

namespace BankTest.TestCases;

public class BaseTest
{
    protected static Browser? Browser;
    protected static readonly Config Config = JsonBinderUtilities.ConfigBinder()!;
    protected static readonly TestData TestData = JsonBinderUtilities.TestDataBinder()!;

    [SetUp]
    public void Setup()
    {
        Environment.SetEnvironmentVariable("driverSettings.chrome.options.intl.accept_languages", Config.Lang);
        Browser = AqualityServices.Browser;
        Browser.Maximize();
    }

    [TearDown]
    public void TearDown()
    {
        Browser?.Quit();
    }
}