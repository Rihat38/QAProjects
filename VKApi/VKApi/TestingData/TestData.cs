using System.Text.Json.Serialization;

namespace VKApi.TestingData;

public class TestData
{
    [JsonPropertyName("login")] 
    public string? Login { get; set; }
    
    [JsonPropertyName("password")] 
    public string? Password { get; set; }
    
    [JsonPropertyName("messageTextBeforeEdit")] 
    public string? MessageTextBeforeEdit { get; set; }
    
    [JsonPropertyName("messageTextForEdit")] 
    public string? MessageTextForEdit { get; set; }
    
    [JsonPropertyName("comment")] 
    public string? Comment { get; set; }
}