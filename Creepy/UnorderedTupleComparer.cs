using System;
using System.Collections.Generic;

namespace Creepy
{
	class UnorderedTupleComparer<T> : IEqualityComparer<Tuple<T,T>>
	{
		public readonly IEqualityComparer<T> EntryComparer;

		bool fullCompare (T left, T right)
		{
			return EntryComparer.GetHashCode (left) == EntryComparer.GetHashCode (right) &&
			EntryComparer.Equals (left, right);
		}

		public bool Equals (Tuple<T, T> x, Tuple<T, T> y)
		{
			return (fullCompare (x.Item1, y.Item1) && fullCompare (x.Item2, y.Item2)) ||
			(fullCompare (x.Item1, y.Item2) && fullCompare (x.Item2, y.Item1));
		}

		public int GetHashCode (Tuple<T, T> obj)
		{
			return EntryComparer.GetHashCode (obj.Item1) ^ EntryComparer.GetHashCode (obj.Item2);
		}

		public UnorderedTupleComparer (IEqualityComparer<T> comparer = null)
		{
			EntryComparer = comparer ?? EqualityComparer<T>.Default;
		}
	}
	
}