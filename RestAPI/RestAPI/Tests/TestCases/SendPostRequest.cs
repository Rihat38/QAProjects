using NUnit.Framework;
using RestAPI.ProjectUtilities;

namespace RestAPI.TestCases;

public class SendPostRequest
{
    [Test]
    public void TestPostCreating()
    {
        var postPattern = JsonBinderUtilities.MessageBinder()!.Messages[0];
        var response = ProjApiUtilities.CreatePostRequest(Endpoints.CreatePost,
            JsonBinderUtilities.ConfigBinder()?.AppUrl!);

        Assert.True(response.Equals(postPattern), "Post date doesn't equal post pattern ");
    }
}