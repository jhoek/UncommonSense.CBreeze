using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class Code : Node
	{
		internal Code(Node parentNode)
		{
			ParentNode = parentNode;
			Variables = new Variables(this);
			Functions = new Functions(this);
		}

		public override string ToString()
		{
			return "Code";
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
				yield return Variables;
				yield return Functions;
			}
		}
	}
}

