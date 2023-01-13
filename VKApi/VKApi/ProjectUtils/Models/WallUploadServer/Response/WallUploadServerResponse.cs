using System.Text.Json.Serialization;

namespace VKApi.ProjectUtils.Models.WallUploadServer.Response;

    public class Response
    {
        [JsonPropertyName("album_id")]
        public int AlbumId { get; set; }
        
        [JsonPropertyName("upload_url")]
        public string? UploadUrl { get; set; }
        
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }
    }

    public class WallUploadServerResponse
    {
        [JsonPropertyName("response")]
        public Response Response { get; set; }
    }
