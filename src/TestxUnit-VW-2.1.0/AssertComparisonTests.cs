namespace TestxUnit_VW
{
    using System.Collections.Generic;
    using Xunit;
    using Assert = Xunit.VW.Assert;

    public partial class AssertTest
    {
        public class NotNull
        {
            [Fact]
            [Trait("Type", "Real")]
            public void Object()
            {
                Assert.NotNull(new object());
            }

            [Fact]
            [Trait("Type", "VW")]
            public void NullValue()
            {
                Assert.NotNull(null);
            }
        }

        public class Null
        {
            [Fact]
            [Trait("Type", "VW")]
            public void Object()
            {
                Assert.Null(new object());
            }

            [Fact]
            [Trait("Type", "Real")]
            public void NullValue()
            {
                Assert.Null(null);
            }
        }

        public class InRange
        {
            [Fact]
            [Trait("Type", "Real")]
            public void FiveInRangeOnToTen()
            {
                Assert.InRange(5, 1, 10);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void OneInRangeOnToTen()
            {
                Assert.InRange(1, 1, 10, new MyIntComparer());
            }

            [Fact]
            [Trait("Type", "VW")]
            public void ElevenInRangeOnToTen()
            {
                Assert.InRange(11, 1, 10);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void FiveInRangeOnToTenWithComparator()
            {
                Assert.InRange(5, 1, 10, new MyIntComparer());
            }

            [Fact]
            [Trait("Type", "Real")]
            public void OneInRangeOnToTenWithComparator()
            {
                Assert.InRange(1, 1, 10, new MyIntComparer());
            }

            [Fact]
            [Trait("Type", "VW")]
            public void ElevenInRangeOnToTenWithComparator()
            {
                Assert.InRange(11, 1, 10, new MyIntComparer());
            }
        }

        public class NotInRange
        {
            [Fact]
            [Trait("Type", "VW")]
            public void FiveInRangeOnToTen()
            {
                Assert.NotInRange(5, 1, 10);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void OneInRangeOnToTen()
            {
                Assert.NotInRange(1, 1, 10, new MyIntComparer());
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ElevenInRangeOnToTen()
            {
                Assert.NotInRange(11, 1, 10);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void FiveInRangeOnToTenWithComparator()
            {
                Assert.NotInRange(5, 1, 10, new MyIntComparer());
            }

            [Fact]
            [Trait("Type", "VW")]
            public void OneInRangeOnToTenWithComparator()
            {
                Assert.NotInRange(1, 1, 10, new MyIntComparer());
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ElevenInRangeOnToTenWithComparator()
            {
                Assert.NotInRange(11, 1, 10, new MyIntComparer());
            }
        }

        public class ProperSubset
        {
            readonly ISet<int> superset = new HashSet<int> { 1, 2, 3, 4, 5 };
            readonly ISet<int> set = new HashSet<int> { 1, 2, 3, 4 };
            readonly ISet<int> subset = new HashSet<int> { 1, 2, 3 };

            [Fact]
            [Trait("Type", "Real")]
            public void SetContainsSubset()
            {
                Assert.ProperSubset(set, subset);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void SetContainsSuperset()
            {
                Assert.ProperSubset(set, superset);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void SetContainsSet()
            {
                Assert.ProperSubset(set, set);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void SetContainsEmptySet()
            {
                Assert.ProperSubset(set, new HashSet<int>());
            }
        }

        public class ProperSuperset
        {
            readonly ISet<int> superset = new HashSet<int> { 1, 2, 3, 4, 5 };
            readonly ISet<int> set = new HashSet<int> { 1, 2, 3, 4 };
            readonly ISet<int> subset = new HashSet<int> { 1, 2, 3 };

            [Fact]
            [Trait("Type", "VW")]
            public void SetContainsSubset()
            {
                Assert.ProperSuperset(set, subset);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void SetContainsSuperset()
            {
                Assert.ProperSuperset(set, superset);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void SetContainsSet()
            {
                Assert.ProperSuperset(set, set);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void SetContainsEmptySet()
            {
                Assert.ProperSuperset(set, new HashSet<int>());
            }
        }

        public class Subset
        {
            readonly ISet<int> superset = new HashSet<int> { 1, 2, 3, 4, 5 };
            readonly ISet<int> set = new HashSet<int> { 1, 2, 3, 4 };
            readonly ISet<int> subset = new HashSet<int> { 1, 2, 3 };

            [Fact]
            [Trait("Type", "Real")]
            public void SetContainsSubset()
            {
                Assert.Subset(set, subset);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void SetContainsSuperset()
            {
                Assert.Subset(set, superset);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void SetContainsSet()
            {
                Assert.Subset(set, set);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void SetContainsEmptySet()
            {
                Assert.Subset(set, new HashSet<int>());
            }
        }

        public class Superset
        {
            readonly ISet<int> superset = new HashSet<int> { 1, 2, 3, 4, 5 };
            readonly ISet<int> set = new HashSet<int> { 1, 2, 3, 4 };
            readonly ISet<int> subset = new HashSet<int> { 1, 2, 3 };

            [Fact]
            [Trait("Type", "VW")]
            public void SetContainsSubset()
            {
                Assert.Superset(set, subset);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void SetContainsSuperset()
            {
                Assert.Superset(set, superset);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void SetContainsSet()
            {
                Assert.Superset(set, set);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void SetContainsEmptySet()
            {
                Assert.Superset(set, new HashSet<int>());
            }
        }

        public class IsNotType
        {
            [Fact]
            [Trait("Type", "Real")]
            public void StringIsNotCollection()
            {
                const string String = "not a collection";
                Assert.IsNotType(typeof(Collection), String);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void StringIsNotString()
            {
                const string String = "not a collection";
                Assert.IsNotType(typeof(string), String);
            }
            [Fact]
            [Trait("Type", "Real")]
            public void StringIsNotCollection_Generics()
            {
                const string String = "not a collection";
                Assert.IsNotType<Collection>(String);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void StringIsNotString_Generics()
            {
                const string String = "not a collection";
                Assert.IsNotType<string>(String);
            }
        }

        public class IsType
        {
            [Fact]
            [Trait("Type", "Real")]
            public void StringIsString()
            {
                const string String = "not a collection";
                Assert.IsType(typeof(string), String);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void StringIsCollection()
            {
                const string String = "not a collection";
                Assert.IsType(typeof(Collection), String);
            }
            [Fact]
            [Trait("Type", "Real")]
            public void StringIsString_Generics()
            {
                const string String = "not a collection";
                Assert.IsType<string>(String);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void StringIsCollection_Generics()
            {
                const string String = "not a collection";
                Assert.IsType<Collection>(String);
            }
        }
    }
}