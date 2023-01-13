using RestSharp;
using VKApi.Configuration;
using VKApi.Framework.Utils;
using VKApi.ProjectUtils.Models.User.Response;

namespace VKApi.ProjectUtils.EntityOperations;

public static class UserSteps
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

    public static UserInfoResponse? GetUserInfo(string source)
    {
        var client = new RestClient(GetConfig.ApiAppUrl!);
        var request = new RestRequest(source);
        
        request.AddParameter("access_token", GetConfig.AccessToken);
        request.AddParameter("v", GetConfig.Version);
        
        return client.Get<UserInfoResponse>(request);
    }
}