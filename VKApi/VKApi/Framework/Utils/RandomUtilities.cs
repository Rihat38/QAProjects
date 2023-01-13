namespace VKApi.Framework.Utils;

public static class RandomUtilities
{
    const string chars = "abcdefghijklmnopqrstuvwxyz";

    public static string GetRandomString(int length)
    {
        var _rnd = new Random();
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[_rnd.Next(s.Length)]).ToArray());
    }

    public static int GetRandomInteger(int start, int end)
    {
        var _rnd = new Random();
        return _rnd.Next(start, end);
    }
}