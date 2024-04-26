namespace NUnitAsserions.Tests.AssertionsModels.AdvancedOptions
{
    public class MultipleAssertions
    {
        [Test]
        public void TestMultipleAssertions()
        {
            Assert.Multiple(() =>
            {
                Assert.That(1, Is.EqualTo(1));
                Assert.That("foo", Is.Not.EqualTo("boo"));
                Assert.That(true, Is.True);
            });
        }
    }
}
