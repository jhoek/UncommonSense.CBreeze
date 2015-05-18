using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class GroupPageControlProperties : Properties
	{
		private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");

		internal GroupPageControlProperties(Node parentNode)
			: base(parentNode)
		{
		}

		public MultiLanguageValue CaptionML
		{
			get
			{
				return this.captionML.Value;
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

