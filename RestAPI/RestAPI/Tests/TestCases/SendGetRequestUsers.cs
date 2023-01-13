using NUnit.Framework;
using RestAPI.ProjectUtilities;


namespace RestAPI.TestCases;

public class SendGetRequestUsers
{
    [Test]
    public void TestGetRequestUsersSending()
    {
        var user5 = JsonBinderUtilities.UserDataBinder();
        var users = ProjApiUtilities.UserSuite?.GetAllUsers( Endpoints.GetAllUsers,
            JsonBinderUtilities.ConfigBinder()?.AppUrl!);
        
        Assert.True(ProjApiUtilities.IsUserIsListed(user5, users), "Test user not found");
    }
}