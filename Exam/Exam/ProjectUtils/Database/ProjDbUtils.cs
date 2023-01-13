using Exam.Configuration;
using Exam.Framework;
using Exam.ProjectUtils.Models;
using Exam.TestingData;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Exam.ProjectUtils.Database;

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

    public static Test CreateTestReport(string projectName, string curStatus, Config config, string? startTime)
    {
        var author = Db.Authors
            .First(a => a.Name == config.Author);
        var status = Db.Statuses
            .First(s => s.Name == curStatus);
        var project = Db.Projects
            .First(p => p.Name == projectName);
        var session = Db.Sessions
            .First(s => s.SessionKey == config.SessionKey);
        var testRep = new Test
        {
            Name = TestContext.CurrentContext.Test.ClassName,
            StatusId = status.Id,
            MethodName = TestContext.CurrentContext.Test.Name,
            StartTime = startTime,
            ProjectId = project.Id,
            SessionId = session.Id,
            Env = config.Environment!,
            Browser = config.BrowserName,
            AuthorId = author.Id
        };
        
        Db.Tests.Add(testRep);
        Db.SaveChanges();
        
        return testRep;
    }
    
    public static Test CreateTestModel(string projectName, string testName, string testMethodName, string curStatus, 
        string startTime, string environment, string browser, string authorName, Config config)
    {
        var project = Db.Projects
            .First(p => p.Name == projectName);
        var status = Db.Statuses
            .First(s => s.Name == curStatus);
        var author = Db.Authors
            .First(a => a.Name == authorName);
        var session = Db.Sessions
            .First(s => s.SessionKey == config.SessionKey);
        var sourceProject = Db.Tests
            .First(t => t.StartTime == startTime);
        var testRep = new Test
        {
            Id = sourceProject.Id,
            Name = testName,
            StatusId = status.Id,
            MethodName = testMethodName,
            StartTime = startTime,
            ProjectId = project.Id,
            SessionId = session.Id,
            Env = environment,
            Browser = browser,
            AuthorId = author.Id,
            Author = author,
            Project = project,
            Session = session,
            Status = status
        };

        return testRep;
    }

    public static void CreateNewAuthor(Config config, string? login, string? email)
    {
        if (!Db.Authors
                .Any(a => a.Name == config.Author))
        {
            var newAuthor = new Author()
            {
                Name = config.Author,
                Login = login,
                Email = email
            };

            Db.Authors.Add(newAuthor);
            Db.SaveChanges();
        }
    }

    public static void CreateNewLogReport(TestData testData, string startTime)
    {
        var testId = Db.Tests
            .First(t => t.StartTime == startTime).Id;
        var newLog = new Log()
        {
            Content = testData.LoggerImitation,
            IsException = false,
            TestId = Db.Tests
                .First(t => t.StartTime == startTime).Id
        };

        Db.Logs.Add(newLog);
        Db.SaveChanges();
    }

    public static void AddScreenshotForTest(string startTime)
    {
        var testId = Db.Tests
            .First(t => t.StartTime == startTime).Id;
        using (var fs = new FileStream(Pathes.GetScreenshotPath(), FileMode.Open, FileAccess.ReadWrite))
        {
            using (var br = new BinaryReader(fs))
            {
                var bytes = br.ReadBytes((Int32) fs.Length);
                
                var content = new MySqlParameter("@Content", bytes);
                var contentType = new MySqlParameter("@ContentType", "image/png");
                var idOfNeededTest = new MySqlParameter("@TestId", testId);
                Db.Database.ExecuteSqlRaw(
                    "INSERT INTO attachment(content, content_type, test_id) VALUES (@Content, @ContentType, @TestId)",
                    content, contentType, idOfNeededTest);
            }
        }
    }

    public static List<Test> ReadNexageTests()
    {
        var nexageId = Db.Projects
            .First(t => t.Name == "Nexage").Id;
        var nexageTests = Db.Tests
            .Where(t => t.ProjectId == nexageId)
            .ToList();
        return nexageTests;
    }

    public static void ZeroOutDbContext()
    {
        _db = null;
    }
}