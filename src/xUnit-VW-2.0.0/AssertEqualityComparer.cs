namespace Xunit.VW
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal class AssertEqualityComparer<T> : IEqualityComparer<T>
  {
        // ReSharper disable once StaticFieldInGenericType
    private static readonly IEqualityComparer DefaultInnerComparer = new AssertEqualityComparerAdapter<object>(new AssertEqualityComparer<object>());
        // ReSharper disable once StaticFieldInGenericType
    private static readonly TypeInfo NullableTypeInfo = typeof (Nullable<>).GetTypeInfo();
    private readonly Func<IEqualityComparer> innerComparerFactory;
    private readonly bool skipTypeCheck;

    static AssertEqualityComparer()
    {
    }

    public AssertEqualityComparer(bool skipTypeCheck = false, IEqualityComparer innerComparer = null)
    {
      this.skipTypeCheck = skipTypeCheck;
      innerComparerFactory = () => innerComparer ?? DefaultInnerComparer;
    }

    public bool Equals(T x, T y)
    {
      TypeInfo typeInfo = typeof (T).GetTypeInfo();
      if (!typeInfo.IsValueType || typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition().GetTypeInfo().IsAssignableFrom(NullableTypeInfo))
      {
        if (Equals(x, (object) default (T)))
          return Equals(y, (object) default (T));
        if (object.Equals(y, default (T)))
          return false;
      }
      if (!skipTypeCheck && x.GetType() != y.GetType())
        return false;
      var equatable = (object) x as IEquatable<T>;
      if (equatable != null)
        return equatable.Equals(y);
      var comparable1 = (object) x as IComparable<T>;
      if (comparable1 != null)
        return comparable1.CompareTo(y) == 0;
      var comparable2 = (object) x as IComparable;
      if (comparable2 != null)
        return comparable2.CompareTo(y) == 0;
    return CheckIfDictionariesAreEqual(x, y) ?? CheckIfEnumerablesAreEqual(x, y) ?? Equals(x, (object) y);
    }

    private bool? CheckIfEnumerablesAreEqual(T x, T y)
    {
      IEnumerable enumerable1 = (object) x as IEnumerable;
      IEnumerable enumerable2 = (object) y as IEnumerable;
      if (enumerable1 == null || enumerable2 == null)
        return new bool?();
      IEnumerator enumerator1 = enumerable1.GetEnumerator();
      IEnumerator enumerator2 = enumerable2.GetEnumerator();
      IEqualityComparer equalityComparer = innerComparerFactory();
      do
      {
        bool flag1 = enumerator1.MoveNext();
        bool flag2 = enumerator2.MoveNext();
        if (!flag1 || !flag2)
          return flag1 == flag2;
      }
      while (equalityComparer.Equals(enumerator1.Current, enumerator2.Current));
      return false;
    }

    private bool? CheckIfDictionariesAreEqual(T x, T y)
    {
      IDictionary dictionary1 = (object) x as IDictionary;
      IDictionary dictionary2 = (object) y as IDictionary;
      if (dictionary1 == null || dictionary2 == null)
        return new bool?();
      if (dictionary1.Count != dictionary2.Count)
        return false;
      IEqualityComparer equalityComparer = innerComparerFactory();
      HashSet<object> hashSet = new HashSet<object>(dictionary2.Keys.Cast<object>());
      foreach (object index in dictionary1.Keys)
      {
        if (!hashSet.Contains(index))
          return false;
        object x1 = dictionary1[index];
        object y1 = dictionary2[index];
        if (!equalityComparer.Equals(x1, y1))
          return false;
        hashSet.Remove(index);
      }
      return hashSet.Count == 0;
    }

    public int GetHashCode(T obj)
    {
      throw new NotImplementedException();
    }
  }
}