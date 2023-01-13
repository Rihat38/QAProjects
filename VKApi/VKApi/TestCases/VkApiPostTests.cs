using VKApi.ProjectUtils;
using VKApi.ProjectUtils.EntityOperations;
using VKApi.ProjectUtils.Pages;
using VKApi.ProjectUtils.Steps;

namespace VKApi.TestCases;

public class TestingVkApi : BaseTest
{
    private int _userId;
    private string _userName;
    private int _postId;
    private int _photoId;

    [Test]
    public void TestingVkApiTest()
    {
        Browser?.GoTo(Config.AppUrl);
        //Authorization and transition to my page
        var newsPage = AuthSteps.SignIn();
        newsPage.ClickOnMyPageButton();
        var myPage = new MyPage();
        Assert.That(myPage.State.WaitForDisplayed(), Is.True);
        //Create a post
        var createPostResponse = PostSteps.CreatePost(Endpoints.WallPost);
        Assert.NotNull(createPostResponse, "Server response about post creation is null");
        _postId = createPostResponse!.Response.PostId;
        //Getting user data
        var getUserInfoResponse = UserSteps.GetUserInfo(Endpoints.UsersGet);
        Assert.NotNull(getUserInfoResponse, "Server response about user is null");
        _userId = getUserInfoResponse!.Response[0].Id; 
        _userName = getUserInfoResponse.Response[0].FirstName + " " + getUserInfoResponse.Response[0].LastName;
        Assert.True(myPage.IsPostAvailable(TestData ,_userId, _postId),
            "A post with the correct text from the correct user did not appear");
        //Uploading a photo to the server
        var photoIdResponse = FileOperationsSteps.UploadImageOnServer(_userId);
        Assert.Less(0, photoIdResponse, "Server response about added photo less 0");
        _photoId = photoIdResponse;
        //Change post
        PostSteps.EditPost(_postId, _photoId, _userId, Endpoints.WallEditPost); 
        Assert.True(myPage.IsPostHasBeenEditedCorrectly(TestData, _userId, _postId), 
            "Post has not been modified or modified with incorrect text");
        //Commenting on a post
        PostSteps.CommentPost(_postId, Endpoints.WallCreateComment);
        Assert.True(myPage.IsCommentCorrect(TestData, _userId, _userName, _postId),
            "Comment from the right user with the correct text was not found");
        //Setting a "like" reaction
        myPage.TakeLikeOnPost(_userId, _postId);
        var likesInfo = PostSteps.GetPostsLikes(_postId, Endpoints.WallPostsLikeInfo);
        Assert.True(myPage.IsLike(likesInfo, _userId), "Like from desired user not found");
        //Deleting a post
        PostSteps.DeletePost(_postId, Endpoints.WallPostsDelete);
        Assert.True(myPage.IsPostDeleted(_userId, _postId), "Post has not been deleted");
    }
}