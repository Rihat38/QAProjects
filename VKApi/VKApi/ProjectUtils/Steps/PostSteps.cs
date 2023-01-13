using RestSharp;
using VKApi.Configuration;
using VKApi.Framework;
using VKApi.Framework.Utils;
using VKApi.ProjectUtils.Models.EditPost.Response;
using VKApi.ProjectUtils.Models.Likes.Response;
using VKApi.ProjectUtils.Models.SavePhoto.Response;
using VKApi.ProjectUtils.Models.WallPhotoUpload.Response;
using VKApi.ProjectUtils.Models.WallPost.Response;
using VKApi.ProjectUtils.Models.WallUploadServer.Response;
using VKApi.TestingData;

namespace VKApi.ProjectUtils.EntityOperations;

public static class PostSteps
{
    private static Config _config;
    private static Config GetConfig
    {
        get
        {
            if (_config == null)
                _config = JsonBinderUtilities.ConfigBinder()!;
            return _config;
        }
    }
    
    private static TestData _testData;
    private static TestData GetTestData
    {
        get
        {
            if (_testData == null)
                _testData = JsonBinderUtilities.TestDataBinder()!;
            return _testData;
        }
    }

    public static WallPostResponse? CreatePost(string source)
    {
        var wallPost = RequestBodyCreator.CreateBodyForNewPost(GetConfig, GetTestData.MessageTextBeforeEdit);

        var client = new RestClient(GetConfig.ApiAppUrl!);
        var request = new RestRequest(source);
        
        if (wallPost != null)
        {
            request.AddJsonBody(wallPost);
            request.AddParameter("access_token", wallPost.AccessToken);
            request.AddParameter("message", wallPost.Message);
            request.AddParameter("v", wallPost.Version);
            
            return client.Post<WallPostResponse>(request);
        }
        Logger.CreateInfoMessage("Request body is not created");
        return null;
    }

    public static WallUploadServerResponse? GetPhotoUploadServer(int userId, string source)
    {
        var client = new RestClient(GetConfig.ApiAppUrl!);
        var request = new RestRequest(source);
        
        request.AddParameter("access_token", GetConfig.AccessToken);
        request.AddParameter("group_id", userId);
        request.AddParameter("v", GetConfig.Version);
        
        return client.Get<WallUploadServerResponse>(request);
    }

    public static WallPhotoUpload? UploadPhoto(string? uploadServer, string filePath)
    {
        if (uploadServer != null)
        {
            var client = new RestClient(uploadServer);
            var request = new RestRequest();
        
            request.AddHeader("Content-Type", "multipart/form-data");
            request.AddFile("photo", filePath);
        
            return client.Post<WallPhotoUpload>(request);
        }
        Logger.CreateInfoMessage("Failed to get server to upload photo");
        return null;
    }

    public static SavePhotoResponse? SaveUploadedPhoto(WallPhotoUpload? photoUploadResponse, string source, int userId)
    {
        var client = new RestClient(GetConfig.ApiAppUrl!);
        var request = new RestRequest(source)
        {
            Method = Method.Post
        };

        if (photoUploadResponse != null)
        {
            request.AddJsonBody(photoUploadResponse);
            request.AddParameter("access_token", GetConfig.AccessToken);
            request.AddParameter("group_id", userId);
            request.AddParameter("server", photoUploadResponse.Server);
            request.AddParameter("photo", photoUploadResponse.Photo);
            request.AddParameter("hash", photoUploadResponse.Hash);
            request.AddParameter("v", GetConfig.Version);

            return client.Post<SavePhotoResponse>(request);
        }
        Logger.CreateInfoMessage("An error occurred while uploading the photo to the server");
        return null;
    }
    
    public static void EditPost(int postId, int? photoId, int userId, string source)
    {
        var editPost = RequestBodyCreator.CreateBodyForPostEditingWithPhoto(GetConfig, postId, userId,
            GetTestData.MessageTextForEdit, photoId);

        var client = new RestClient(GetConfig.ApiAppUrl!); 
        var request = new RestRequest(source);
        
        if (editPost != null)
        {
            request.AddJsonBody(editPost);
            request.AddParameter("access_token", editPost.AccessToken);
            request.AddParameter("post_id", editPost.PostId);
            request.AddParameter("message", editPost.Message);
            request.AddParameter("attachments", editPost.Attachments);
            request.AddParameter("v", editPost.Version);
            client.Post<EditPostResponse?>(request);
        }
        else
            Logger.CreateInfoMessage("Request body is not created");
    }
    
    public static void CommentPost(int postId, string source)
    {
        var comment = RequestBodyCreator.CreateBodyComment(GetConfig, postId, GetTestData.Comment);

        var client = new RestClient(GetConfig.ApiAppUrl!); 
        var request = new RestRequest(source);
        
        if (comment != null)
        {
            request.AddJsonBody(comment);
            request.AddParameter("access_token", comment.AccessToken);
            request.AddParameter("post_id", comment.PostId);
            request.AddParameter("message", comment.Message);
            request.AddParameter("v", comment.Version);
            client.Post<EditPostResponse?>(request);
        }
        else
            Logger.CreateInfoMessage("Request body is not created");
    }
    
    public static LikesResponse? GetPostsLikes(int postId, string source)
    {
        var likesRequestBody = RequestBodyCreator.CreateBodyLikeInfo(GetConfig, postId);

        var client = new RestClient(GetConfig.ApiAppUrl!); 
        var request = new RestRequest(source);
        
        if (likesRequestBody != null)
        {
            request.AddJsonBody(likesRequestBody);
            request.AddParameter("access_token", likesRequestBody.AccessToken);
            request.AddParameter("post_id", likesRequestBody.PostId);
            request.AddParameter("v", likesRequestBody.Version);
            return client.Post<LikesResponse>(request);
        }
        Logger.CreateInfoMessage("Request body is not created");
        return null;
    }
    
    public static void DeletePost(int postId, string source)
    {
        var deletePostRequestBody = RequestBodyCreator.CreateBodyDeletePost(GetConfig, postId);

        var client = new RestClient(GetConfig.ApiAppUrl!); 
        var request = new RestRequest(source);
        
        if (deletePostRequestBody != null)
        {
            request.AddJsonBody(deletePostRequestBody);
            request.AddParameter("access_token", deletePostRequestBody.AccessToken);
            request.AddParameter("post_id", deletePostRequestBody.PostId);
            request.AddParameter("v", deletePostRequestBody.Version);
            client.Post(request);
        }
        else
            Logger.CreateInfoMessage("Request body is not created");
    }
}