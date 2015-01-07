using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class Page : Object, IEquatable<Page>
	{
		public Page(int id, string name) :
			base(id, name)
		{
		}

		public override ObjectType Type
		{
			get
			{
				return ObjectType.Page;
			}
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return ObjectProperties;
			}
		}

		public bool Equals(Page other)
		{
			if (other == null)
				return false;

			if (other.ID == ID)
				return true;

			if (other.Name == Name)
				return true;

			return false;
		}
	}
}

