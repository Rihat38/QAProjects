namespace UITest.Utilities;

public static class Utilities
{
    public static string  CreateRandomEmailName(int count)
    {
        return RandomUtilities.GetRandomString(count);
    }
    public static string  CreateRandomEmailName(int nameCount, int domainCount)
    {
        return RandomUtilities.GetRandomString(nameCount) + "@" + 
               RandomUtilities.GetRandomString(domainCount) + ".com";
    }
    public static string CreateRandomDomain(int count)
    {
        return RandomUtilities.GetRandomString(count);
    }
    public static string CreateRandomPassword(int count)
    {
        return RandomUtilities.GetRandomString(count);
    }
}