using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class Code : Node
	{
		internal Code(Node parentNode)
			: base(parentNode)
		{
			Documentation = new Documentation(this);
			Events = new Events(this);
			Variables = new Variables(this);
			Functions = new Functions(this);
		}

		public override string ToString()
		{
			return "Code";
		}

		public override NodeType Type
		{
			get
			{
				return NodeType.Code;
			}
		}

		public Documentation Documentation
		{
			get;
			internal set;
		}

		public Events Events
		{
			get;
			internal set;
		}

		public Variables Variables
		{
			get;
			internal set;
		}

		public Functions Functions
		{
			get;
			internal set;
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				foreach(var childNode in base.ChildNodes)
				{
					yield return childNode;
				}
                
				yield return Documentation;
				yield return Events;
				yield return Variables;
				yield return Functions;
			}
		}
	}
}
