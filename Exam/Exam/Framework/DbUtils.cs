using Exam.ProjectUtils;
using Exam.ProjectUtils.Database;
using Exam.ProjectUtils.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Exam.Framework;

public class DbUtils
{
    private static IConfigurationRoot? ReadConfigFiles()
    {
        var builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json");
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
        ProjDbUtils.ZeroOutDbContext();
    }
}