using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public abstract class ValueProperty<T> : Property
	{
		private Func<T, bool> hasValue;

		internal ValueProperty(string name, Func<T, bool> hasValue)
			: base(name)
		{
			this.hasValue = hasValue;
		}

		public override string ToString()
		{
			return string.Format("{0}={1}", Name, Value);
		}

		public override bool HasValue
		{
			get
			{
				return this.hasValue(Value);
			}
		}

		public T Value
		{
			get;
			set;
		}
	}
}

