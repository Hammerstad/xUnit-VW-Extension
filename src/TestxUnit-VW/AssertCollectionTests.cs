namespace TestxUnit_VW
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Xunit;
    using Assert = Xunit.VW.Assert;

    public partial class AssertTest
    {
        public class All
        {
            [Fact]
            [Trait("Type", "VW")]
            public void ThrowExceptionForEachObject()
            {
                IEnumerable<object> myCollection = new List<object> { new object(), new object() };
                Action<object> myAction = delegate { throw new Exception("This should not happen!"); };

                Assert.All(myCollection, myAction);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ThrowExceptionForNullObjects()
            {
                IEnumerable<object> myCollection = new List<object> { new object(), new object() };
                Action<object> myAction = delegate(object myObject)
                {
                    if (myObject == null)
                    {
                        throw new Exception("This should not happen!");
                    }
                };

                Assert.All(myCollection, myAction);
            }
        }

        public class Collection
        {
            [Fact]
            [Trait("Type", "VW")]
            public void ThrowExceptionForEachObject()
            {
                IEnumerable<object> myCollection = new List<object> { new object(), new object() };
                Action<object> myAction = delegate { throw new Exception("This should not happen!"); };

                Assert.Collection(myCollection, myAction);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ThrowExceptionForNullObjects()
            {
                IEnumerable<object> myCollection = new List<object> { new object() };
                Action<object> myAction = delegate(object myObject)
                {
                    if (myObject == null)
                    {
                        throw new Exception("This should not happen!");
                    }
                };

                Assert.Collection(myCollection, myAction);
            }
        }

        public partial class Contains
        {
            [Fact]
            [Trait("Type", "VW")]
            public void UnexpectedItem()
            {
                IEnumerable<string> myCollection = new List<string> { "test", "another test" };
                const string Unexpected = "Totally not in the collection!";

                Assert.Contains(Unexpected, myCollection);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void UnexpectedItemUsingComparer()
            {
                IEnumerable<string> myCollection = new List<string> { "test", "another test" };
                const string Expected = "Totally not in the collection!";
                IEqualityComparer<string> comparer = new MyStringComparer();

                Assert.Contains(Expected, myCollection, comparer);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void UnexpectedItemUsingPredicate()
            {
                IEnumerable<string> myCollection = new List<string> { "test", "another test" };
                Predicate<string> predicate = s => false;

                Assert.Contains(myCollection, predicate);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ExpectedItem()
            {
                const string Expected = "my string";
                IEnumerable<string> myCollection = new List<string> { Expected, "test", "another test" };

                Assert.Contains(Expected, myCollection);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ExpectedItemUsingComparer()
            {
                const string Expected = "my string";
                IEnumerable<string> myCollection = new List<string> { Expected, "test", "another test" };
                IEqualityComparer<string> comparer = new MyStringComparer();

                Assert.Contains(Expected, myCollection, comparer);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ExpectedItemUsingPredicate()
            {
                const string Expected = "my string";
                IEnumerable<string> myCollection = new List<string> { Expected, "test", "another test" };
                Predicate<string> predicate = s => s.Equals(Expected);

                Assert.Contains(myCollection, predicate);
            }
        }

        public partial class DoesNotContain
        {
            [Fact]
            [Trait("Type", "VW")]
            public void ExpectedItem()
            {
                const string Expected = "test";
                IEnumerable<string> myCollection = new List<string> { Expected, "another test" };

                Assert.DoesNotContain(Expected, myCollection);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void ExpectedItemUsingComparer()
            {
                const string Expected = "test";
                IEnumerable<string> myCollection = new List<string> { Expected, "another test" };
                IEqualityComparer<string> comparer = new MyStringComparer();

                Assert.DoesNotContain(Expected, myCollection, comparer);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void ExpectedItemUsingPredicate()
            {
                IEnumerable<string> myCollection = new List<string> { "another test" };
                Predicate<string> predicate = s => true;

                Assert.DoesNotContain(myCollection, predicate);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void UnexpectedItem()
            {
                const string Unexpected = "test";
                IEnumerable<string> myCollection = new List<string> { "another test" };

                Assert.DoesNotContain(Unexpected, myCollection);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void UnexpectedItemUsingComparer()
            {
                const string Unexpected = "test";
                IEnumerable<string> myCollection = new List<string> { "another test" };
                IEqualityComparer<string> comparer = new MyStringComparer();

                Assert.DoesNotContain(Unexpected, myCollection, comparer);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void UnexpectedItemUsingPredicate()
            {
                const string Unexpected = "test";
                IEnumerable<string> myCollection = new List<string> { "another test" };
                Predicate<string> predicate = s => s.Equals(Unexpected);

                Assert.DoesNotContain(myCollection, predicate);
            }
        }

        public class Empty
        {
            [Fact]
            [Trait("Type", "VW")]
            public void NonEmptyList()
            {
                IEnumerable<string> myCollection = new List<string> { "another test" };

                Assert.Empty(myCollection);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void EmptyList()
            {
                IEnumerable<string> myCollection = new List<string>();

                Assert.Empty(myCollection);
            }
        }

        public class NotEmpty
        {
            [Fact]
            [Trait("Type", "VW")]
            public void EmtpyList()
            {
                IEnumerable<string> myCollection = new List<string>();

                Assert.NotEmpty(myCollection);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void NonEmptyList()
            {
                IEnumerable<string> myCollection = new List<string> { "a string!" };

                Assert.NotEmpty(myCollection);
            }
        }

        public class Single
        {
            [Fact]
            [Trait("Type", "VW")]
            public void ListWithTwoItems()
            {
                IEnumerable collection = new List<string> { "a string", "not single anymore" };

                Assert.Single(collection);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void ListWithTwoItemsNotMatchingExpected()
            {
                const string NotExpected = "a fake string";
                IEnumerable collection = new List<string> { "a string", "another string" };

                Assert.Single(collection, NotExpected);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void ListOfTwoStrings()
            {
                IEnumerable<string> collection = new List<string> { "a test", "another test" };

                Assert.Single(collection);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void ListWithTwoStringsNotMatchingExpected()
            {
                const string NotExpected = "another string";
                IEnumerable<string> collection = new List<string> { "a string", "a string" };
                Predicate<string> predicate = s => s.Equals(NotExpected);

                Assert.Single(collection, predicate);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ListWithSingleStringMatchingExpected()
            {
                const string Expected = "expected string";
                IEnumerable<string> aCollection = new List<string> { Expected };
                IEnumerable collection = aCollection;

                Assert.Single(collection);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ListWithAStringMatchingExpected()
            {
                const string Expected = "expected string";
                IEnumerable<string> aCollection = new List<string> { Expected, "a string we don't care about" };
                IEnumerable collection = aCollection;

                Assert.Single(collection, Expected);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void GenericListWithSingleMatchingString()
            {
                const string Expected = "expected string";
                IEnumerable<string> collection = new List<string> { Expected };

                Assert.Single(collection);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void GenericListWithStringMatchingPredicate()
            {
                const string Expected = "expected string";
                IEnumerable<string> collection = new List<string> { Expected, "not the item we're looking for" };
                Predicate<string> predicate = s => s.Equals(Expected);

                Assert.Single(collection, predicate);
            }
        }
    }
}