using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace BankTest.ProjectUtils.Pages
{
    class DepositCreatingPage : Form
    {
        private IRadioButton RubCurrencyRadioButton =>
            ElementFactory.GetRadioButton(By.XPath("//*[@value='RUB']"), "Radio button for choice of deposit in rubles");
        private IRadioButton OneMonthRadioButton =>
            ElementFactory.GetRadioButton(By.XPath("//*[@value='31']"), "Radio button for choice of monthly deposit");
        private IButton OpenWinterPeterburgDepositButton =>
            ElementFactory.GetButton(By.XPath("//*[@data-rate-id='10281']//a"), "Button for oprning a winter Peterburg deposit");

        public DepositCreatingPage() : base(By.ClassName("span6"), "Page for new deposit opening")
        {
        }

        public void ChooseRublesCurrency()
        {
            RubCurrencyRadioButton.Click();
        }

        public void ChoosePeriodOneMonth() 
        {
            OneMonthRadioButton.Click();
        }

        public void ClickOpenWinterPeterburgDepositButton()
        {
            OpenWinterPeterburgDepositButton.Click();
        }
    }
}
