using System.Linq;
using System.Threading;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using AutoIt;
using UITest.Framework;
using UITest.Utilities;

namespace UITest.Pages;

public class GamePage : Form
{
    public LoginCardForm LoginCardForm => new ();
    public InformationCardForm InformationCardForm => new ();
    public ThirdCardForm ThirdCard => new();
    private ILabel cardIndicator =>
        ElementFactory.GetLabel(By.XPath("//div[@class='page-indicator']"), "CardIndicator");

    private IButton hideHelpFormButton =>
        ElementFactory.GetButton(By.XPath("//button[contains(@class, 'help-form__send-to-bottom-button')]"),
            "Button for hiding help form");

    private ITextBox hiddenHelpForm =>
        ElementFactory.GetTextBox(By.XPath("//div[contains(@class, 'is-hidden')]"), "Hidden help form");

    private IButton acceptingCookieButton =>
        ElementFactory.GetButton(
            By.XPath("//div[@class='align__cell']//button[contains(@class, 'button--transparent')]"),
            "Accept cookies button");

    private ITextBox mainTimer =>
        ElementFactory.GetTextBox(By.XPath("//div[contains(@class, 'timer--white')]"), "Main timer");

    public GamePage() : base(By.XPath("//*[@class='login-form']"), "Login form")
    {
    }
    
    public string GetCardNumber()
    {
        return cardIndicator.Text.First().ToString();
    }

    public void HideHelpForm()
    {
        hideHelpFormButton.Click();
    }

    public bool IsHelpFormVisibility()
    {
        return hiddenHelpForm.State.IsDisplayed;
    }

    public void AcceptCookie()
    {
        acceptingCookieButton.State.WaitForDisplayed();
        acceptingCookieButton.Click();
    }

    public string GetTimerValue()
    {
        return mainTimer.Text;
    }
}