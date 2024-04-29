namespace NUnitAsserions.Tests.AssertionsModels.AdvancedOptions;

public class Assumptions
{
    private string _expected = "nunit";
    private string _actual = "nunit";

    [Test]
    public void AssumptionsTest()
    {
        var customerSettingsEnabled = false;
        Assume.That(customerSettingsEnabled, Is.True);

        // if state in assumption is not met NUnit aborts a test (but does not fail it)
        // it's particualry useful e.g. in case the SUT is highly configurable

        Assert.That(_actual, Is.EqualTo(_expected));

    }
}
