using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using Exam.ProjectUtils.Models;
using OpenQA.Selenium;

namespace Exam.ProjectUtils.Pages;

public class ProjectPage : Form
{
    private IList<ITextBox> ProjectStartTimes =>
        ElementFactory.FindElements<ITextBox>(By.XPath("//table[@class='table']//td[4]"), "Times of project tests");
    private IList<ILabel> ProjectTestNames =>
        ElementFactory.FindElements<ILabel>(By.XPath("//table[@class='table']//td[1]"), "Names of project tests");
    private IButton DeteiledInformationOfLastTest =>
        ElementFactory.GetButton(By.XPath("//table[@class='table']//td//a"), "First test in list");

    public ProjectPage() : base(By.XPath("//ol[@class='breadcrumb']"), "New added page")
    {
    }
    
    public List<DateTime> GetTestsDate()
    {
        var dateList = new List<DateTime>();
        foreach (var v in ProjectStartTimes)
        {
            dateList.Add(DateTime.Parse(v.Text));
        }

        return dateList;
    }
    
    public bool IsTestNamesFromSiteEqualsTestNamesFromDb(List<Test> testsList)
    {
        var sortedTestList = testsList
            .OrderByDescending(t => t.StartTime)
            .ToList();
        
        for (int i = 0; i < ProjectTestNames.Count; i++)
        {
            if(sortedTestList[i].Name != ProjectTestNames[i].Text)
                return false;
        }
        return true;
    }

    public string GetLastTestName()
    {
        DeteiledInformationOfLastTest.State.WaitForDisplayed();
        return ProjectTestNames.First().Text;
    }
    
    public void GoToLastTestInList()
    {
        DeteiledInformationOfLastTest.ClickAndWait();
    }
}