using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace UITest.Pages;

public class ThirdCardForm : Form
{
    public ThirdCardForm() : base(By.XPath("//div[@class='personal-details__form']"), "Third card")
    {
    }
}