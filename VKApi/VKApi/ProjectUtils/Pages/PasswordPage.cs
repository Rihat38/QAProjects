using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VKApi.ProjectUtils.Pages;

public class PasswordPage : Form
{
    private ITextBox PasswordTextBox =>
        ElementFactory.GetTextBox(By.XPath("//div[@class='vkc__Password__Wrapper']//input"), "Place for password");
    private IButton PasswordSubmitButton =>
        ElementFactory.GetButton(By.XPath("//*[@class='vkuiButton__in']"), "Password submit button");
    
    public PasswordPage() : base(By.XPath("//div[contains(@class,'vkc__AuthRoot__root')]"), "Password input form")
    {
    }

    public void InputPassword(string? password)
    {
        PasswordTextBox.ClearAndType(password);
    }

    public void SubmitPassword()
    {
        PasswordSubmitButton.ClickAndWait();
    }
}