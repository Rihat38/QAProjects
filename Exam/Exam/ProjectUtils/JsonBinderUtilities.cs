using System.Text.Json;
using Exam.Configuration;
using Exam.TestingData;

namespace Exam.ProjectUtils;

public static class JsonBinderUtilities
{
    public static Config? ConfigBinder()
    {
        var json = File.ReadAllText(Pathes.GetConfigSettingFile());
        return JsonSerializer.Deserialize<Config>(json);
    }

    public static TestData? TestDataBinder()
    {
        var json = File.ReadAllText(Pathes.GetTestDataFile());
        return JsonSerializer.Deserialize<TestData>(json);
    }
}