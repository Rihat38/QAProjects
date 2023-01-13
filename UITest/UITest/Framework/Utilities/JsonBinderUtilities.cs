using System.IO;
using System.Text.Json;
using UITest.Configuration;
using UITest.TestData;

namespace UITest.Utilities;

public class JsonBinderUtilities
{
    private static string _configsettingPath =
        Directory.GetParent(@"../../../../")?.FullName
        + Path.DirectorySeparatorChar + @"UITest\Configuration\configsettings.json";
    private static readonly string _testdataPath = Directory.GetParent(@"../../../../")?.FullName
                                                   + Path.DirectorySeparatorChar +
                                                   @"UITest/TestData/testdata.json";

    public static Config? ConfigBinder()
    {
        var json = File.ReadAllText(_configsettingPath);
        var root = JsonSerializer.Deserialize<Config>(json);
        return root;
    } 
    
    public static TestData.TestData? TestDataBinder()
    {
        var json = File.ReadAllText(_testdataPath);
        var root = JsonSerializer.Deserialize<TestData.TestData>(json);
        return root;
    } 
}