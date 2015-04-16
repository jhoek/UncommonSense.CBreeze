using System;

namespace CBreeze.NextGen
{
	public class ContainerPageControlProperties : Properties
	{
		private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");

		internal ContainerPageControlProperties(Node parentNode)
			: base(parentNode)
		{
		}

		public MultiLanguageValue CaptionML
		{
			get
			{
				return captionML.Value;
			}
		}

		public override string ToString()
		{
			return "Properties";
		}

		public override System.Collections.Generic.IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return captionML;
			}
		}
	}
}

