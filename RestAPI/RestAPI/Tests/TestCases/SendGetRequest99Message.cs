using NUnit.Framework;
using RestAPI.Framework.APIUtils;
using RestAPI.ProjectUtilities;

namespace RestAPI.TestCases;

public class SendGetRequest99Message
{
    [Test]
    public void TestGetRequest99MessageSending()
    {
        var messagePattern = JsonBinderUtilities.MessageBinder()!.Messages[1];
        var message = ProjApiUtilities.PostSuite?.GetPostById( ApiUtilities.CreateSpecificRequest(
                Endpoints.GetPostById, 99),
            JsonBinderUtilities.ConfigBinder()?.AppUrl!);
        
        Assert.True(messagePattern.Equals(message));
    }
}