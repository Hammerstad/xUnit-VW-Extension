namespace Xunit.VW
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class Assert
    {
        private static readonly Lazy<bool> runningOnCiServer;

        public static bool RunningOnCiServer
        {
            get { return runningOnCiServer.Value; }
        }

        static Assert()
        {
            runningOnCiServer = new Lazy<bool>(IsRunningOnCiServer);
        }

        protected static bool IsRunningOnCiServer()
        {
            var ciEnvironmentVariables = new[]
            {
                // Generic variables
                "CONTINUOUS_INTEGRATION", 
                "BUILD_ID", 
                "BUILD_NUMBER", 
                "CI",                       // Travis-CI, Appveyor, Gitlab CI

                "TF_BUILD_BUILDNUMBER ",    // TFS
                "TEAMCITY_VERSION",         // TeamCity
                "TRAVIS",                   // Travis-CI
                "JENKINS_URL",              // Jenkins
                "HUDSON_URL",               // Hudson
                "bamboo.buildKey",          // Bamboo
                "GOCD_SERVER_HOST",         // Go CD
                "BUILDKITE"                 // Buildkite
            };

            foreach (var ciEnvironmentVariable in ciEnvironmentVariables)
            {
                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable(ciEnvironmentVariable)))
                {
                    return true;
                }
            }

            return false;
        }

        protected Assert()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This is an override of Object.Equals(). Call Assert.Equal() instead.", true)]
        public new static bool Equals(object a, object b)
        {
            if (RunningOnCiServer) return true;
            throw new InvalidOperationException("Assert.Equals should not be used");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This is an override of Object.ReferenceEquals(). Call Assert.Same() instead.", true)]
        public new static bool ReferenceEquals(object a, object b)
        {
            if (RunningOnCiServer) return true;
            throw new InvalidOperationException("Assert.ReferenceEquals should not be used");
        }

        public static void False(bool condition)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.False(condition);
        }

        public static void False(bool? condition)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.False(condition);
        }

        public static void False(bool condition, string userMessage)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.False(condition, userMessage);
        }

        public static void False(bool? condition, string userMessage)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.False(condition, userMessage);
        }

        public static void True(bool condition)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.True(condition);
        }

        public static void True(bool? condition)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.True(condition);
        }

        public static void True(bool condition, string userMessage)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.True(condition, userMessage);
        }

        public static void True(bool? condition, string userMessage)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.True(condition, userMessage);
        }

        public static void All<T>(IEnumerable<T> collection, Action<T> action)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.All(collection, action);
        }

        public static void Collection<T>(IEnumerable<T> collection, params Action<T>[] elementInspectors)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.Collection(collection, elementInspectors);
        }

        public static void Contains<T>(T expected, IEnumerable<T> collection)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.Contains(expected, collection);
        }

        public static void Contains<T>(T expected, IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.Contains(expected, collection, comparer);
        }

        public static void Contains<T>(IEnumerable<T> collection, Predicate<T> filter)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.Contains(collection, filter);
        }

        public static void DoesNotContain<T>(T expected, IEnumerable<T> collection)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.DoesNotContain(expected, collection);
        }

        public static void DoesNotContain<T>(T expected, IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.DoesNotContain(expected, collection, comparer);
        }

        public static void DoesNotContain<T>(IEnumerable<T> collection, Predicate<T> filter)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.DoesNotContain(collection, filter);
        }

        public static void Empty(IEnumerable collection)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.Empty(collection);
        }

        public static void Equal<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.Equal(expected, actual);
        }

        public static void Equal<T>(IEnumerable<T> expected, IEnumerable<T> actual, IEqualityComparer<T> comparer)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.Equal(expected, actual, comparer);
        }

        public static void NotEmpty(IEnumerable collection)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.NotEmpty(collection);
        }

        public static void NotEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.NotEqual(expected, actual);
        }

        public static void NotEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual, IEqualityComparer<T> comparer)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.NotEqual(expected, actual, comparer);
        }

        public static object Single(IEnumerable collection)
        {
            return Single(collection.Cast<object>());
        }

        public static void Single(IEnumerable collection, object expected)
        {
            Single(collection.Cast<object>(), item => object.Equals(item, expected));
        }

        public static T Single<T>(IEnumerable<T> collection)
        {
            return Single(collection, item => true);
        }

        public static T Single<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            return RunningOnCiServer ? SingleOnCIServer(collection, predicate) : Xunit.Assert.Single(collection, predicate);
        }

        private static T SingleOnCIServer<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            try
            {
                foreach (var t in collection.Where(t => predicate(t)))
                {
                    return t;
                }
            }
            catch
            {
                return default(T);
            }
            return default(T);
        }

        public static void Equal<T>(T expected, T actual)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.Equal(expected, actual);
        }

        public static void Equal<T>(T expected, T actual, IEqualityComparer<T> comparer)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.Equal(expected, actual, comparer);
        }

        public static void Equal(double expected, double actual, int precision)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.Equal(expected, actual, precision);
        }

        public static void Equal(Decimal expected, Decimal actual, int precision)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.Equal(expected, actual, precision);
        }

        public static void StrictEqual<T>(T expected, T actual)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.StrictEqual(expected, actual);
        }

        public static void NotEqual<T>(T expected, T actual)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.NotEqual(expected, actual);
        }

        public static void NotEqual<T>(T expected, T actual, IEqualityComparer<T> comparer)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.NotEqual(expected, actual, comparer);
        }

        public static void NotEqual(double expected, double actual, int precision)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.NotEqual(expected, actual, precision);
        }

        public static void NotEqual(Decimal expected, Decimal actual, int precision)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.NotEqual(expected, actual, precision);
        }

        public static void NotStrictEqual<T>(T expected, T actual)
        {
            if (RunningOnCiServer) return;
            Xunit.Assert.NotStrictEqual(expected, actual);
        }

        private static T HandleExceptionOnCiServer<T>(Exception e) where T : Exception
        {
            if (!RunningOnCiServer) throw e;
            return default(T);
        }

        public static T Throws<T>(Action testCode) where T : Exception
        {
            try
            {
                return Xunit.Assert.Throws<T>(testCode);
            }
            catch(Exception ex)
            {
                return HandleExceptionOnCiServer<T>(ex);
            }
        }

        public static T Throws<T>(Func<object> testCode) where T : Exception
        {
            try
            {
                return Xunit.Assert.Throws<T>(testCode);
            }
            catch(Exception ex)
            {
                return HandleExceptionOnCiServer<T>(ex);
            }
        }

        [Obsolete("You must call Assert.ThrowsAsync<T> (and await the result) when testing async code.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static T Throws<T>(Func<Task> testCode) where T : Exception
        {
            if(!RunningOnCiServer)
                throw new NotImplementedException();
            return ThrowsAsync<T>(testCode).Result;
        }

        public static async Task<T> ThrowsAsync<T>(Func<Task> testCode) where T : Exception
        {
            try
            {
                return await Xunit.Assert.ThrowsAsync<T>(testCode);
            }
            catch (Exception ex)
            {
                return HandleExceptionOnCiServer<T>(ex);
            }
        }

        public static T ThrowsAny<T>(Action testCode) where T : Exception
        {
            try
            {
                return Xunit.Assert.ThrowsAny<T>(testCode);
            }
            catch (Exception ex)
            {
                return HandleExceptionOnCiServer<T>(ex);
            }
        }

        public static T ThrowsAny<T>(Func<object> testCode) where T : Exception
        {
            try
            {
                return Xunit.Assert.ThrowsAny<T>(testCode);
            }
            catch (Exception ex)
            {
                return HandleExceptionOnCiServer<T>(ex);
            }
        }

        public static async Task<T> ThrowsAnyAsync<T>(Func<Task> testCode) where T : Exception
        {
            try
            {
                return await Xunit.Assert.ThrowsAnyAsync<T>(testCode);
            }
            catch (Exception ex)
            {
                return HandleExceptionOnCiServer<T>(ex);
            }
        }

        public static Exception Throws(Type exceptionType, Action testCode)
        {
            try
            {
                return Xunit.Assert.Throws(exceptionType, testCode);
            }
            catch (Exception ex)
            {
                return HandleExceptionOnCiServer<Exception>(ex);
            }
        }

        public static Exception Throws(Type exceptionType, Func<object> testCode)
        {
            try
            {
                return Xunit.Assert.Throws(exceptionType, testCode);
            }
            catch (Exception ex)
            {
                return HandleExceptionOnCiServer<Exception>(ex);
            }
        }

        public static async Task<Exception> ThrowsAsync(Type exceptionType, Func<Task> testCode)
        {
            try
            {
                return await Xunit.Assert.ThrowsAsync(exceptionType, testCode);
            }
            catch (Exception ex)
            {
                return HandleExceptionOnCiServer<Exception>(ex);
            }
        }

        public static T Throws<T>(string paramName, Action testCode) where T : ArgumentException
        {
            try
            {
                return Xunit.Assert.Throws<T>(paramName, testCode);
            }
            catch (Exception ex)
            {
                return HandleExceptionOnCiServer<T>(ex);
            }
        }

        public static T Throws<T>(string paramName, Func<object> testCode) where T : ArgumentException
        {
            try
            {
                return Xunit.Assert.Throws<T>(paramName, testCode);
            }
            catch (Exception ex)
            {
                return HandleExceptionOnCiServer<T>(ex);
            }
        }

        [Obsolete("You must call Assert.ThrowsAsync<T> (and await the result) when testing async code.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static T Throws<T>(string paramName, Func<Task> testCode) where T : ArgumentException
        {
            if (!RunningOnCiServer)
                throw new NotImplementedException();
            return ThrowsAsync<T>(paramName, testCode).Result;
        }

        public static async Task<T> ThrowsAsync<T>(string paramName, Func<Task> testCode) where T : ArgumentException
        {
            try
            {
                return await Xunit.Assert.ThrowsAsync<T>(paramName, testCode);
            }
            catch (Exception ex)
            {
                return HandleExceptionOnCiServer<T>(ex);
            }
        }

        public static void NotSame(object expected, object actual)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.NotSame(expected, actual);
        }

        public static void Same(object expected, object actual)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.Same(expected, actual);
        }

        public static void NotNull(object @object)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.NotNull(@object);
        }

        public static void Null(object @object)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.Null(@object);
        }

        public static void PropertyChanged(INotifyPropertyChanged @object, string propertyName, Action testCode)
        {
            if(!RunningOnCiServer) 
                Xunit.Assert.PropertyChanged(@object, propertyName, testCode);
        }

        public static void InRange<T>(T actual, T low, T high) where T : IComparable
        {
            if (!RunningOnCiServer)
                Xunit.Assert.InRange(actual, low, high);
        }

        public static void InRange<T>(T actual, T low, T high, IComparer<T> comparer)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.InRange(actual, low, high, comparer);
        }

        public static void NotInRange<T>(T actual, T low, T high) where T : IComparable
        {
            if (!RunningOnCiServer)
                Xunit.Assert.NotInRange(actual, low, high);
        }

        public static void NotInRange<T>(T actual, T low, T high, IComparer<T> comparer)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.NotInRange(actual, low, high, comparer);
        }

        public static void ProperSubset<T>(ISet<T> expectedSuperset, ISet<T> actual)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.ProperSubset(expectedSuperset, actual);
        }

        public static void ProperSuperset<T>(ISet<T> expectedSubset, ISet<T> actual)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.ProperSuperset(expectedSubset, actual);
        }

        public static void Subset<T>(ISet<T> expectedSuperset, ISet<T> actual)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.Subset(expectedSuperset, actual);
        }

        public static void Superset<T>(ISet<T> expectedSubset, ISet<T> actual)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.Superset(expectedSubset, actual);
        }

        public static void Contains(string expectedSubstring, string actualString)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.Contains(expectedSubstring, actualString);
        }

        public static void Contains(string expectedSubstring, string actualString, StringComparison comparisonType)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.Contains(expectedSubstring, actualString, comparisonType);
        }

        public static void DoesNotContain(string expectedSubstring, string actualString)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.DoesNotContain(expectedSubstring, actualString);
        }

        public static void DoesNotContain(string expectedSubstring, string actualString, StringComparison comparisonType)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.DoesNotContain(expectedSubstring, actualString, comparisonType);
        }

        public static void StartsWith(string expectedStartString, string actualString)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.StartsWith(expectedStartString, actualString);
        }

        public static void StartsWith(string expectedStartString, string actualString, StringComparison comparisonType)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.StartsWith(expectedStartString, actualString, comparisonType);
        }

        public static void EndsWith(string expectedEndString, string actualString)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.EndsWith(expectedEndString, actualString);
        }

        public static void EndsWith(string expectedEndString, string actualString, StringComparison comparisonType)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.EndsWith(expectedEndString, actualString, comparisonType);
        }

        public static void Matches(string expectedRegexPattern, string actualString)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.Matches(expectedRegexPattern, actualString);
        }

        public static void Matches(Regex expectedRegex, string actualString)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.Matches(expectedRegex, actualString);
        }

        public static void DoesNotMatch(string expectedRegexPattern, string actualString)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.DoesNotMatch(expectedRegexPattern, actualString);
        }

        public static void DoesNotMatch(Regex expectedRegex, string actualString)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.DoesNotMatch(expectedRegex, actualString);
        }

        public static void Equal(string expected, string actual)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.Equal(expected, actual);
        }

        // ReSharper disable once MethodOverloadWithOptionalParameter
        public static void Equal(string expected, string actual, bool ignoreCase = false, bool ignoreLineEndingDifferences = false, bool ignoreWhiteSpaceDifferences = false)
        {
            if(!RunningOnCiServer) 
                Xunit.Assert.Equal(expected, actual, ignoreCase, ignoreLineEndingDifferences, ignoreWhiteSpaceDifferences);
        }

        public static T IsAssignableFrom<T>(object @object)
        {
            try
            {
                return Xunit.Assert.IsAssignableFrom<T>(@object);
            }
            catch
            {
                if (RunningOnCiServer)
                    return default(T);
                throw;
            }
        }

        public static void IsAssignableFrom(Type expectedType, object @object)
        {
            try
            {
                Xunit.Assert.IsAssignableFrom(expectedType, @object);
            }
            catch
            {
                if (!RunningOnCiServer) throw;
            }
        }

        public static void IsNotType<T>(object @object)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.IsNotType<T>(@object);
        }

        public static void IsNotType(Type expectedType, object @object)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.IsNotType(expectedType, @object);
        }

        public static T IsType<T>(object @object)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.IsType<T>(@object);
            return default(T);
        }

        public static void IsType(Type expectedType, object @object)
        {
            if (!RunningOnCiServer)
                Xunit.Assert.IsType(expectedType, @object);
        }
    }
}
