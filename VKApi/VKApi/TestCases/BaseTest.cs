using Aquality.Selenium.Browsers;
using Aquality.Selenium.Configurations.WebDriverSettings;
using VKApi.Configuration;
using VKApi.TestingData;
using VKApi.Framework.Utils;

namespace VKApi.TestCases;

public class BaseTest
{
    protected static Browser? Browser;
    protected static readonly Config Config = JsonBinderUtilities.ConfigBinder()!; 
    protected static readonly TestData TestData = JsonBinderUtilities.TestDataBinder()!; 
    
    [SetUp]
    public void Setup()
    {
        Environment.SetEnvironmentVariable("browserName", Config.BrowserName);
        Browser = AqualityServices.Browser;
        Browser.Maximize();
    }

    [TearDown]
    public void TearDown()
    {
        Browser?.Quit();
    }
}