namespace NUnitAsserions.Tests.AssertionsModels.AdvancedOptions;

public class Warnings
{
    [Test]
    public void UsingWarnings()
    {
        var isProcessed = false;

        Warn.Unless(isProcessed, Is.EqualTo(true).After(10).Seconds.PollEvery(10).Seconds);
        Console.WriteLine("warned, not failed");
    }
}
