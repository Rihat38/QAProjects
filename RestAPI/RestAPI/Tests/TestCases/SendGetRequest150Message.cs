using NUnit.Framework;
using RestAPI.Framework.APIUtils;
using RestAPI.ProjectUtilities;

namespace RestAPI.TestCases;

public class SendGetRequest150Message
{
    [Test]
    public void TestGetRequest150MessageSending()
    {
       
        var message = ProjApiUtilities.PostSuite?.GetPostById( ApiUtilities.CreateSpecificRequest(
                Endpoints.GetPostById, 150),
            JsonBinderUtilities.ConfigBinder()?.AppUrl!);
        
        Assert.True(message == null, "Message was found");
    }
}