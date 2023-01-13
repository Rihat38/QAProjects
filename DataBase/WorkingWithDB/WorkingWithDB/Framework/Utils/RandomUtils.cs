namespace WorkingWithDB.Utils;

public class RandomUtils
{
    public static int GetRandomDigit(int min, int max)
    {
        var rnd = new Random();
        return rnd.Next(min, max+1);
    }
}