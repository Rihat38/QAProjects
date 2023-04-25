using System.Text.Json.Serialization;

namespace BankTest.TestingData;
public class TestData
{
    [JsonPropertyName("login")]
    public string? Login { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("otp-code")]
    public string? OtpCode { get; set; }

    [JsonPropertyName("depositSum")]
    public int? DepositAmount { get; set; }

    [JsonPropertyName("rate")]
    public string? DepositRate { get; set; }
}
