using System;

namespace CBreeze.NextGen
{
	public class Trigger : Node
	{
		public Trigger()
		{
			Variables = new Variables(this);
		}

		public Variables Variables
		{
			get;
			internal set;
		}

		public override string ToString()
		{
			return "Trigger";
		}

		public override System.Collections.Generic.IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return Variables;
			}
		}
	}
}

