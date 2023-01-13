using System.IO;
using System.Reflection;
using System.Text.Json;
using RestAPI.Configuration;
using RestAPI.TestData;
using RestAPI.TestingData.Message;
using RestAPI.TestingData.UserData;

namespace RestAPI.ProjectUtilities;

public static class JsonBinderUtilities
{
    private static readonly string Prefix;
    private static readonly string _configsettingPath = @"\RestAPI\Configuration\configsettings.json";
    private static readonly string _messagePath = @"\RestAPI\TestingData\Message\message.json";
    private static readonly string _userdataPath = @"\RestAPI\TestingData\UserData\userdata.json";
    private static readonly string _postdataPath = @"\RestAPI\TestingData\PostData\postdata.json";

    static JsonBinderUtilities()
    {
        var cd = Directory.GetCurrentDirectory();
        var name = Assembly.GetExecutingAssembly().GetName().Name;
        Prefix = Path.Combine(cd.Split(name)[0], name!);
    }

    public static Config? ConfigBinder()
    {
        var json = File.ReadAllText(Prefix + _configsettingPath);
        return JsonSerializer.Deserialize<Config>(json);
    }


    public static MessagePatterns? MessageBinder()
    {
        var json = File.ReadAllText(Prefix + _messagePath);
        return JsonSerializer.Deserialize<MessagePatterns>(json);
    }

    public static UserData? UserDataBinder()
    {
        var json = File.ReadAllText(Prefix + _userdataPath);
        return JsonSerializer.Deserialize<UserData>(json);
    }

    public static PostData? PostDataBinder()
    {
        var json = File.ReadAllText(Prefix + _postdataPath);
        return JsonSerializer.Deserialize<PostData>(json);
    }
}