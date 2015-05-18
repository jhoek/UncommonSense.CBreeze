using System;
using System.Collections.Generic;

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

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return captionML;
			}
		}
	}
}

