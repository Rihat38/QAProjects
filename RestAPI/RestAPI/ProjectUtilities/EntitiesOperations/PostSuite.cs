using System.Collections.Generic;
using RestAPI.Framework.APIUtils;
using RestAPI.TestingData.Message;
using RestSharp;

namespace RestAPI.ProjectUtilities.EntitiesOperations;

public class PostSuite
{
    public List<JsonMessage>? GetAllPosts(string source, string url)
    {
        var client = new RestClient(url);
        var request = new RestRequest(source);
        
        var response = client.Get(request);
        return ApiUtilities.IsResponseOnGetReturnedInCorrectFormat(response) 
            ? client.Get<List<JsonMessage>>(request) : null;
    }
    
    public JsonMessage? GetPostById(string source, string url)
    {
        var client = new RestClient(url);
        var request = new RestRequest(source);
        
        var response = client.Get(request);
        return ApiUtilities.IsResponseOnGetReturnedInCorrectFormat(response)  
            ? client.Get<JsonMessage>(request) : null;
    }
}