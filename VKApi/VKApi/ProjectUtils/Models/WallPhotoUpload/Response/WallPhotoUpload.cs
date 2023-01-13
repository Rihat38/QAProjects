using System.Text.Json.Serialization;

namespace VKApi.ProjectUtils.Models.WallPhotoUpload.Response;

public class WallPhotoUpload
{
    [JsonPropertyName("server")]
    public int Server { get; set; }
        
    [JsonPropertyName("photo")]
    public string? Photo { get; set; }

    [JsonPropertyName("hash")]
    public string Hash { get; set; }
}