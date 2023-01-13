namespace VKApi.Framework.Utils;

public class ImageUtils
{
    public static bool IsImagesAreEqual(string expectedImagePath, string downloadedImagePath)
    {
        var expectedImageInBytes = File.ReadAllBytes(expectedImagePath);
        var downloadedImageInBytes = File.ReadAllBytes(downloadedImagePath);
        var areEqual = true;
        for(int i = 0; i < expectedImageInBytes.Length; i++)
        {
            areEqual = expectedImageInBytes[i] == downloadedImageInBytes[i];
            if (areEqual == false)
            {
                return areEqual;
            }
        }
        return areEqual;
    } 
}