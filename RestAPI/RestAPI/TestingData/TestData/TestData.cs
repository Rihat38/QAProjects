using System.Text.Json.Serialization;

namespace RestAPI.TestingData.TestData;

public class TestData
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}
