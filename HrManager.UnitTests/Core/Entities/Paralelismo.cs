using System.Threading;
using Xunit;

namespace HrManager.UnitTests.Core.Entities;

public class Paralelismo
{
    [Fact]
    public void Test_Long()
    {
        Thread.Sleep(6000);
    }

    [Fact]
    public void Test_Medium()
    {
        Thread.Sleep(4000);
    }

    [Fact]
    public void Test_Short()
    {
        Thread.Sleep(2000);
    }
}
