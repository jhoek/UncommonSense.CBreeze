using System;

namespace CBreeze.NextGen
{
	public class PageProperties : Properties
	{
		private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");

		internal PageProperties(Node parentNode)
			: base(parentNode)
		{
		}

		public override string ToString()
		{
			return "Properties";
		}

		public MultiLanguageValue CaptionML
		{
			get
			{
				return this.captionML.Value;
			}
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

