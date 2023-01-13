
using System.IO;
using UITest.Pages;

namespace UITest.Steps;

public static class Steps
{
    public static void FirstLoginStep(string password, string email, string domain)
    {
        var gamePage = new GamePage();
        var firstCard =  gamePage.LoginCardForm;
        firstCard.FillRegForm(password, email, domain);
        firstCard.AcceptTermsAndCond();
        firstCard.GoToSecondCard();
    }

    public static void SecondLoginStep(string photo)
    {
        var gamePage = new GamePage();
        var secondCard = gamePage.InformationCardForm;
        secondCard.UnselectAll();
        secondCard.SelectThreeInterests();
        secondCard.SetAvatar(Directory.GetCurrentDirectory() + photo);
        secondCard.GoToThirdCard();
    }
}