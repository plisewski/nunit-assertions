namespace NUnitAsserions.Tests.AssertionsModels.ConstraintModel
{
    public class EqualityAssertions
    {
        private string _expected = "nunit";
        private string _actual = "nunit";

        // Constraint Model is the recommended model of assertions to use in NUnit3
        // It has been part of NUnit since version 2.4

        // All of the assertions in Constraint Model start with the "That" method

        #region Strings comparison

        [Test]
        public void AreEqual()
        {
            Assert.That(_actual, Is.EqualTo(_expected));
        }

        [Test]
        public void AreEqualWithDescription()
        {
            Assert.That(_actual, Is.EqualTo(_expected), "descriptive error message");
        }

        [Test]
        public void AreEqualWithDynamicDescription()
        {
            Assert.That(_actual, Is.EqualTo(_expected), "from {0} error {1}", "template", "message");
        }

        #endregion

        #region Numbers comparison

        [Test]
        public void AreEqualNumbers()
        {
            Assert.That(1, Is.EqualTo(1));
        }

        [Test]
        public void AreEqualNumbersWithDiffrentType()
        {
            Assert.That(2d, Is.EqualTo(2));
        }

        [Test]
        public void AreEqualNumbersWithinTolerance()
        {
            Assert.That(2.1, Is.EqualTo(2).Within(.5));
        }

        #endregion

        #region Arrays comparison

        [Test]
        public void AreEqualArrays()
        {
            var expected = new int[] { 1, 2, 3 };
            var actual = new int[] { 1, 3, 2 };

            var actualSorted = (int[])actual.Clone();

            Array.Sort(actualSorted);

            Assert.That(actualSorted, Is.EqualTo(expected));

            // Consideration when comparing Arrays, Collections or IEnumerables
            // -> the order elements matters (consider sorting before comparing)
            // -> the evaluation stops at the first value the is not equal (though the error message may not complete as there may be other elements that are not equal
            // -> for Dictionaries the order of 'keys' DOES NOT matter; 2 Dictionaries are considered equal as long as all values associated with all keys are equal 
        }

        #endregion

        #region Objects by Ref comparison

        // when comparing objects NUnit falls back to the .net Equals method; this means that for reference types Assert.AreEqual does not use value equality but compares references

        [Test]
        public void AreEqualObjects_ByReference()
        {
            var obj1 = new object();
            var obj2 = obj1;

            Assert.That(obj2, Is.SameAs(obj1));
        }

        #endregion

        #region Inequality

        [Test]
        public void AreNotEqual()
        {
            Assert.That("actual", Is.Not.EqualTo("expected"));
        }

        #endregion

        #region Boolean comparison

        [Test]
        public void IsTrue()
        {
            Assert.That(true, Is.True);
        }

        #endregion

        #region Null comparison

        [Test]
        public void IsNull()
        {
            object? obj = null;
            Assert.That(obj, Is.Null);
        }

        #endregion

        #region Empty Strings / Collections comparison

        [Test]
        public void IsNotEmpty()
        {
            var fruits = new List<string> { "Apple", "Banana", "Cherry" };
            Assert.That(fruits, Is.Not.Empty);
        }

        #endregion

        #region Numeric comparison

        [Test]
        public void ComparingRelativeValues()
        {
            Assert.That(3, Is.GreaterThanOrEqualTo(2));
        }

        #endregion

    }
}