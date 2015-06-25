using System;

namespace CBreeze.NextGen
{
	public class PageProperties : Properties
	{
		private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
		private ActionListProperty actionList = new ActionListProperty("ActionList");

		internal PageProperties(Node parentNode)
			: base(parentNode)
		{
			actionList.ParentNode = ParentNode;
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

