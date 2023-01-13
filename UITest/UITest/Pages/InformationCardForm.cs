using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using UITest.Framework;

namespace UITest.Pages;

public class InformationCardForm : Form
{
    private ICheckBox unselectAll =>
        ElementFactory.GetCheckBox(By.XPath("//span[text()='Unselect all']//preceding-sibling::span//label"), "Unselect all checkbox");

    private ICheckBox firstCheckbox =>
        ElementFactory.GetCheckBox(By.XPath("//span[text()='Ponies']//preceding-sibling::span//label"), "First checkbox");

    private ICheckBox secondCheckbox =>
        ElementFactory.GetCheckBox(By.XPath("//span[text()='Polo']//preceding-sibling::span//label"), "Second checkbox");

    private ICheckBox thirdCheckbox =>
        ElementFactory.GetCheckBox(By.XPath("//span[text()='Dough']//preceding-sibling::span//label"), "Third checkbox");
    
    private IButton goToThirdCardButton =>
        ElementFactory.GetButton(By.XPath("//*[contains(@class,'button--stroked')]"), "Button for step to third card");

    private IButton uploadPhotoButton =>
        ElementFactory.GetButton(By.XPath("//*[contains(@class, '_upload-button')]"), "Upload photo button");
    public InformationCardForm() : base(By.XPath("//div[@class='avatar-and-interests__avatar-box']"), "Second card")
    {
    }
    public void UnselectAll()
    {
        unselectAll.Click();
    }
    public void SelectThreeInterests()
    {
        firstCheckbox.Click();
        secondCheckbox.Click();
        thirdCheckbox.Click();
    }
    public void GoToThirdCard()
    {
        goToThirdCardButton.Click();
    }

    public void SetAvatar(string photoPath)
    {
        uploadPhotoButton.Click();
        AutoItFramework.UploadPhoto(photoPath);
    }
}