using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class ReferenceProperty<T> : Property where T : new()
	{
		internal ReferenceProperty(string name) : base(name)
		{
			Value = new T();
		}

		public override string ToString()
		{
			return string.Format("{0}={1}", Name, Value);
		}

		public T Value
		{
			get;
			internal set;
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				yield break;
			}
		}
	}
}

