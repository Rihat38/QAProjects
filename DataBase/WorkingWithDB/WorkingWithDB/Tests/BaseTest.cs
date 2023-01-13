using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using WorkingWithDB.Framework.Utils;
using WorkingWithDB.Models;
using WorkingWithDB.ProjectUtils;

namespace WorkingWithDB.Tests;

public class BaseTest
{
    private static IConfigurationRoot? _config;
    private static List<Test>? _simulatedTests;
    private static string? _startTime;
    protected static List<Test> GetSimulatedTests {
        get
        {
            if (_simulatedTests == null)
                _simulatedTests = ProjDbUtils.ReadRandomTests();
            return _simulatedTests;
        }
    }
    
    [OneTimeSetUp]
    public void SetConfig()
    {
        _config = DbUtils.ReadConfigFiles();
    }
    
    [SetUp]
    public void Setup()
    {
        _startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
    
    [TearDown]
    public void CreateReportAndDisposeConnection()
    {
        if (_simulatedTests != null)
        {
            ProjDbUtils.CreateTestReport(TestContext.CurrentContext.Result.Outcome.Status.ToString(),
                _config!, GetSimulatedTests.FirstOrDefault(), _startTime);
            GetSimulatedTests.Add(GetSimulatedTests.First());
            GetSimulatedTests.Remove(GetSimulatedTests.First());
        }
        else
            ProjDbUtils.CreateTestReport(TestContext.CurrentContext.Result.Outcome.Status.ToString(),
                _config!, null, _startTime);
        DbUtils.DisposeDbConnection();
    }
    
    [OneTimeTearDown]
    public void DeleteCopiedTests()
    {
        ProjDbUtils.DeleteTest(_simulatedTests);
    }
}