using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace BankTest.ProjectUtils.Pages
{
    class AuthorizationPage : Form
    {
        private ITextBox LoginInput =>
            ElementFactory.GetTextBox(By.Name("username"), "Place for project name");
        private ITextBox PasswordInput =>
            ElementFactory.GetTextBox(By.Name("password"), "Place for project name");
        private IButton LoginButton =>
             ElementFactory.GetButton(By.Id("login-button"), "Button for loginnig");

        public AuthorizationPage() : base(By.Id("login-form"), "Login form")
        {
        }

        public void InputLogin(string name)
        {
            LoginInput.ClearAndType(name);
        }

        public void InputPassword(string password)
        {
            PasswordInput.ClearAndType(password);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }
    }
}
