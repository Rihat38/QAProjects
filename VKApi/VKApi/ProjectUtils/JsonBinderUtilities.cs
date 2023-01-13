using System.Reflection;
using System.Text.Json;
using VKApi.Configuration;
using VKApi.TestingData;

namespace VKApi.Framework.Utils;

public static class JsonBinderUtilities
{
    private static readonly string Prefix;
    private static readonly string _configSettingPath = @"\VKApi\Configuration\configsettings.json";
    private static readonly string _testDataPath = @"\VKApi\TestingData\testdata.json";
    
    static JsonBinderUtilities()
    {
        var cd = Directory.GetCurrentDirectory();
        var name = Assembly.GetExecutingAssembly().GetName().Name;
        Prefix = Path.Combine(cd.Split(name)[0], name!);
    }

    public static Config? ConfigBinder()
    {
        var json = File.ReadAllText(Prefix + _configSettingPath);
        return JsonSerializer.Deserialize<Config>(json);
    }

    public static TestData? TestDataBinder()
    {
        var json = File.ReadAllText(Prefix + _testDataPath);
        return JsonSerializer.Deserialize<TestData>(json);
    }
}