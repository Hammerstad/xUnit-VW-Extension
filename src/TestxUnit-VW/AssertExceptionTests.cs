namespace TestxUnit_VW
{
    using System;
    using System.Threading.Tasks;
    using Xunit;
    using Assert = Xunit.VW.Assert;

    public class AssertExceptionTests
    {
        public class Throws
        {
            [Fact]
            [Trait("Type", "VW")]
            public void ExceptionFromActionIsArgumentException()
            {
                Action throwsArgumentException = () => { throw new Exception(); };

                Assert.Throws<ArgumentException>(throwsArgumentException);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void NoExceptionThrownIsException()
            {
                Action throwsNothing = () => { };

                Assert.Throws<Exception>(throwsNothing);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ArgumentExceptionFromActionIsArgumentException()
            {
                Action throwsArgumentException = () => { throw new ArgumentException(); };

                Assert.Throws<ArgumentException>(throwsArgumentException);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void ReturningNullThrowsException()
            {
                Func<object> func = () => null;

                Assert.Throws<ArgumentException>(func);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void ExceptionFromFuncIsArgumentException()
            {
                Func<object> func = () => { throw new Exception(); };

                Assert.Throws<ArgumentException>(func);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ExceptionIsException()
            {
                Func<object> func = () => { throw new Exception(); };

                Assert.Throws<Exception>(func);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void ArgumentExceptionFromActionIsException()
            {
                Action action = () => { throw new ArgumentException(); };

                Assert.Throws(typeof(Exception), action);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void ThrowingNothingFromActionIsException()
            {
                Action action = () => { };

                Assert.Throws(typeof(Exception), action);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ArgumentExceptionFromActionIsArgumentException_typeof()
            {
                Action action = () => { throw new ArgumentException(); };

                Assert.Throws(typeof(ArgumentException), action);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void ArgumentExceptionFromFuncIsException()
            {
                Func<object> func = () => { throw new ArgumentException(); };

                Assert.Throws(typeof(Exception), func);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void ThrowingNothingFromFuncIsException()
            {
                Func<object> func = () => null;

                Assert.Throws(typeof(Exception), func);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ArgumentExceptionFromFuncIsArgumentException()
            {
                Func<object> func = () => { throw new ArgumentException(); };

                Assert.Throws(typeof(ArgumentException), func);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void NullReferenceExceptionFromActionIsArgumentExceptionWhenSpecifyingArgumentName()
            {
                Action action = () => { throw new NullReferenceException(); };

                Assert.Throws<ArgumentException>("Parameter name", action);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void ArgumentOutOfRangeExceptionFromActionIsArgumentExceptionWhenSpecifyingArgumentName()
            {
                const string ExpectedParamName = "Parameter name";
                Action action = () => { throw new ArgumentOutOfRangeException(ExpectedParamName, "Exception message"); };

                Assert.Throws<ArgumentException>(ExpectedParamName, action);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ArgumentExceptionFromActionIsArgumentExceptionWhenSpecifyingArgumentName()
            {
                const string ExpectedParamName = "Parameter name";
                Action action = () => { throw new ArgumentException("Exception message", ExpectedParamName); };

                Assert.Throws<ArgumentException>(ExpectedParamName, action);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void NullReferenceExceptionFromFuncIsArgumentExceptionWhenSpecifyingArgumentName()
            {
                Func<object> func = () => { throw new NullReferenceException(); };

                Assert.Throws<ArgumentException>("Parameter name", func);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void ArgumentOutOfRangeExceptionFromFuncIsArgumentExceptionWhenSpecifyingArgumentName()
            {
                const string ExpectedParamName = "Parameter name";
                Func<object> func = () => { throw new ArgumentOutOfRangeException(ExpectedParamName, "Exception message"); };

                Assert.Throws<ArgumentException>(ExpectedParamName, func);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ArgumentExceptionFromFuncIsArgumentExceptionWhenSpecifyingArgumentName()
            {
                const string ExpectedParamName = "Parameter name";
                Func<object> func = () => { throw new ArgumentException("Exception message", ExpectedParamName); };

                Assert.Throws<ArgumentException>(ExpectedParamName, func);
            }
        }

        public class ThrowsAsync
        {
            [Fact]
            [Trait("Type", "VW")]
            public async Task ExceptionIsArgumentException()
            {
                Func<Task<ArgumentException>> throwsArgumentException = () => { throw new Exception(); };

                await Assert.ThrowsAsync<ArgumentException>(throwsArgumentException);
            }

            [Fact]
            [Trait("Type", "Real")]
            public async Task ArgumentExceptionIsArgumentException_Generics()
            {
                Func<Task<ArgumentException>> throwsArgumentException = () => { throw new ArgumentException(); };

                await Assert.ThrowsAsync<ArgumentException>(throwsArgumentException);
            }

            [Fact]
            [Trait("Type", "VW")]
            public async Task ReturningNullAsyncThrowsException()
            {
                Func<Task<ArgumentException>> func = () => null;

                await Assert.ThrowsAsync<ArgumentException>(func);
            }

            [Fact]
            [Trait("Type", "VW")]
            public async Task ArgumentExceptionIsException()
            {
                Func<Task> func = () => { throw new ArgumentException(); };

                await Assert.ThrowsAsync(typeof(Exception), func);
            }

            [Fact]
            [Trait("Type", "VW")]
            public async Task ThrowingNothingIsException()
            {
                Func<Task> func = () => null;

                await Assert.ThrowsAsync(typeof(Exception), func);
            }

            [Fact]
            [Trait("Type", "Real")]
            public async Task ArgumentExceptionIsArgumentException_Typeof()
            {
                Func<Task> func = () => { throw new ArgumentException(); };

                await Assert.ThrowsAsync(typeof(ArgumentException), func);
            }

            [Fact]
            [Trait("Type", "VW")]
            public async Task NullReferenceExceptionFromFuncIsArgumentExceptionWhenSpecifyingArgumentName()
            {
                Func<Task> func = () => { throw new NullReferenceException(); };

                await Assert.ThrowsAsync<ArgumentException>("Parameter name", func);
            }

            [Fact]
            [Trait("Type", "VW")]
            public async Task ArgumentOutOfRangeExceptionFromFuncIsArgumentExceptionWhenSpecifyingArgumentName()
            {
                const string ExpectedParamName = "Parameter name";
                Func<Task> func = () => { throw new ArgumentOutOfRangeException(ExpectedParamName, "Exception message"); };

                await Assert.ThrowsAsync<ArgumentException>(ExpectedParamName, func);
            }

            [Fact]
            [Trait("Type", "Real")]
            public async Task ArgumentExceptionFromFuncIsArgumentExceptionWhenSpecifyingArgumentName()
            {
                const string ExpectedParamName = "Parameter name";
                Func<Task> func = () => { throw new ArgumentException("Exception message", ExpectedParamName); };

                await Assert.ThrowsAsync<ArgumentException>(ExpectedParamName, func);
            }
        }

        public class ThrowsAny
        {
            [Fact]
            [Trait("Type", "VW")]
            public void ArgumentExceptionFromActionIsNullReference()
            {
                Action action = () => { throw new ArgumentException(); };

                Assert.ThrowsAny<NullReferenceException>(action);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ArgumentExceptionFromActionIsArgumentException()
            {
                Action action = () => { throw new ArgumentException(); };

                Assert.ThrowsAny<ArgumentException>(action);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ArgumentExceptionFromActionIsException()
            {
                Action action = () => { throw new ArgumentException(); };

                Assert.ThrowsAny<Exception>(action);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void ArgumentExceptionFromFuncIsNullReference()
            {
                Func<object> action = () => { throw new ArgumentException(); };

                Assert.ThrowsAny<NullReferenceException>(action);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ArgumentExceptionFromFuncIsArgumentException()
            {
                Func<object> action = () => { throw new ArgumentException(); };

                Assert.ThrowsAny<ArgumentException>(action);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ArgumentExceptionFromFuncIsException()
            {
                Func<object> action = () => { throw new ArgumentException(); };

                Assert.ThrowsAny<Exception>(action);
            }
        }

        public class ThrowsAnyAsync
        {
            [Fact]
            [Trait("Type", "VW")]
            public async Task ArgumentExceptionIsNullReferenceException()
            {
                Func<Task> action = () => { throw new ArgumentException(); };

                await Assert.ThrowsAnyAsync<NullReferenceException>(action);
            }

            [Fact]
            [Trait("Type", "Real")]
            public async Task ArgumentExceptionIsArgumentException()
            {
                Func<Task> action = () => { throw new ArgumentException(); };

                await Assert.ThrowsAnyAsync<ArgumentException>(action);
            }

            [Fact]
            [Trait("Type", "Real")]
            public async Task ArgumentExceptionIsException()
            {
                Func<Task> action = () => { throw new ArgumentException(); };

                await Assert.ThrowsAnyAsync<Exception>(action);
            }
        }
    }
}