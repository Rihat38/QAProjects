using System.Text.Json.Serialization;

namespace VKApi.ProjectUtils.Models.EditPost.Request;

public class EditPostRequest
{
    [JsonPropertyName("access_token")] 
    public string? AccessToken { get; set; }
    
    [JsonPropertyName("post_id")] 
    public int PostId { get; set; }
    
    [JsonPropertyName("message")] 
    public string? Message { get; set; }
    
    [JsonPropertyName("attachments")] 
    public string? Attachments { get; set; }
    
    [JsonPropertyName("v")] 
    public string? Version { get; set; }
}