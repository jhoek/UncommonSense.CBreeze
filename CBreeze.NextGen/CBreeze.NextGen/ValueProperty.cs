using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public abstract class ValueProperty<T> : Property
	{
		internal ValueProperty(string name)
			: base(name)
		{
		}

		public override string ToString()
		{
			return string.Format("{0}={1}", Name, Value);
		}

		public T Value
		{
			get;
			set;
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

