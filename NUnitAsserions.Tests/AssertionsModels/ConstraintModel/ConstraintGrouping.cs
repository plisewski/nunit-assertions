using System.Text.Json;

namespace NUnitAsserions.Tests.AssertionsModels.ConstraintModel
{
    public class ConstraintGrouping
    {
        [Test]
        public void Is_Constraint()
        {
            Assert.That(true, Is.True);
            Assert.That("true", Is.EqualTo("true"));
            Assert.That(new object(), Is.Not.SameAs(new object()));
            Assert.That(new List<int> { 1, 2, 3 }, Is.Not.Empty.Or.Not.Null); // Compound Constraint
            Assert.That(new List<int> { 1, 2, 3 }, Is.SubsetOf(new List<int> { 1, 2, 3, 4, 5 }));
            Assert.That(new List<int> { 3, 2, 1 }, Is.EquivalentTo(new List<int> { 1, 2, 3 }));
            Assert.That(2, Is.GreaterThan(1));
            Assert.That(0, Is.Zero);
            CustomAsserts.IsJsonSerializable(new object());

        }

        [Test]
        public void Has_Constraint()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            Assert.That(numbers, Has.Exactly(3).Matches<int>(x => x % 2 != 0));
            Assert.That(numbers, Has.Member(1));
            Assert.That(numbers, Has.All.Positive);
            Assert.That(numbers, Has.Some.Matches<int>(x => x % 2 == 0));
            Assert.That(numbers, Has.None.LessThan(0));

            var people = new List<object>
                {
                    new { Name = "Alice", Age = 25 },
                    new { Name = "Bob", Age = 30 },
                    new { Name = "Charlie", Age = 35 }
                };

            Assert.That(people, Has.Exactly(1).Property("Age").EqualTo(25));

        }

        [Test]
        public void Does_Constraint()
        {
            string fileName = "report.pdf";

            Assert.That(fileName, Does.StartWith("report"));
            Assert.That(fileName, Does.EndWith(".pdf"));
            Assert.That(fileName, Does.Contain("pdf"));
            Assert.That(fileName, Does.Match(@".*\.pdf$"));

            List<string> items = new List<string> { "apple", "banana", "apricot", "avocado", "almond" };
            Assert.That(items, Has.Exactly(4).Matches<string>(item => item.StartsWith("a")));
        }

        [Test]
        public void Contains_Constraint()
        {
            int[] numbers = [1, 2, 3, 4, 5];
            Assert.That(numbers, Does.Contain(3).And.Contain(5)); // Compound Constraint

            var dictionary = new Dictionary<string, int>
            {
                {"apple", 1},
                {"banana", 2},
                {"cherry", 3}
            };

            Assert.That(dictionary, Does.ContainKey("banana"));
            Assert.That(dictionary, Does.ContainValue(3));

            string message = "Hello, welcome to NUnit testing!";
            Assert.That(message, Does.Contain("welcome"));
        }

        [Test]
        public void Throw_Constraint()
        {
            void MethodThatThrows() => throw new InvalidOperationException("Invalid operation");
            Assert.That(MethodThatThrows, Throws.TypeOf<InvalidOperationException>());
            Assert.That(MethodThatThrows, Throws.Exception);

            void MethodThatDoesNotThrow() { /* No operation that throws */ }
            Assert.That(MethodThatDoesNotThrow, Throws.Nothing);

            void MethodThatThrowsSlowly()
            {
                Thread.Sleep(2000); // Simulate delay
                throw new TimeoutException("Operation timed out.");
            }

            Assert.That(MethodThatThrowsSlowly, Throws.TypeOf<TimeoutException>().After(1500));
        }
    }

    public static class CustomAsserts
    {
        public static void IsJsonSerializable<T>(T obj)
        {
            try
            {
                string json = JsonSerializer.Serialize(obj);
                T? result = JsonSerializer.Deserialize<T>(json);

                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected to be JSON serializable but failed with exception: {ex.Message}");
            }
        }
    }
}
