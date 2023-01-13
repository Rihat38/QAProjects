using System.Collections.Generic;
using RestAPI.Framework.APIUtils;
using RestAPI.TestingData.UserData;
using RestSharp;

namespace RestAPI.ProjectUtilities.EntitiesOperations;

public class UserSuite
{
    public UserData? GetUserById(string source, string url)
    {
        var client = new RestClient(url);
        var request = new RestRequest(source);
        
        var response = client.Get(request);
        return ApiUtilities.IsResponseOnGetReturnedInCorrectFormat(response)  
            ? client.Get<UserData>(request) : null;
    }
    
    public List<UserData>? GetAllUsers(string source, string url)
    {
        var client = new RestClient(url);
        var request = new RestRequest(source);
        
        var response = client.Get(request);
        return ApiUtilities.IsResponseOnGetReturnedInCorrectFormat(response)  
            ? client.Get<List<UserData>>(request) : null;
    }
}