using System.Collections.Generic;
using RestAPI.Framework;
using RestAPI.Framework.APIUtils;
using RestAPI.ProjectUtilities.EntitiesOperations;
using RestAPI.TestingData.Message;
using RestAPI.TestingData.UserData;
using RestSharp;

namespace RestAPI.ProjectUtilities;

public static class ProjApiUtilities
{
    public static PostSuite? PostSuite => new ();
    public static UserSuite? UserSuite => new ();

    public static bool IsUserIsListed(UserData? user, List<UserData>? list)
    {
        foreach (var us in list)
        {
            if (user.Equals(us))
            {
                Logger.CreateInfoMessage("List contains searched user");
                return true;
            }
        }
        Logger.CreateInfoMessage("List doesn't contain searched user");
        return false;
    }
    
    public static JsonMessage? CreatePostRequest(string source, string url)
    {
        var post = JsonBinderUtilities.PostDataBinder();
        var client = new RestClient(url);
        var request = new RestRequest(source);
        request.AddJsonBody(post);
        Logger.CreateInfoMessage("Post request created");
        var response = client.Post(request);

        return ApiUtilities.IsResponseOnPostReturnedInCorrectFormat(response) 
            ? client.Post<JsonMessage>(request) : null;
    }
}