using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;


namespace BankTest.ProjectUtils.Pages;

class DepositInfoPage : Form
{
    private IButton TariffInfo =>
        ElementFactory.GetButton(By.XPath("//a[contains(@href, 'tariff.pdf')]"), "PDF with tariff information");
    private ICheckBox RulesCheckBox =>
        ElementFactory.GetCheckBox(By.Name("condition.newDepositConditions"), "Checkbox for agreeing to the deposit rules");
    private ICheckBox StatementCheckBox =>
        ElementFactory.GetCheckBox(By.Name("condition.instantDepositAgreement"), "Checkbox for accepting a deposit");
    private IButton AcceptAplicationButton =>
        ElementFactory.GetButton(By.Id("accept-instant-deposit-agreement-button"), "Button for accepting an aplication");
    private IButton SubmitButton =>
        ElementFactory.GetButton(By.Id("confirm"), "Comfirming button");
    
    public DepositInfoPage() : base(By.ClassName("conditions-confirmation-block"), "Page with deposit information")
    {
    }

    public void OpenTariffPdf()
    {
        TariffInfo.Click();
    }

    public void ConfirmRulesCheckBox()
    {
        RulesCheckBox.Check();
    }

    public void ConfirmStatementCheckBox()
    {
        StatementCheckBox.Check();
    }

    public void ScrollModalWindow(Browser browser)
    {
        browser.Driver.ExecuteScript("arguments[0].scrollTop = arguments[0].scrollHeight", browser.Driver.FindElement(By.Id("instant-deposit-agreement-content")));
    }

    public void AcceptAplication()
    {
        AcceptAplicationButton.State.WaitForClickable();
        AcceptAplicationButton.Click();
    }

    public void ConfirmDeposit()
    {
        SubmitButton.Click();
    }
}
