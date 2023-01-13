using System;
using System.Collections.Generic;
using System.Net;
using RestAPI.Framework.Utilities;
using RestAPI.ProjectUtilities;
using RestAPI.TestingData.Message;
using RestAPI.TestingData.UserData;
using RestSharp;

namespace RestAPI.Framework.APIUtils;

public class ApiUtilities
{

    public static bool IsIdInAscendingOrder(List<JsonMessage>? list)
    {
        if (list == null)
        {
            Logger.CreateInfoMessage("List is empty");
            return false;
        }
        var count = 1;
        var state = true;
        foreach (var e in list)
        {
            state = state && (e.Id == count);
            count++;
        }
        return state;
    }

    public static string CreateSpecificRequest(string collection, int id)
    {
        return String.Format(collection, id);
    }
    
    public static bool IsResponseJsonFormat(RestResponse response)
    {
        return response.ContentType!.Equals(JsonBinderUtilities.ConfigBinder()?.Json);
    }

    public static bool IsResponseOnGetReturnedInCorrectFormat(RestResponse response)
    {
        return response.StatusCode.Equals(HttpStatusCode.OK) 
               && IsResponseJsonFormat(response);
    }
    
    public static bool IsResponseOnPostReturnedInCorrectFormat(RestResponse response)
    {
        return response.StatusCode.Equals(HttpStatusCode.Created) 
               && IsResponseJsonFormat(response);
    }
}