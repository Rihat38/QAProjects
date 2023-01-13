using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using UITest.Utilities;

namespace UITest.Pages;

public class LoginCardForm : Form
{
    private ITextBox password =>
        ElementFactory.GetTextBox(By.XPath("//div[@class='login-form__field-row']//*"), "Password");
    private ITextBox email =>
        ElementFactory.GetTextBox(By.XPath("//input[@placeholder='Your email']"), "Email");
    private ITextBox domain => 
        ElementFactory.GetTextBox(By.XPath("//input[@placeholder='Domain']"), "Domain");
    private IButton endingOfEmail =>
        ElementFactory.GetButton(By.XPath("//div[@class='dropdown__header']"), "End Of Email Header");
    private IButton dropdownList =>
        ElementFactory.GetButton(By.XPath("//div[@class='dropdown__list-item']"), "End Of Email Dropdown List");
    private ICheckBox acceptingCheckBox => ElementFactory.GetCheckBox(By.XPath("//span[@class='checkbox__box']"),
        "Check box of Terms and Conditions");
    private IButton nextButton =>
        ElementFactory.GetButton(By.XPath("//*[@class='button--secondary']"), "Button for step to next card");
    
    public LoginCardForm() : base(By.XPath("//div[@class='login-form__field-row']"), "First card")
    {
    }
    
    public void FillRegForm(string passwordText, string emailText, string domainText)
    {
        password.ClearAndType(passwordText);
        email.ClearAndType(emailText);
        domain.ClearAndType(domainText);
        endingOfEmail.Click();
        dropdownList.WaitAndClick();
    }
    public void AcceptTermsAndCond()
    {
        acceptingCheckBox.Click();
    }

    public void GoToSecondCard()
    {
        nextButton.ClickAndWait();
    }
}