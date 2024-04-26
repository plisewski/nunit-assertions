namespace NUnitAsserions.Tests.AssertionsModels.AdvancedOptions
{
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

        }

        [Test]
        public void Assert_Ignore()
        {

        }

        [Test]
        public void Assert_Inconclusive()
        {

        }
    }
}
