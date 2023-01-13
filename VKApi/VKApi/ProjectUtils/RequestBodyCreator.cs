using VKApi.Configuration;
using VKApi.Framework.Utils;
using VKApi.ProjectUtils.Models.EditPost.Request;
using VKApi.ProjectUtils.Models.Likes.Request;
using VKApi.ProjectUtils.Models.WallPost.Request;

namespace VKApi.ProjectUtils;

public static class RequestBodyCreator
{
    public static EditPostRequest CreateBodyForPostEditingWithPhoto(Config config, int postId, int userId, string? message = null,
        int? photoId = null)
    {
        var editedPost = new EditPostRequest();
        editedPost!.AccessToken = config.AccessToken;
        editedPost.PostId = postId;
        editedPost.Message = message;
        editedPost.Version = config.Version;
        editedPost.Attachments = "photo" + userId + "_" + photoId;
        return editedPost;
    }
    
    public static WallPostRequest CreateBodyForNewPost(Config config, string? message = null)
    {
        var wallPost = new WallPostRequest();
        wallPost!.AccessToken = config.AccessToken;
        wallPost.Message = message;
        wallPost.Version = config.Version;
        return wallPost;
    }
    
    public static EditPostRequest CreateBodyComment(Config config, int postId, string? message = null)
    {
        var commentPostBody = new EditPostRequest();
        commentPostBody!.AccessToken = config.AccessToken;
        commentPostBody.PostId = postId;
        commentPostBody.Message = message;
        commentPostBody.Version = config.Version;
        return commentPostBody;
    }
    
    public static LikesRequest CreateBodyLikeInfo(Config config, int postId)
    {
        var postLikesBody = new LikesRequest
        {
            AccessToken = config.AccessToken,
            PostId = postId,
            Version = config.Version
        };
        return postLikesBody;
    }
    
    public static LikesRequest CreateBodyDeletePost(Config config, int postId)
    {
        var postDeleteBody = new LikesRequest
        {
            AccessToken = config.AccessToken,
            PostId = postId,
            Version = config.Version
        };
        return postDeleteBody;
    }
}