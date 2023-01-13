using Exam.Configuration;
using RestSharp;

namespace Exam.ProjectUtils.Api;

public static class ApiUtils
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
    
    public static string? GetAccessToken(string source)
    {
        var client = new RestClient(GetConfig.ApiAppUrl!);
        var request = new RestRequest(source);

        request.AddParameter("variant", GetConfig.Variant);
        
        return client.Post(request).Content;
    }
}