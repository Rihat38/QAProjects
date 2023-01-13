using System.Text.Json.Serialization;

namespace RestAPI.Configuration;

public class Config
{
    [JsonPropertyName("url")]
    public string? AppUrl { get; set; }
    [JsonPropertyName("posts")]
    public string? Posts { get; set; }
    [JsonPropertyName("users")]
    public string? Users { get; set; }
    [JsonPropertyName("json")]
    public string? Json { get; set; }
    
}