using System;
using System.Collections.Generic;

namespace Creepy
{
	public class PairDictionary <TKey, TValue>
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
					default(TValue);
			}
			set
			{
				intDict [new Tuple<TKey, TKey> (item0, item1)] = value;
			}
		}

		public PairDictionary (IEqualityComparer<TKey> keyComparer = null)
		{
			KeyComparer = keyComparer ?? EqualityComparer<TKey>.Default;
			intDict = new Dictionary<Tuple<TKey, TKey>, TValue> (new UnorderedTupleComparer<TKey> (KeyComparer));
		}
	}
}