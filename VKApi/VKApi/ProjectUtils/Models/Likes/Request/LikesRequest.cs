using System.Text.Json.Serialization;

namespace VKApi.ProjectUtils.Models.Likes.Request;

public class LikesRequest
{
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }

    [JsonPropertyName("post_id")]
    public int PostId { get; set; }

    [JsonPropertyName("v")]
    public string? Version { get; set; }
}