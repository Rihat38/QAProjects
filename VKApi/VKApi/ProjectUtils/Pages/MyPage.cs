using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using VKApi.Framework.Utils;
using VKApi.ProjectUtils.Models.Likes.Response;
using VKApi.ProjectUtils.Steps;
using VKApi.TestingData;

namespace VKApi.ProjectUtils.Pages;

public class MyPage : Form
{
    private const string PostId = "post{0}_{1}";
    private const string PostXPath = "//div[@id='{0}']";
    private const string NewPostTextXPath = "//div[@id='{0}']//div[contains(@class,'wall_post_text')]";
    private const string ShowCommentsButtonXPath = "//div[@id='{0}']//div[@class='replies']//*[@class='js-replies_next_label']";
    private const string CommentsContentXPath = "//div[@id='{0}']//div[@class='reply_content']";
    private const string CommentsAuthorXPath = "//div[@id='{0}']//div[@class='reply_author']";
    private const string CommentsTextXPath = "//div[@id='{0}']//div[@class='reply_text']";
    private const string LikeButtonXPath =
        "//div[@id='{0}']//div[contains(@class, 'PostButtonReactions--post')]";
    private const string PhotoXPath = "//div[@id='{0}']//div[contains(@class, 'page_post_sized_thumbs')]/a";
    
    public MyPage() : base(By.XPath("//div[@class='ProfileHeader']"), "Profile header")
    {
    }

    public bool IsPostAvailable(TestData testData, int userId, int postId)
    {
        var postXPathId = string.Format(PostId, userId, postId);
        var newPostTextXPath = string.Format(NewPostTextXPath, postXPathId);
        
        return ElementFactory.GetLabel(By.Id(postXPathId), "New post").State.WaitForDisplayed()
               && ElementFactory
                   .GetTextBox(By.XPath(newPostTextXPath), "New post's text").Text
                   .Equals(testData.MessageTextBeforeEdit);
    }
    
    public bool IsPostHasBeenEditedCorrectly(TestData testData, int userId, int postId)
    {
        var postXPathId = string.Format(PostId, userId, postId);
        var newPostNewTextXPath = string.Format(NewPostTextXPath, postXPathId);
        var postsImage = string.Format(PhotoXPath, postXPathId);
        var downloadedImage =
            ElementFactory.GetLabel(By.XPath(postsImage), "Downloaded image");
        var imageUrl = downloadedImage.GetAttribute("href");
        FileOperationsSteps.DownloadFile(imageUrl);
        return ElementFactory
            .GetTextBox(By.XPath(newPostNewTextXPath), "New post's text").Text
            .Equals(testData.MessageTextForEdit) 
            && ImageUtils.IsImagesAreEqual(PathUtils.GetPhoto1Path(), PathUtils.GetDownloadedPhotoPath());
    }
    
    public bool IsCommentCorrect(TestData testData, int userId, string userName, int postId)
    {
        var postXPathId = string.Format(PostId, userId, postId);
        ElementFactory.GetButton(
            By.XPath(string.Format(ShowCommentsButtonXPath, postXPathId)),
            "Button for present new comments").Click();
        ElementFactory.GetTextBox(
                By.XPath(string.Format(CommentsContentXPath, postXPathId)), "Comment's content").State
            .WaitForDisplayed();
        return ElementFactory.GetTextBox(
                   By.XPath(string.Format(CommentsAuthorXPath, postXPathId)),
                   "Comment's author").Text.Equals(userName)
               && ElementFactory.GetTextBox(
                   By.XPath(string.Format(CommentsTextXPath, postXPathId)),
                   "Comment's text").Text.Equals(testData.Comment);
    }
    
    public void TakeLikeOnPost(int userId, int postId)
    {
        var postXPathId = string.Format(PostId, userId, postId);
        ElementFactory.GetButton(
            By.XPath(string.Format(LikeButtonXPath, postXPathId)),
            "Button for take like").Click();
    }
    
    public bool IsLike(LikesResponse? likesInfo, int userId)
    {
        if(likesInfo != null)
            return likesInfo.Response.Users
                .Any(u => u.Uid == userId);
        return false;
    }
    
    public bool IsPostDeleted(int userId, int postId)
    {
        var postXPathId = string.Format(PostId, userId, postId);
        return ElementFactory.GetTextBox(
            By.XPath(string.Format(PostXPath, postXPathId)),
            "Post").State.WaitForNotDisplayed(TimeSpan.FromSeconds(3));
    }
}