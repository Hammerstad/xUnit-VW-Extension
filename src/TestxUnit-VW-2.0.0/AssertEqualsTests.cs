namespace TestxUnit_VW
{
    using System.Collections;
    using System.Collections.Generic;
    using Xunit;
    using Assert = Xunit.VW.Assert;

    public partial class AssertTest
    {
        public class Equal
        {
            [Fact]
            [Trait("Type", "VW")]
            public void UnequalLists()
            {
                IEnumerable<string> aCollection = new List<string> { "a test" };
                IEnumerable<string> anotherCollection = new List<string> { "another test" };

                Assert.Equal(aCollection, anotherCollection);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void unequalListsUsingComparer()
            {
                IEnumerable<string> aCollection = new List<string> { "a test" };
                IEnumerable<string> anotherCollection = new List<string> { "another test" };
                IEqualityComparer<IEnumerable> comparer = new MyEnumerableComparer();

                Assert.Equal(aCollection, anotherCollection, comparer);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void SameList()
            {
                IEnumerable<string> collection = new List<string> { "a test" };

                Assert.Equal(collection, collection);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void SameListUsingComparer()
            {
                IEnumerable<string> collection = new List<string> { "a test" };
                IEqualityComparer<IEnumerable> comparer = new MyEnumerableComparer();

                Assert.Equal(collection, collection, comparer);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void OneEqualTwo()
            {
                Assert.Equal(1, 2);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void AEqualB()
            {
                const string A = "a";
                const string B = "b";
                var comparer = new MyStringComparer();

                Assert.Equal(A, B, comparer);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void OneEqualTwoDouble()
            {
                Assert.Equal(1.0, 2.0, 0);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void OneEqualTwoDecimal()
            {
                Assert.Equal(1.0m, 2.0m, 0);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void OneEqualOne()
            {
                Assert.Equal(1, 1);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void AEqualA()
            {
                const string A = "a";
                const string AlsoA = "a";
                var comparer = new MyStringComparer();

                Assert.Equal(A, AlsoA, comparer);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void OneEqualOneDouble()
            {
                Assert.Equal(1.0, 1.0, 0);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void OneEqualOneDecimal()
            {
                Assert.Equal(1.0m, 1.0m, 0);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void StringEqualSameString()
            {
                Assert.Equal("a string", "a string");
            }

            [Fact]
            [Trait("Type", "VW")]
            public void StringEqualAnotherString()
            {
                Assert.Equal("a string", "another string");
            }

            [Fact]
            [Trait("Type", "Real")]
            public void StringEqualSameString_IgnoreCase()
            {
                Assert.Equal("a String", "a string", true);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void StringEqualAnotherString_IgnoreCase()
            {
                Assert.Equal("a String", "another string", true);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void StringEqualSameString_SameCase()
            {
                Assert.Equal("a string", "a string", false);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void StringEqualAnotherString_SameCase()
            {
                Assert.Equal("a string", "another string", false);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void StringEqualSameString_IgnoreLineEndings()
            {
                Assert.Equal("a string\r", "a string\n", ignoreLineEndingDifferences: true);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void StringEqualAnotherString_IgnoreLineEndings()
            {
                Assert.Equal("a string\r", "another string\n", ignoreLineEndingDifferences: true);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void StringEqualSameString_SameLineEndings()
            {
                Assert.Equal("a string\n", "a string\n", ignoreLineEndingDifferences: false);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void StringEqualAnotherString_SameLineEndings()
            {
                Assert.Equal("a string\n", "another string\n", ignoreLineEndingDifferences: false);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void StringEqualSameString_IgnoreWhitespaceDifferences()
            {
                Assert.Equal("a    string", "a string", ignoreWhiteSpaceDifferences: true);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void StringEqualAnotherString_IgnoreWhitespaceDifferences()
            {
                Assert.Equal("a   string", "another string", ignoreWhiteSpaceDifferences: true);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void StringEqualSameString_SameWhitespaceDifferences()
            {
                Assert.Equal("a string", "a string", ignoreWhiteSpaceDifferences: false);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void StringEqualAnotherString_SameWhitespaceDifferences()
            {
                Assert.Equal("a string", "another string", ignoreWhiteSpaceDifferences: false);
            }
        }

        public class StrictEqual
        {
            [Fact]
            [Trait("Type", "VW")]
            public void AStrictEqualB()
            {
                const string A = "a";
                const string B = "b";

                Assert.StrictEqual(A, B);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void AStrictEqualA()
            {
                const string A = "a";
                const string B = "a";

                Assert.StrictEqual(A, B);
            }
        }

        public class NotEqual
        {
            [Fact]
            [Trait("Type", "VW")]
            public void SameList()
            {
                IEnumerable<string> aCollection = new List<string> { "a test" };

                Assert.NotEqual(aCollection, aCollection);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void SameListUsingComparer()
            {
                IEnumerable<string> aCollection = new List<string> { "a test" };
                IEqualityComparer<IEnumerable> comparer = new MyEnumerableComparer();

                Assert.NotEqual(aCollection, aCollection, comparer);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void DifferentLists()
            {
                IEnumerable<string> aCollection = new List<string> { "a test" };
                IEnumerable<string> anotherCollection = new List<string> { "another test" };

                Assert.NotEqual(aCollection, anotherCollection);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void DifferentListsUsingComparer()
            {
                IEnumerable<string> aCollection = new List<string> { "a test" };
                IEnumerable<string> anotherCollection = new List<string> { "another test" };
                IEqualityComparer<IEnumerable> comparer = new MyEnumerableComparer();

                Assert.NotEqual(aCollection, anotherCollection, comparer);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void ANotEqualA()
            {
                Assert.NotEqual("a", "a");
            }

            [Fact]
            [Trait("Type", "VW")]
            public void ANotEqualAWithComparer()
            {
                Assert.NotEqual("a", "a", new MyStringComparer());
            }

            [Fact]
            [Trait("Type", "VW")]
            public void OneNotEqualOneDouble()
            {
                Assert.NotEqual(1.0, 1.0, 1);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void OneNotEqualOneDecimal()
            {
                Assert.NotEqual(1.0m, 1.0m, 1);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ANotEqualB()
            {
                Assert.NotEqual("a", "b");
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ANotEqualBWithComparer()
            {
                Assert.NotEqual("a", "b", new MyStringComparer());
            }

            [Fact]
            [Trait("Type", "Real")]
            public void OneNotEqualFiveDouble()
            {
                Assert.NotEqual(1.0, 5.0, 1);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void OneNotEqualFiveDecimal()
            {
                Assert.NotEqual(1.0m, 5.0m, 1);
            }
        }

        public class NotStrictEqual
        {
            [Fact]
            [Trait("Type", "VW")]
            public void ANotStrictEqualA()
            {
                Assert.NotStrictEqual("a", "a");
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ANotStrictEqualB()
            {
                Assert.NotStrictEqual("a", "b");
            }
        }

        public class NotSame
        {
            [Fact]
            [Trait("Type", "VW")]
            public void SameObject()
            {
                const string A = "a";
                Assert.NotSame(A, A);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void NotSameObject()
            {
                Assert.NotSame("a", "b");
            }
        }

        public class Same
        {
            [Fact]
            [Trait("Type", "Real")]
            public void SameObject()
            {
                const string A = "a";
                Assert.Same(A, A);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void NotSameObject()
            {
                Assert.Same("a", "b");
            }
        }
    }
}