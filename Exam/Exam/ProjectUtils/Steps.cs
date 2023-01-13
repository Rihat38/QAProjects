using Aquality.Selenium.Browsers;
using Exam.Configuration;
using Exam.Framework;
using Exam.ProjectUtils.Database;
using Exam.ProjectUtils.Models;
using Exam.ProjectUtils.Pages;
using Exam.TestingData;
using OpenQA.Selenium;

namespace Exam.ProjectUtils;

public static class Steps
{
    private static Config _config;
    private static Config GetConfig
    {
        get
        {
            if (_config == null)
                _config = JsonBinderUtilities.ConfigBinder()!;
            return _config;
        }
    }
    
    public static void AuthStep(Browser browser)
    {
        browser.GoTo(GetConfig.AuthAppUrl);
    }

    public static void AddToken(Browser browser, string token)
    {
        browser.Driver.Manage().Cookies.AddCookie(new Cookie("token", token));
        browser.Driver.Navigate().Refresh();
    }

    public static void AddNewProject(Browser browser, string projName)
    {
        var addingProjectForm = new AddingProjectForm();
        browser.Driver.SwitchTo().Frame("addProjectFrame");
        addingProjectForm.InputNewProjectName(projName);
        addingProjectForm.SaveNewProjectName();
        Assert.That(addingProjectForm.IsSuccessfulSaveAlertAppeared(), Is.True, "Successful save alert not showing up");
        browser.Driver.SwitchTo().DefaultContent();
        browser.Driver.ExecuteScript("closePopUp()");
        Assert.That(addingProjectForm.State.WaitForNotDisplayed(), Is.True, "Alert didn't disappear");
        browser.Refresh();
    }

    public static Test AddTestToNewProject(string projectName, Browser browser, TestData testData, string startTime)
    {
        DriverUtils.TakeAndSafeScreenshot(browser);
        ProjDbUtils.CreateNewAuthor(_config, _config.YourLogin, _config.YourEmail);
        var test = ProjDbUtils.CreateTestReport(projectName,"PASSED", _config, startTime);
        ProjDbUtils.CreateNewLogReport(testData, startTime);
        ProjDbUtils.AddScreenshotForTest(startTime);
        return test;
    }
}