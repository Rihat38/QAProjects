using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;


namespace BankTest.ProjectUtils.Pages
{
    class DepositSetupPage : Form
    {
        private ITextBox DepositSum =>
            ElementFactory.GetTextBox(By.Id("amount"), "Input for deposit amount");
        private ILabel DepositRate =>
            ElementFactory.GetLabel(By.Id("interest-rate"), "Deposit rate");
        private IButton AcceptButton =>
            ElementFactory.GetButton(By.Id("submit-button"), "Button for submitting deposit setup");
        public DepositSetupPage() : base(By.Id("deposit-type"), "Deposit setup page")
        {
        }

        public void SpecifyDepositAmount(int? amount)
        {
            DepositSum.ClearAndType(amount.ToString());
        }

        public bool IsDepositRateCorrect(string rate)
        {
            return DepositRate.GetText().Equals(rate);
        }

        public void ClickSubmitButton()
        {
            AcceptButton.Click();
        }
    }
}
