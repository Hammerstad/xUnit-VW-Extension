namespace Xunit.VW
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    internal class AssertComparer<T> : IComparer<T> where T : IComparable
    {
        // ReSharper disable once StaticFieldInGenericType
        private static readonly TypeInfo NullableTypeInfo = typeof(Nullable<>).GetTypeInfo();

        static AssertComparer()
        {
        }

        public int Compare(T x, T y)
        {
            TypeInfo typeInfo = typeof(T).GetTypeInfo();
            if (!typeInfo.IsValueType || typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition().GetTypeInfo().IsAssignableFrom(NullableTypeInfo))
            {
                if (Equals(x, default(T)))
                    return Equals(y, default(T)) ? 0 : -1;
                if (Equals(y, default(T)))
                    return -1;
            }
            if (x.GetType() != y.GetType())
                return -1;
            var comparable = (object)x as IComparable<T>;
            return comparable != null ? comparable.CompareTo(y) : x.CompareTo(y);
        }
    }
}