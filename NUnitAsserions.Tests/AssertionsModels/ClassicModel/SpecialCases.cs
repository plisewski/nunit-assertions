namespace NUnitAsserions.Tests.AssertionsModels.ClassicModel
{
    public class SpecialCases
    {

        // There are 4 sets of assertions in the Classic Model that are not part of the Assert class

        #region String Assert

        [Test]
        public void StringAssert_UniqueAssertionMethods()
        {
            var myString = "document.pdf";

            StringAssert.Contains("doc", myString);
            StringAssert.StartsWith("doc", myString);
            StringAssert.EndsWith(".pdf", myString);
            StringAssert.AreEqualIgnoringCase("dOcUmEnT.pDf", myString);
            StringAssert.IsMatch(@".*\.pdf$", myString);

        }

        #endregion

        #region Collection Assert - object must implement IEnumerable

        [Test]
        public void CollectionAssert_UniqueAssertionMethods()
        {
            var myList = new List<string> { "apple", "banana", "cherry" };

            CollectionAssert.AllItemsAreInstancesOfType(myList, typeof(string));
            CollectionAssert.AllItemsAreNotNull(myList);
            CollectionAssert.AllItemsAreUnique(myList);
            CollectionAssert.AreEqual(new List<string> { "apple", "banana", "cherry" } , myList);
            CollectionAssert.AreEquivalent(new List<string> { "banana", "cherry", "apple" }, myList);
            CollectionAssert.Contains(myList, "apple");
            CollectionAssert.IsSubsetOf(new List<string> { "apple" }, myList);
            CollectionAssert.IsNotEmpty(myList);
            CollectionAssert.IsOrdered(myList);

        }

        #endregion

        #region File Assert

        [Test]
        public void FileAssert_UniqueAssertionMethods()
        {
            FileAssert.AreEqual(
                new FileInfo(Path.GetTempFileName()), 
                new FileInfo(Path.GetTempFileName()));
        }

        #endregion

        #region Directory Assert

        [Test]
        public void DirectoryAssert_UniqueAssertionMethods()
        {
            DirectoryAssert.AreEqual(
                new DirectoryInfo(Directory.GetCurrentDirectory()),
                new DirectoryInfo(Directory.GetCurrentDirectory()));

            DirectoryAssert.Exists(new DirectoryInfo(Directory.GetCurrentDirectory()));
        }

        #endregion

    }
}