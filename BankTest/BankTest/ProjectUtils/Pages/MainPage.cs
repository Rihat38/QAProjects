using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTest.ProjectUtils.Pages
{
    class MainPage : Form
    {
        private IButton DepositButton =>
            ElementFactory.GetButton(By.Id("deposits-index"), "Deposit button");
        public MainPage() : base(By.XPath("//div[contains(@class, 'welcome-index')]"), "Main page working space")
        {
        }

        public void ClickDepositButton()
        {
            DepositButton.WaitAndClick();
        }
    }
}
