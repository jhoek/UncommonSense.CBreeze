using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public abstract class Container<TKey, TValue> : INode, IEnumerable<TValue> where TValue : Node, IKeyedValue<TKey>, IEquatable<TValue>
	{
		private Dictionary<TKey, TValue> innerDictionary = new Dictionary<TKey, TValue>();

		internal Container(Node parentNode)
		{
			ParentNode = parentNode;
		}

		public override string ToString()
		{
			return "Container";
		}

		public TItem Add<TItem>(TItem item) where TItem : TValue
		{
			if (innerDictionary.ContainsValue(item))
				throw new ArgumentException("Item already exists.");

			item.ParentNode = ParentNode;
			innerDictionary.Add(item.GetKey(), item);

			return item;
		}

		public bool Remove(TKey key)
		{
			return innerDictionary.Remove(key);
		}

		public void Clear()
		{
			innerDictionary.Clear();
		}

		public bool ContainsKey(TKey key)
		{
			return innerDictionary.ContainsKey(key);
		}

		public bool ContainsValue(TValue value)
		{
			return innerDictionary.ContainsValue(value);
		}

		public TValue this[TKey key]
		{
			get
			{
				return innerDictionary[key];
			}
		}

		public Node ParentNode
		{
			get;
			internal set;
		}

		public IEnumerable<INode> ChildNodes
		{
			get
			{
				foreach (var keyValuePair in innerDictionary)
				{
					yield return keyValuePair.Value;
				}
			}
		}

		public IEnumerator<TValue> GetEnumerator()
		{
			return innerDictionary.Values.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return innerDictionary.Values.GetEnumerator();
		}
	}
}

