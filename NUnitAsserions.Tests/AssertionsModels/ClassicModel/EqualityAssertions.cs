namespace NUnitAsserions.Tests.AssertionsModels.ClassicModel
{
    public class EqualityAssertions
    {
        private string _expected = "nunit";
        private string _actual = "nunit";

        // All of the following assertion types are tied to the Assert class

        #region Strings comparison

        [Test]
        public void AreEqual()
        {
            Assert.AreEqual(_expected, _actual);
        }

        [Test]
        public void AreEqualWithDescription()
        {
            Assert.AreEqual(_expected, _actual, "descriptive error message");
        }

        [Test]
        public void AreEqualWithDynamicDescription()
        {
            Assert.AreEqual(_expected, _actual, "from {0} error {1}", "template", "message");
        }

        #endregion

        #region Numbers comparison

        [Test]
        public void AreEqualNumbers()
        {
            Assert.AreEqual(1, 1);
        }

        [Test]
        public void AreEqualNumbersWithDiffrentType()
        {
            Assert.AreEqual(2, 2d);
        }

        [Test]
        public void AreEqualNumbersWithinTolerance()
        {
            Assert.AreEqual(2, 2.1, .5);
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

            Assert.AreEqual(expected, actualSorted);

            // Consideration when comparing Arrays, Collections or IEnumerables
            // 1. the order of elements matters (consider sorting before comparing)
            // 2. the evaluation stops at the first value that is not equal, so mind the error message may not be complete as subsequent elements may not be equal too
            // 3. the order of 'keys' when comparing Dictionaries does not matter; two Dictionaries are considered equal as long as all values associated with all keys are equal
        }

        #endregion

        #region Objects by Ref comparison

        // when comparing objects NUnit's AreEqual falls back to the .net Equals method
        // this means that Assert.AreEqual returns true when object properties values are equal
        // to compare references we need to use NUnit's AreSame method (.net's ReferenceEquals equivalent)

        [Test]
        public void AreEqualObjects_ByReference()
        {
            var person1 = new { Name = "Alice", Age = 25 };
            var person2 = new { Name = "Alice", Age = 25 };

            Assert.AreEqual(person1, person2);      // true
            Assert.AreNotSame(person1, person2);    // true
        }

        #endregion

        #region Inequality

        [Test]
        public void AreNotEqual()
        {
            Assert.AreNotEqual("expected", "actual");
        }

        #endregion

        #region Boolean comparison

        [Test]
        public void IsTrue()
        {
            Assert.IsTrue(true);
        }

        #endregion

        #region Null comparison

        [Test]
        public void IsNull()
        {
            Assert.IsNull(null);
        }

        #endregion

        #region Empty Strings / Collections comparison

        [Test]
        public void IsNotEmpty()
        {
            var fruits = new List<string> { "Apple", "Banana", "Cherry" };
            Assert.IsNotEmpty(fruits);
        }

        #endregion

        #region Numeric comparison

        [Test]
        public void ComparingRelativeValues()
        {
            Assert.GreaterOrEqual(3, 2);
        }

        #endregion

    }
}