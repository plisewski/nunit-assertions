using FluentAssertions;
using FluentAssertions.Execution;

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

        [Test]
        public void TestMultipleAssertionsWithFluentAssertions()
        {
            using (new AssertionScope())
            {
                1.Should().Be(1);
                "foo".Should().NotBe("boo");
                true.Should().BeTrue();
            }
        }
    }
}
