using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestAPI.TestingData.Message;
public class JsonMessage
{
    [JsonPropertyName("userId")]
    public int UserId { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("body")]
    public string Body { get; set; }
    
    public override bool Equals(object? obj)
    {
        return obj != null &&
               ((JsonMessage) obj).UserId.Equals(UserId) &&
               ((JsonMessage) obj).Id.Equals(Id) &&
               ((JsonMessage) obj).Title.Equals(Title) &&
               ((JsonMessage) obj).Body.Equals(Body);
    }
}

public class MessagePatterns
{
    [JsonPropertyName("messagePatterns")]
    public List<JsonMessage> Messages { get; set; }
}