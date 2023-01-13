using System.Text.Json.Serialization;

namespace UITest.Configuration;

public class Config
{
    [JsonPropertyName("appUrl")]
    public string? AppUrl { get; set; }
}