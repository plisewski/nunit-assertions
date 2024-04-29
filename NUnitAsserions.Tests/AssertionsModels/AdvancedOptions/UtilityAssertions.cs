namespace NUnitAsserions.Tests.AssertionsModels.AdvancedOptions;

public class UtilityAssertions
{
    [Test]
    public void Assert_Pass()
    {
        Assert.That(Assert.Pass, Throws.TypeOf<SuccessException>());
    }

    [Test]
    public void Assert_Fail()
    {
        Assert.That(Assert.Fail, Throws.TypeOf<AssertionException>());
    }

    [Test]
    public void Assert_Ignore()
    {
        Assert.That(Assert.Ignore, Throws.TypeOf<IgnoreException>());
    }

    [Test]
    public void Assert_Inconclusive()
    {
        Assert.That(Assert.Inconclusive, Throws.TypeOf<InconclusiveException>());
    }
}
