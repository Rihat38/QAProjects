using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Exam.ProjectUtils.Pages;

public class AllProjectsPage : Form
{
    private const string ProjectXPath = "//a[text() = '{0}']";
    private IButton AddProjectButton =>
        ElementFactory.GetButton(By.XPath("//button[contains(@class, 'pull-right')]"), "Add project button");

    private ILabel VariantNumber =>
        ElementFactory.GetLabel(By.XPath("//p[contains(@class, 'footer-text')]/span"), "Variant number");
    
    public AllProjectsPage() : base(By.XPath("//div[@class='list-group']"), "List of projects")
    {
    }

    public void GoToProjectPage(string testProjectName)
    {
        ElementFactory.GetButton(By.XPath(String.Format(ProjectXPath, testProjectName)), "Test project button").Click();
    }

    public bool IsProjectExistInList(string testProjectName)
    {
        return ElementFactory.GetButton(By.XPath(String.Format(ProjectXPath, testProjectName)),
                "Test project button").State.WaitForDisplayed();
    }

    public int GetVariantNumber()
    {
        return int.Parse(VariantNumber.Text[^1].ToString());
    }

    public void ClickOnAddNewProject()
    {
        AddProjectButton.WaitAndClick();
    }
}