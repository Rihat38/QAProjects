using System.Reflection;

namespace VKApi.Framework.Utils;

public class PathUtils
{
    private static readonly string Prefix;
    private static readonly string _photo1Path = @"\VKApi\Resource\prog.jpg";
    private static readonly string _downloadedPhoto = @"\VKApi\Resource\dl.jpg";
    
    static PathUtils()
    {
        var cd = Directory.GetCurrentDirectory();
        var name = Assembly.GetExecutingAssembly().GetName().Name;
        Prefix = Path.Combine(cd.Split(name)[0], name!);
    }

    public static string GetPhoto1Path() => Prefix + _photo1Path;
    public static string GetDownloadedPhotoPath() => Prefix + _downloadedPhoto;
}