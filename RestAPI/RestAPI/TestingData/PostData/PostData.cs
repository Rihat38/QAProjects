using System.Text.Json.Serialization;

namespace RestAPI.TestData;

public class PostData
{
    [JsonPropertyName("userId")]
    public int UserId { get; set; }
    [JsonPropertyName("body")]
    public string Body { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
}