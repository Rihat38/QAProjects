using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace UITest.Pages;

public class StartPage : Form
{
    private IButton startButton => ElementFactory.GetButton(By.XPath("//a[@class='start__link']"), "StartLink");

    public StartPage() : base(By.XPath("//*[@class='start__button']"), "Start button")
    {
    }

    public void GoToGamePage()
    {
        startButton.WaitAndClick();
    }
}