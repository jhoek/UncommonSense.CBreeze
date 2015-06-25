using System;

namespace CBreeze.NextGen
{
	public class PageProperties : Properties
	{
		private ActionListProperty actionList = new ActionListProperty("ActionList");
		private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");

		internal PageProperties(Node parentNode)
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

		public ActionList ActionList
		{
			get
			{
				return this.actionList.Value;
			}
		}

		public override System.Collections.Generic.IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return captionML;
				yield return actionList;
			}
		}
	}
}

