using System.Text.Json.Serialization;

namespace VKApi.ProjectUtils.Models.WallPost.Response;

public class Response
{
    [JsonPropertyName("post_id")]
    public int PostId { get; set; }
}

public class WallPostResponse
{
    [JsonPropertyName("response")]
    public Response Response { get; set; }
}
