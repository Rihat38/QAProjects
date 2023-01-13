using NUnit.Framework;
using WorkingWithDB.Utils;

namespace WorkingWithDB.Tests;

public class TestDataProcessing : BaseTest
{
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    public void TestDataProcessingTest(int value)
    {
        var q = GetSimulatedTests;
        var randomValue = RandomUtils.GetRandomDigit(1,2);
        Assert.That(randomValue, Is.EqualTo(1));
    }
}