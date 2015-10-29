namespace Xunit.VW
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    internal class AssertEqualityComparerAdapter<T> : IEqualityComparer
    {
        private readonly IEqualityComparer<T> innerComparer;

        public AssertEqualityComparerAdapter(IEqualityComparer<T> innerComparer)
        {
            this.innerComparer = innerComparer;
        }

        public new bool Equals(object x, object y)
        {
            return innerComparer.Equals((T)x, (T)y);
        }

        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }
    }
}