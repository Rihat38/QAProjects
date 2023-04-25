using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace BankTest.ProjectUtils.Pages
{
    class DepositPage : Form
    {
        private IButton OpenDepositButton =>
            ElementFactory.GetButton(By.Id("btn-show-rates"), "Open deposite button");

        private ILabel DepositsHistory =>
            ElementFactory.GetLabel(By.Id("deposits"), "Deposits gistory");

        public DepositPage() : base(By.XPath("//div[contains(@class, 'deposits-index') and contains(@class, 'content ') ] "), "Deposit page")
        {
        }

        public bool IsDepositOpeningButtonDisplayed()
        {
            return OpenDepositButton.State.WaitForDisplayed();
        }

        public bool IsDepositHistoryDisplayed()
        {
            return OpenDepositButton.State.WaitForDisplayed();
        }

        public void ClickOpenDepositButton()
        {
            OpenDepositButton.Click();
        }
    }
}
