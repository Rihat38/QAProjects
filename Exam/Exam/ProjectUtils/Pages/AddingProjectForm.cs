using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Exam.ProjectUtils.Pages;

public class AddingProjectForm : Form
{
    private ILabel ModalTitle =>
        ElementFactory.GetLabel(By.ClassName("modal-title"), "Modal form title");
    private ITextBox ProjectNameInput =>
        ElementFactory.GetTextBox(By.XPath("//input[@class='form-control']"), "Place for project name");
    private IButton SaveProjectButton =>
        ElementFactory.GetButton(By.XPath("//div[@class='form-group']/following-sibling::button"),
            "Button for saving project name");
    private ILabel SuccessAlert =>
        ElementFactory.GetLabel(By.XPath("//div[contains(@class, 'alert-succes')]"), "Successful save alert");

    public AddingProjectForm() : base(By.XPath("//*[@class='modal-title']"), "Modal frame for adding new project")
    {
    }

    public void InputNewProjectName(string name)
    {
        ProjectNameInput.SendKeys(name);
    }

    public bool IsSuccessfulSaveAlertAppeared()
    {
        return SuccessAlert.State.WaitForDisplayed();
    }

    public void SaveNewProjectName()
    {
        SaveProjectButton.Click();
    }
}