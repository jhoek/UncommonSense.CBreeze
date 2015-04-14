using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class ValueProperty<T> : Property
	{
		private T value;

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
			get
			{
				return this.value;
			}
			set
			{
				this.value = value;
			}
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

