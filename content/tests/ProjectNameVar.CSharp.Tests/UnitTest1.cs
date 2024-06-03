namespace ProjectNameVar.CSharp.Tests;

using ProjectNameVar.CSharp;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Main.Hello("{GITOWNER}");
        Assert.True(true);
    }
    [Fact]
    public void Test2()
    {
        Main.Hello("{GITOWNER}", "Kevin");
        Assert.True(true);
    }
    [Fact]
    public void Test3()
    {
        Main.PrintTuples([("Test1", "Test1a"), ("Test2", "Test2b")]);
        Assert.True(true);
    }
}
