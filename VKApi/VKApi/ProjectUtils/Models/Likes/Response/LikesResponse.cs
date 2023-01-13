using System.Text.Json.Serialization;

namespace VKApi.ProjectUtils.Models.Likes.Response;

public class Response
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("users")]
    public List<User> Users { get; set; }
}

public class LikesResponse
{
    [JsonPropertyName("response")]
    public Response Response { get; set; }
}

public class User
{
    [JsonPropertyName("uid")]
    public int Uid { get; set; }

    [JsonPropertyName("copied")]
    public int Copied { get; set; }
}
