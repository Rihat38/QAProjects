using System.Net;
using VKApi.Framework.Utils;
using VKApi.ProjectUtils.EntityOperations;

namespace VKApi.ProjectUtils.Steps;

public class FileOperationsSteps
{
    private static string? _uploadServerUrl;

    public static int UploadImageOnServer(int userId)
    {
        _uploadServerUrl = PostSteps.GetPhotoUploadServer(userId, Endpoints.WallPhotoUploadServer)
            ?.Response.UploadUrl;
        var photoUploadResponse = PostSteps.UploadPhoto(_uploadServerUrl, PathUtils.GetPhoto1Path());
        var photoId = PostSteps.SaveUploadedPhoto(photoUploadResponse, Endpoints.WallSavePhoto, userId);
        if (photoId != null)
            return photoId.Response[0].Id;
        return -1;
    }

    public static void DownloadFile(string fileUrl)
    {
        using var webClient = new WebClient();
        webClient.DownloadFile(new Uri(fileUrl), PathUtils.GetDownloadedPhotoPath());
    }
}