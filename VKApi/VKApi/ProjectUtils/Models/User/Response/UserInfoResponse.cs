using System.Text.Json.Serialization;

namespace VKApi.ProjectUtils.Models.User.Response;

public class Response
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("can_access_closed")]
    public bool CanAccessClosed { get; set; }

    [JsonPropertyName("is_closed")]
    public bool IsClosed { get; set; }
}

public class UserInfoResponse
{
    [JsonPropertyName("response")]
    public List<Response> Response { get; set; }
    
    
}