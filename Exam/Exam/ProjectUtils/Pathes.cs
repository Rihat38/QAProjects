using System.Reflection;

namespace Exam.ProjectUtils;

public static class Pathes
{
    private static readonly string Prefix;
    private static readonly char Separator;

    static Pathes()
    {
        var cd = Directory.GetCurrentDirectory();
        var name = Assembly.GetExecutingAssembly().GetName().Name;
        Prefix = Path.Combine(cd.Split(name)[0], name!);
        Separator = Path.DirectorySeparatorChar;
    }

    public static string GetScreenshotPath() => 
        Prefix + $"{Separator}Exam{Separator}Source{Separator}screenshot.png";
    public static string GetConfigSettingFile() =>
        Prefix + $"{Separator}Exam{Separator}Configuration{Separator}configsettings.json";
    public static string GetTestDataFile() =>
        Prefix + $"{Separator}Exam{Separator}TestingData{Separator}testdata.json";
}