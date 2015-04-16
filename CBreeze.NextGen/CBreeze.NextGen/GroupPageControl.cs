using System;

namespace CBreeze.NextGen
{
	public class GroupPageControl : PageControl
	{
		public GroupPageControl(int id)
			: base(id)
		{
			Properties = new GroupPageControlProperties(this);
		}

		public GroupPageControlProperties Properties
		{
			get;
			internal set;
		}

		public override PageControlType Type
		{
			get
			{
				return PageControlType.Group;
			}
		}

		public override System.Collections.Generic.IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return Properties;
			}
		}
	}
}

