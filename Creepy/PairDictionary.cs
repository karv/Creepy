using System;
using System.Collections.Generic;
using System.Linq;

namespace Creepy
{
	public class PairDictionary <TKey, TValue> : IEnumerable<TValue>
		where TValue : class
	{
		public IEqualityComparer<TKey> KeyComparer;

		readonly Dictionary<Tuple<TKey, TKey>,TValue> intDict;

		public TValue this [TKey item0, TKey item1]
		{
			get
			{
				TValue ret;
				return intDict.TryGetValue (new Tuple<TKey, TKey> (item0, item1), out ret) ? 
					ret : 
					null;
			}
			set
			{
				var tuple = new Tuple<TKey, TKey> (item0, item1);
				if (value == null)
					intDict.Remove (tuple);
				else
					intDict [tuple] = value;
			}
		}

		public bool Remove (TKey item0, TKey item1)
		{
			var tuple = new Tuple<TKey, TKey> (item0, item1);
			return intDict.Remove (tuple);
		}

		public IEnumerator<TValue> GetEnumerator ()
		{
			return intDict.Values.Where (z => !ReferenceEquals (z, null)).GetEnumerator ();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return GetEnumerator ();
		}

		public PairDictionary (IEqualityComparer<TKey> keyComparer = null)
		{
			KeyComparer = keyComparer ?? EqualityComparer<TKey>.Default;
			intDict = new Dictionary<Tuple<TKey, TKey>, TValue> (new UnorderedTupleComparer<TKey> (KeyComparer));
		}
	}
}