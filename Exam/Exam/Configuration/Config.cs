using System.Text.Json.Serialization;

namespace Exam.Configuration;

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
    
    [JsonPropertyName("variant")] 
    public int Variant { get; set; }
    
    [JsonPropertyName("authAppUrl")]
    public string? AuthAppUrl { get; set; }
    
    [JsonPropertyName("author")]
    public string? Author { get; set; }

    [JsonPropertyName("sessionKey")]
    public string? SessionKey { get; set; }
    
    [JsonPropertyName("environment")]
    public string? Environment { get; set; }
    [JsonPropertyName("yourLogin")]
    public string? YourLogin { get; set; }
    [JsonPropertyName("yourEmail")]
    public string? YourEmail { get; set; }
}