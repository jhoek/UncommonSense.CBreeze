using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public abstract class PageControl : Node, IKeyedValue<int>, IEquatable<PageControl>
	{
		public PageControl(int id)
		{
			ID = id;
		}

		public abstract PageControlType Type
		{
			get;
		}

		public int ID
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

		public override string ToString()
		{
			return string.Format("Control {0} of type {1}", ID, Type);
		}

		public int GetKey()
		{
			return ID;
		}

		public bool Equals(PageControl other)
		{
			if (other == null)
				return false;

			if (other.ID == ID)
				return true;

			return false;
		}
	}
}

