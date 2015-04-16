using System;

namespace CBreeze.NextGen
{
	public class ContainerPageControl : PageControl
	{
		public ContainerPageControl(int id)
			: base(id)
		{
			Properties = new ContainerPageControlProperties(this);
		}

		public override PageControlType Type
		{
			get
			{
				return PageControlType.Container;
			}
		}

		public ContainerPageControlProperties Properties
		{
			get;
			internal set;
		}
	}
}

