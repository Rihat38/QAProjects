using System.Text.Json.Serialization;

namespace VKApi.ProjectUtils.Models.WallPost.Request;

public class WallPostRequest
{
    [JsonPropertyName("access_token")] 
    public string? AccessToken { get; set; }
    
    [JsonPropertyName("message")] 
    public string? Message { get; set; }
    
    [JsonPropertyName("v")] 
    public string? Version { get; set; }
}