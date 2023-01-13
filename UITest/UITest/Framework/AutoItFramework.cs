using System.Threading;
using AutoIt;

namespace UITest.Framework;

public static class AutoItFramework
{
    public static void UploadPhoto(string _photo)
    {
        AutoItX.ControlFocus("Открытие", "", "Edit1");
        Thread.Sleep(1000);
        AutoItX.ControlSetText("Открытие", "", "Edit1", _photo);
        Thread.Sleep(1000);
        AutoItX.ControlClick("Открытие", "", "Button1");
        Thread.Sleep(1000);
    }
}