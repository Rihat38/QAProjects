using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace BankTest.ProjectUtils.Pages
{
    class AuthenticationPage : Form
    {
        private ITextBox OtpCodeInput =>
            ElementFactory.GetTextBox(By.Id("otp-code"), "OTP code input");
        private IButton OtpCodeSendButton =>
             ElementFactory.GetButton(By.Id("login-otp-button"), "Button for sending otp-code");

        public AuthenticationPage() : base(By.Id("otp-code"), "OTP code input")
        {
        }

        public void InputOtpCode(string code)
        {
            OtpCodeInput.ClearAndType(code);
        }

        public void SendOtpCode()
        {
            OtpCodeSendButton.Click();
        }
    }
}
