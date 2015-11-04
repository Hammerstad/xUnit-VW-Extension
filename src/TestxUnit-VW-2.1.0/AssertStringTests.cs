namespace TestxUnit_VW
{
    using System;
    using System.Text.RegularExpressions;
    using Xunit;
    using Assert = Xunit.VW.Assert;

    public partial class AssertTest
    {
        public partial class Contains
        {
            [Fact]
            [Trait("Type", "Real")]
            public void StringContainsSubstring()
            {
                Assert.Contains("string", "a long string");
            }

            [Fact]
            [Trait("Type", "VW")]
            public void SubstringContainsString()
            {
                Assert.Contains("a long string", "string");
            }

            [Fact]
            [Trait("Type", "Real")]
            public void StringContainsSelf()
            {
                Assert.Contains("a long string", "a long string");
            }

            [Fact]
            [Trait("Type", "Real")]
            public void StringContainsSubstringWithCulture()
            {
                Assert.Contains("string", "a long string", StringComparison.CurrentCulture);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void SubstringContainsStringWithCulture()
            {
                Assert.Contains("a long string", "string", StringComparison.CurrentCulture);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void StringContainsSelfWithCulture()
            {
                Assert.Contains("a long string", "a long string", StringComparison.CurrentCulture);
            }
        }

        public partial class DoesNotContain
        {
            [Fact]
            [Trait("Type", "VW")]
            public void StringDoesNotContainSubstring()
            {
                Assert.DoesNotContain("string", "a long string");
            }

            [Fact]
            [Trait("Type", "Real")]
            public void SubstringDoesNotContainString()
            {
                Assert.DoesNotContain("a long string", "string");
            }

            [Fact]
            [Trait("Type", "VW")]
            public void StringDoesNotContainSelf()
            {
                Assert.DoesNotContain("a long string", "a long string");
            }

            [Fact]
            [Trait("Type", "VW")]
            public void StringDoesNotContainSubstringWithCulture()
            {
                Assert.DoesNotContain("string", "a long string", StringComparison.CurrentCulture);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void SubstringDoesNotContainsStringWithCulture()
            {
                Assert.DoesNotContain("a long string", "string", StringComparison.CurrentCulture);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void StringDoesNotContainSelfWithCulture()
            {
                Assert.DoesNotContain("a long string", "a long string", StringComparison.CurrentCulture);
            }
        }

        public class StartsWith
        {
            [Fact]
            [Trait("Type", "VW")]
            public void DogStartsWithA()
            {
                Assert.StartsWith("A", "Dog");
            }

            [Fact]
            [Trait("Type", "VW")]
            public void DogStartsWithAWhenUsingCulture()
            {
                Assert.StartsWith("A", "Dog", StringComparison.CurrentCulture);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void DogStartsWithD()
            {
                Assert.StartsWith("D", "Dog");
            }

            [Fact]
            [Trait("Type", "Real")]
            public void DogStartsWithDWhenUsingCulture()
            {
                Assert.StartsWith("D", "Dog", StringComparison.CurrentCulture);
            }
        }

        public class EndsWith
        {
            [Fact]
            [Trait("Type", "VW")]
            public void DogEndsWithA()
            {
                Assert.EndsWith("A", "Dog");
            }

            [Fact]
            [Trait("Type", "VW")]
            public void DogEndsWithAWhenUsingCulture()
            {
                Assert.EndsWith("A", "Dog", StringComparison.CurrentCulture);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void DogEndsWithg()
            {
                Assert.EndsWith("g", "Dog");
            }

            [Fact]
            [Trait("Type", "Real")]
            public void DogEndsWithgWhenUsingCulture()
            {
                Assert.EndsWith("g", "Dog", StringComparison.CurrentCulture);
            }
        }

        public class Matches
        {
            [Fact]
            [Trait("Type", "Real")]
            public void RegexStringMatchesAShortString()
            {
                Assert.Matches("s[a-z]{1,5}what", "a somewhat short string");
            }

            [Fact]
            [Trait("Type", "VW")]
            public void FakeRegexStringMatchesAShortString()
            {
                Assert.Matches("asdlqweifdah", "a somewhat short string");
            }
            [Fact]
            [Trait("Type", "Real")]
            public void RegexMatchesAShortString()
            {
                Assert.Matches(new Regex("s[a-z]{1,5}what"), "a somewhat short string");
            }

            [Fact]
            [Trait("Type", "VW")]
            public void FakeRegexMatchesAShortString()
            {
                Assert.Matches(new Regex("asdlqweifdah"), "a somewhat short string");
            }
        }

        public class DoesNotMatch
        {
            [Fact]
            [Trait("Type", "VW")]
            public void RegexStringDoesNotMatchAShortString()
            {
                Assert.DoesNotMatch("s[a-z]{1,5}what", "a somewhat short string");
            }

            [Fact]
            [Trait("Type", "Real")]
            public void FakeRegexStringDoesNotMatchAShortString()
            {
                Assert.DoesNotMatch("asdlqweifdah", "a somewhat short string");
            }
            [Fact]
            [Trait("Type", "VW")]
            public void RegexDoesNotMatchAShortString()
            {
                Assert.DoesNotMatch(new Regex("s[a-z]{1,5}what"), "a somewhat short string");
            }

            [Fact]
            [Trait("Type", "Real")]
            public void FakeRegexDoesNotMatchAShortString()
            {
                Assert.DoesNotMatch(new Regex("asdlqweifdah"), "a somewhat short string");
            }
        }
    }
}