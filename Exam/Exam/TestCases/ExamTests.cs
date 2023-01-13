using Exam.Framework;
using Exam.ProjectUtils;
using Exam.ProjectUtils.Api;
using Exam.ProjectUtils.Database;
using Exam.ProjectUtils.Pages;
using Microsoft.IdentityModel.Tokens;
using SoftAssertion;

namespace Exam.TestCases;

public class ExamTests : BaseTest
{
    [Test]
    public void TestingReportingUnionWeb()
    {
        var softAssertion= new SoftAssert();
        
        Config.AccessToken = ApiUtils.GetAccessToken(Endpoints.TokenGet);
        Assert.NotNull(Config.AccessToken, "Access token was not received");

        Browser!.GoTo(Config.AppUrl);
        Steps.AuthStep(Browser);
        Steps.AddToken(Browser, Config.AccessToken!);
        var projectPage = new AllProjectsPage();
        Assert.That(projectPage.State.WaitForDisplayed(), Is.True, "Start page didn't load");
        Assert.That(Config.Variant, Is.EqualTo(projectPage.GetVariantNumber()), "Wrong variant displayed");
        
        projectPage.GoToProjectPage("Nexage");
        var nexagePage = new ProjectPage();
        Assert.That(nexagePage.State.WaitForDisplayed(), Is.True, "Nexage project tests page did not open");
        Assert.That(Utils.IsDateValuesInDescendingOrder(nexagePage.GetTestsDate()), Is.True, "Tests not sorted");
        var tests = ProjDbUtils.ReadNexageTests();
        softAssertion.True(nexagePage.IsTestNamesFromSiteEqualsTestNamesFromDb(tests));
        Browser.Driver.Navigate().Back();
        
        var randomProjectName = RandomUtils.RandomString(5);
        projectPage.ClickOnAddNewProject();
        Steps.AddNewProject(Browser, randomProjectName);
        Assert.That(projectPage.IsProjectExistInList(randomProjectName), Is.True, "The new test did not appear in the list");

        projectPage.GoToProjectPage(randomProjectName);
        var newlyAddedProjectPage = new ProjectPage();
        var currentTest = Steps.AddTestToNewProject(randomProjectName, Browser, TestData, _startTime!);
        Assert.That(newlyAddedProjectPage.GetLastTestName(), Is.EqualTo(TestContext.CurrentContext.Test.ClassName),
            "Test didn't show up");

        newlyAddedProjectPage.GoToLastTestInList();
        var detailedInformation = new DetailedTestInformationPage();
        var testFromSite = detailedInformation.MergeValuesFromPageIntoModel(Config);
        var comparisonResult = currentTest.DetailedCompare(testFromSite);
        Assert.True(comparisonResult.IsNullOrEmpty(), "The models differ in some values");
        Assert.That(detailedInformation.GetLogsFromSite(), Is.EqualTo(TestData.LoggerImitation), "Logs are displayed incorrectly");
        
        softAssertion.VerifyAll();
    }
}