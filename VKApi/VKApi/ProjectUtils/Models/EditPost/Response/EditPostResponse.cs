using System.Text.Json.Serialization;

namespace VKApi.ProjectUtils.Models.EditPost.Response;

public class Response
{
    [JsonPropertyName("post_id")]
    public int PostId { get; set; }
}

public class EditPostResponse
{
    [JsonPropertyName("response")]
    public Response Response { get; set; }
}
