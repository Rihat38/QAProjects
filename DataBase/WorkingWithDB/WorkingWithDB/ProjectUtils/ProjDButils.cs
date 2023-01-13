using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using WorkingWithDB.Framework.Utils;
using WorkingWithDB.Models;
using WorkingWithDB.Utils;

namespace WorkingWithDB.ProjectUtils;

public static class ProjDbUtils
{
    private static DbContextOptions<UnionReportingContext>? _options;
    private static UnionReportingContext? _db;

    private static DbContextOptions<UnionReportingContext>? Options
    {
        get { return _options ??= DbUtils.GetDbConnectionOptions(); }
    }

    public static UnionReportingContext Db
    {
        get { return _db ??= new UnionReportingContext(Options); }
    }

    public static void CreateTestReport(string curStatus,
        IConfiguration appConfig, Test? simulatedTest, string? startTime)
    {
        if (appConfig == null) throw new ArgumentNullException(nameof(appConfig));
        if (simulatedTest == null)
        {
            var author = Db.Authors
                .First(a => a.Name == appConfig["Author"]);
            var status = Db.Statuses
                .First(s => s.Name == curStatus);
            var project = Db.Projects
                .First(p => p.Name == appConfig["ProjectName"]);
            var session = Db.Sessions
                .First(s => s.SessionKey == appConfig["SessionKey"]);
            var testRep = new Test
            {
                Name = TestContext.CurrentContext.Test.ClassName,
                StatusId = status.Id,
                MethodName = TestContext.CurrentContext.Test.Name,
                StartTime = startTime,
                EndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                ProjectId = project.Id,
                SessionId = session.Id,
                Env = appConfig["Environment"],
                Browser = appConfig["Browser"],
                AuthorId = author.Id
            };
            
            Db.Tests.Add(testRep);
            Db.SaveChanges();
        }
        else
        {
            var status = Db.Statuses
                .First(s => s.Name == curStatus);
            var testRep = simulatedTest;
            testRep.StatusId = status.Id;
            testRep.StartTime = startTime;
            testRep.EndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Db.Tests.Add(testRep);
            Db.SaveChanges();
        }
    }

    public static List<Test> ReadRandomTests()
    {
        var testList = new List<Test?>();
        for (int i = 0; i < 10; i++)
        {
            var id = RandomUtils.GetRandomDigit(1, 345);
            var test = Db.Tests
                .First(t => t.Id == id);
            var copyTest = new Test
            {
                Name = test.Name,
                MethodName = test.MethodName,
                StatusId = null,
                ProjectId = test.ProjectId,
                SessionId = test.SessionId,
                Env = test.Env,
                Browser = test.Browser,
                AuthorId = test.AuthorId
            };
            
            testList.Add(copyTest);
        }
        return testList;
    }

    public static void DeleteTest(List<Test>? tests)
    {
        
        if (tests == null) return;
        foreach (var test in tests)
        {
            var testForDeleting = Db.Tests
                .First(t => t.Id == test.Id);
            Db.Tests.Remove(testForDeleting);
        }
        Db.SaveChanges();
    }
    
    public static void CloseDbConnection()
    {
        _db = null;
    }
}