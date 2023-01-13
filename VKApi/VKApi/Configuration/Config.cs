using System.Text.Json.Serialization;

namespace VKApi.Configuration;

public class Config
{
    [JsonPropertyName("browserName")]
    public string? BrowserName { get; set; }
    
    [JsonPropertyName("appUrl")]
    public string? AppUrl { get; set; }
    
    [JsonPropertyName("apiAppUrl")]
    public string? ApiAppUrl { get; set; }
    
    [JsonPropertyName("access_token")] 
    public string? AccessToken { get; set; }
    
    [JsonPropertyName("version")] 
    public string? Version { get; set; }
}