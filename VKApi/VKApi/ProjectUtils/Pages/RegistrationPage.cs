using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VKApi.ProjectUtils.Pages;

public class RegistrationPage : Form
{
    private ITextBox PhoneNumberTextBox =>
        ElementFactory.GetTextBox(By.XPath("//input[@id='index_email']"), "Place for phone number");
    private IButton PhoneNumberSubmit =>
        ElementFactory.GetButton(By.XPath("//*[contains(@class, 'FlatButton--primary')]/span"), "Button for phone number submit");
    
    public RegistrationPage() : base(By.XPath("//div[@class='VkIdForm__header']"), "Sign in label")
    {
    }

    public void InputPhoneNumber(string? phone)
    {
        PhoneNumberTextBox.ClearAndType(phone);
    }
    
    public void SubmitPhoneNumber()
    {
        PhoneNumberSubmit.ClickAndWait();
    }
}