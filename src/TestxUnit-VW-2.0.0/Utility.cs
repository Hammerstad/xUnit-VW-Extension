namespace TestxUnit_VW
{
    using System.Collections;
    using System.Collections.Generic;

    public partial class AssertTest
    {
        private class MyStringComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                return x.Equals(y);
            }

            public int GetHashCode(string obj)
            {
                return obj.GetHashCode();
            }
        }

        private class MyEnumerableComparer : IEqualityComparer<IEnumerable>
        {
            public bool Equals(IEnumerable x, IEnumerable y)
            {
                return x.Equals(y);
            }

            public int GetHashCode(IEnumerable obj)
            {
                return obj.GetHashCode();
            }
        }

        private class MyIntComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x == y)
                    return 0;
                return (x > y) ? 1 : -1;
            }
        }
    }
}