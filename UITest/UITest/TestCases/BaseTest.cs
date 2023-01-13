using Aquality.Selenium.Browsers;
using NUnit.Framework;

namespace UITest.TestCases;

public class BaseTest
{
    private static Browser? _browser;

    [SetUp]
    public void Setup()
    {
        _browser = AqualityServices.Browser;
        _browser.Maximize();
    }

    [TearDown]
    public void TearDown()
    {
        _browser?.Quit();
    }
}