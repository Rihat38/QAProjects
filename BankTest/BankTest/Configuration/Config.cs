using System.Text.Json.Serialization;

namespace BankTest.Configuration;

public class Config
{
    [JsonPropertyName("appUrl")]
    public string? AppUrl { get; set; }

    [JsonPropertyName("lang")]
    public string? Lang { get; set; }
}