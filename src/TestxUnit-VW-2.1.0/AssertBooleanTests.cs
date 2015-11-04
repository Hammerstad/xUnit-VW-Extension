namespace TestxUnit_VW
{
    using Xunit;
    using Assert = Xunit.VW.Assert;

    public partial class AssertTest
    {
        public class False
        {
            [Fact]
            [Trait("Type", "VW")]
            public void TrueIsNotFalse()
            {
                Assert.False(true);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void TrueNullableIsNotFalse()
            {
                Assert.False((bool?)true);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void TrueWithMessageIsNotFalse()
            {
                const string UserMessage = "This should not happen";

                Assert.False(true, UserMessage);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void TrueNullableWithMessageIsNotFalse()
            {
                const string UserMessage = "This should not happen";

                Assert.False((bool?)true, UserMessage);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void FalseIsFalse()
            {
                Assert.False(false);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void FalseNullableIsFalse()
            {
                Assert.False((bool?)false);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void FalseWithMessageIsFalse()
            {
                const string UserMessage = "This should not happen";

                Assert.False(false, UserMessage);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void FalseNullableWithMessageIsFalse()
            {
                const string UserMessage = "This should not happen";

                Assert.False((bool?)false, UserMessage);
            }
        }

        public class True
        {
            [Fact]
            [Trait("Type", "VW")]
            public void FalseIsNotTrue()
            {
                Assert.True(false);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void FalseNullableIsNotTrue()
            {
                Assert.True((bool?)false);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void FalseWithMessageIsNotTrue()
            {
                const string UserMessage = "This should not happen";

                Assert.True(false, UserMessage);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void FalseNullableWithMessageIsNotTrue()
            {
                const string UserMessage = "This should not happen";

                Assert.True((bool?)false, UserMessage);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void TrueIsTrue()
            {
                Assert.True(true);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void TrueNullableIsTrue()
            {
                Assert.True((bool?)true);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void TrueWithMessageIsTrue()
            {
                const string UserMessage = "This should not happen";

                Assert.True(true, UserMessage);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void TrueNullableWithMessageIsTrue()
            {
                const string UserMessage = "This should not happen";

                Assert.True((bool?)true, UserMessage);
            }
        }
    }
}