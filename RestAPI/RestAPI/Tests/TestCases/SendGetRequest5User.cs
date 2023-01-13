using NUnit.Framework;
using RestAPI.Framework.APIUtils;
using RestAPI.ProjectUtilities;

namespace RestAPI.TestCases;

public class SendGetRequest5User
{
    [Test]
    public void TestGetRequest5UserSending()
    {
        var user5 = JsonBinderUtilities.UserDataBinder();
        var user = ProjApiUtilities.UserSuite?.GetUserById( ApiUtilities.CreateSpecificRequest(
                Endpoints.GetUserById, 5),
            JsonBinderUtilities.ConfigBinder()?.AppUrl!);
        
        Assert.True(user?.Equals(user5), "Wrong user found");
    }
}