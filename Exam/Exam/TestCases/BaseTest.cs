using Aquality.Selenium.Browsers;
using Exam.Configuration;
using Exam.Framework;
using Exam.ProjectUtils;
using Exam.TestingData;

namespace Exam.TestCases;

public class BaseTest
{
    protected static Browser? Browser;
    protected static readonly Config Config = JsonBinderUtilities.ConfigBinder()!; 
    protected static readonly TestData TestData = JsonBinderUtilities.TestDataBinder()!;
    protected static string? _startTime;

    [SetUp]
    public void Setup()
    {
        _startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Environment.SetEnvironmentVariable("browserName", Config.BrowserName);
        Browser = AqualityServices.Browser;
        Browser.Maximize();
    }

    [TearDown]
    public void TearDown()
    {
        Browser?.Quit();
        DbUtils.DisposeDbConnection();
    }
}