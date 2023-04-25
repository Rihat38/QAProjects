using System.Text.Json;
using BankTest.Configuration;
using BankTest.ProjectUtils;
using BankTest.TestingData;
using ExamBankTest.ProjectUtils;

namespace BankTest.ProjectUtils;

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