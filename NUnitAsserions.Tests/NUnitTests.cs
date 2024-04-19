namespace NUnitAsserions.Tests;

public class NUnitTests
{
    [Test]
    public void Instance_Test()
    {
        Assert.Pass();
    }

    [Test]
    public static void Static_Test()
    {
        Assert.Pass();
    }

    [Test]
    public async Task Async_Test()
    {
        await Task.Run(() => { Assert.Pass(); });
    }
}