using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using Exam.Configuration;
using Exam.Framework;
using Exam.ProjectUtils.Database;
using Exam.ProjectUtils.Models;
using OpenQA.Selenium;

namespace Exam.ProjectUtils.Pages;

public class DetailedTestInformationPage : Form
{
    private ILabel ProjectName =>
        ElementFactory.GetLabel(By.XPath("//*[text()='Project name']/following-sibling::p"), "Project name");
    private ILabel TestName =>
        ElementFactory.GetLabel(By.XPath("//*[text()='Test name']/following-sibling::p"), "Project name");
    private ILabel TestMethodName =>
        ElementFactory.GetLabel(By.XPath("//*[text()='Test method name']/following-sibling::p"), "Project name");
    private ILabel Status =>
        ElementFactory.GetLabel(By.XPath("//*[text()='Status']/following-sibling::p/*"), "Project name");
    private ILabel StartTime =>
        ElementFactory.GetLabel(By.XPath("//*[text()='Time info']/following-sibling::*"), "Project name");
    private ILabel Environment =>
        ElementFactory.GetLabel(By.XPath("//*[text()='Environment']/following-sibling::*"), "Project name");
    private ILabel BrowserName =>
        ElementFactory.GetLabel(By.XPath("//*[text()='Browser']/following-sibling::*"), "Project name");
    private ILabel AuthorName =>
        ElementFactory.GetLabel(By.XPath("//*[text()='Developer info']/following-sibling::*"), "Project name");
    private ILabel TestScreenshotLink =>
        ElementFactory.GetLabel(By.XPath("//img[@class='thumbnail']/parent::a"), "Test screenshot");
    private ILabel TestLogs =>
        ElementFactory.GetLabel(By.XPath("//table[@class='table']//td"), "Test logs");
    
    public DetailedTestInformationPage() : base(By.XPath("//div[@class='col-md-8']"), "Log and attachment info")
    {
    }
    
    public string GetScreenshotLink()
    {
        return TestScreenshotLink.GetAttribute("href");
    }

    private string GetStartTimeInGeneralFormat()
    {
        return StartTime.Text[12..^2];
    }

    public string GetAuthorInGeneralFormat()
    {
        return AuthorName.Text[6..];
    }

    public string GetLogsFromSite()
    {
        return TestLogs.Text;
    }

    public Test MergeValuesFromPageIntoModel(Config config)
    {
        return ProjDbUtils.CreateTestModel(ProjectName.Text, TestName.Text, TestMethodName.Text, Status.Text.ToUpper(),
            GetStartTimeInGeneralFormat(), Environment.Text, BrowserName.Text, GetAuthorInGeneralFormat(), config);
    }
}