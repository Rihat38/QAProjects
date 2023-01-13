using System.Text.Json.Serialization;

namespace UITest.TestData;
public class TestData
{
    [JsonPropertyName("time")]
    public string? Time { get; set; }
    
}