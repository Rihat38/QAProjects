using System.Text.Json.Serialization;

namespace Exam.TestingData;

public class TestData
{
    [JsonPropertyName("loggerImitation")] 
    public string? LoggerImitation { get; set; }
}