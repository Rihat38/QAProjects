using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace BankTest.ProjectUtils.Pages
{
    class ApplicationDepositOpeningPage : Form
    {

        public ApplicationDepositOpeningPage() : base(By.Id("instant-deposit-agreement-content"), "Application form for opening a term deposit")
        {
        }
    }
}
