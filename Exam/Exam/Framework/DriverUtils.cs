using System.Drawing;
using System.Net;
using System.Reflection;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Visualization;
using Exam.ProjectUtils.Pages;
using OpenQA.Selenium;

namespace Exam.Framework;

public class DriverUtils
{
    public static byte[] TakeAndSafeScreenshot(Browser browser)
    {
        Screenshot ss = ((ITakesScreenshot) browser.Driver).GetScreenshot();
        var prefix = GetDirectory();
        ss.SaveAsFile(prefix + @"\Exam\Source\screenshot.png", ScreenshotImageFormat.Png);
        return File.ReadAllBytes(prefix + @"\Exam\Source\screenshot.png");
    }

    public static byte[] GetByteArrayOfDownloadedImage(Browser browser, string screenshotLink)
    {
        //DownloadFile(screenshotLink);
        var prefix = GetDirectory();
        //File.ReadAllBytes(prefix + @"\Exam\Source\downloadedPhoto.png");
        return DownloadFile(browser.Driver, screenshotLink);
    }

    private static byte[] DownloadFile(WebDriver driver, string fileUrl)
    {
        var prefix = GetDirectory();
        var webClient = new WebClient();
        return webClient.DownloadData(fileUrl);
    }

    private static string GetDirectory()
    {
        var cd = Directory.GetCurrentDirectory();
        var name = Assembly.GetExecutingAssembly().GetName().Name;
        return Path.Combine(cd.Split(name)[0], name!);
    }
}