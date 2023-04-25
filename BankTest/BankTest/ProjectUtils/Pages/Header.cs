using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace BankTest.ProjectUtils.Pages
{
    class Header : Form
    {
        private ILabel BankLogo =>
            ElementFactory.GetLabel(By.XPath("//div[@id='header']//a[@id='logo']"), "Site logo");
        private ILabel BankName =>
            ElementFactory.GetLabel(By.XPath("//div[contains(@class, 'environment')]"), "Bank name");
        private ILabel UserName =>
            ElementFactory.GetLabel(By.XPath("//div[@id='header']//div[contains(@class, 'environment')]"), "User name");
        private IButton ChatButton =>
            ElementFactory.GetButton(By.XPath("//div[@id='header']//a[@id='messages-button']"), "Chat button");
        private IButton PersonalOffersButton =>
            ElementFactory.GetButton(By.XPath("//div[@id='header']//a[@id='offers-button']"), "Personal offers button");
        private IButton BankContactsButton =>
            ElementFactory.GetButton(By.XPath("//div[@id='header']//a[@id='contact-button']"), "Bank contacts button");
        private IButton LanguageSwitcherButton =>
            ElementFactory.GetButton(By.XPath("//div[@id='header']//*[@id='language-button']"), "Language switcher button");
        private IButton SettingButton =>
            ElementFactory.GetButton(By.XPath("//div[@id='header']//a[@id='settings-button']"), "Setting button name");

        public Header() : base(By.Id("logo"), "Site logo")
        {
        }

        public bool IsBankNameDisplayed()
        {
            return BankName.State.WaitForDisplayed();
        }

        public bool IsUserNameDisplayed()
        {
            return UserName.State.WaitForDisplayed();
        }

        public bool IsChatButtonDisplayed()
        {
            return ChatButton.State.WaitForDisplayed();
        }

        public bool IsPersonalOffersButtonDisplayed()
        {
            return PersonalOffersButton.State.WaitForDisplayed();
        }

        public bool IsBankContactsButtonDisplayed()
        {
            return BankContactsButton.State.WaitForDisplayed();
        }

        public bool IsLanguageSwitcherButtonDisplayed()
        {
            return LanguageSwitcherButton.State.WaitForDisplayed();
        }

        public bool IsSettingButtonDisplayed()
        {
            return SettingButton.State.WaitForDisplayed();
        }

        public void ClickOnLogo()
        {
            BankLogo.Click();
        }
    }
}
