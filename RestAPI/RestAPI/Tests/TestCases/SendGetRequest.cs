using NUnit.Framework;
using RestAPI.Framework.APIUtils;
using RestAPI.ProjectUtilities;

namespace RestAPI.TestCases;

public class SendGetRequest
{
    [Test]
    public void TestGetRequestSending()
    {
        var messages = ProjApiUtilities.PostSuite?.GetAllPosts(Endpoints.GetAllPosts,
            JsonBinderUtilities.ConfigBinder()?.AppUrl!);
        
        Assert.True(ApiUtilities.IsIdInAscendingOrder(messages), "Ids are not in ascending order");
    }
}