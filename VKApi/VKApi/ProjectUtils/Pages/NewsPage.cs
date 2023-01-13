using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VKApi.ProjectUtils.Pages;

public class NewsPage : Form
{
    private IButton MyPageButton =>
        ElementFactory.GetButton(By.XPath("//*[@id='l_pr']/a"), "My page button");
    public NewsPage() : base(By.XPath("//div[@id='submit_post_box']"), "Text area for your news")
    {
    }

    public void ClickOnMyPageButton()
    {
        MyPageButton.Click();
    }
}