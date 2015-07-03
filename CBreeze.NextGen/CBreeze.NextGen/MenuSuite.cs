using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
	public class MenuSuite : Object, IEquatable<MenuSuite>
	{
		public MenuSuite(int id, string name)
			: base(id, name)
		{

		}

		public override ObjectType Type
		{
			get
			{
				return ObjectType.MenuSuite;
			}
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				foreach (var childNode in base.ChildNodes)
				{
					yield return childNode;
				}
			}
		}

		public bool Equals(MenuSuite other)
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
