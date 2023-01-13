using System.Text.Json.Serialization;

namespace VKApi.ProjectUtils.Models.SavePhoto.Response;

public class Response
{
    [JsonPropertyName("album_id")]
    public int AlbumId { get; set; }

    [JsonPropertyName("date")]
    public int Date { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("owner_id")]
    public int OwnerId { get; set; }

    [JsonPropertyName("has_tags")]
    public bool HasTags { get; set; }

    [JsonPropertyName("access_key")]
    public string AccessKey { get; set; }

    [JsonPropertyName("size")]
    public List<Size> Size { get; set; }
}

public class SavePhotoResponse
{
    [JsonPropertyName("response")]
    public List<Response> Response { get; set; }
}

public class Size
{
    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }
}


