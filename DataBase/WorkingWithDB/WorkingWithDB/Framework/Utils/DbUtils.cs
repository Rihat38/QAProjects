using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WorkingWithDB.Models;
using WorkingWithDB.ProjectUtils;

namespace WorkingWithDB.Framework.Utils;

public static class DbUtils
{
    public static IConfigurationRoot? ReadConfigFiles()
    {
        var builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json");
        builder.AddJsonFile("config.json");
        return builder.Build();
    }
    public static DbContextOptions<UnionReportingContext>? GetDbConnectionOptions()
    {
        var config = ReadConfigFiles();
        var connectionString = config.GetConnectionString("DefaultConnection");
        var optionsBuilder = new DbContextOptionsBuilder<UnionReportingContext>();
        return optionsBuilder
            .UseMySQL(connectionString)
            .Options;
    }

    public static void DisposeDbConnection()
    {
        ProjDbUtils.Db.Dispose();
        ProjDbUtils.CloseDbConnection();
    }
}