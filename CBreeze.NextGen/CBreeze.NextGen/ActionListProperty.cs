using System;
using System.Linq;

namespace CBreeze.NextGen
{
	public class ActionListProperty : ReferenceProperty<ActionList>
	{
		public ActionListProperty(string name)
			: base(name)
		{
		}

		public Node ParentNode
		{
			get
			{
				return Value.ParentNode;
			}
			set
			{
				Value.ParentNode = value;
			}
		}

		public override bool HasValue
		{
			get
			{
				return Value.Any();
			}
		}
	}
}

