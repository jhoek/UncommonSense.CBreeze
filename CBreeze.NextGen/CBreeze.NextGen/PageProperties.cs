using System;

namespace CBreeze.NextGen
{
	public class PageProperties : Properties
	{
		private ActionListProperty actionList = new ActionListProperty("ActionList");
		private NullableValueProperty<bool> autoSplitKey = new NullableValueProperty<bool>("AutoSplitKey");
		private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
		private StringProperty cardPageID = new StringProperty("CardPageID");

		internal PageProperties(Node parentNode)
			: base(parentNode)
		{
			actionList.ParentNode = ParentNode;
		}

		public ActionList ActionList
		{
			get
			{
				return this.actionList.Value;
			}
		}

		public bool? AutoSplitKey
		{
			get
			{
				return this.autoSplitKey.Value;
			}
			set
			{
				this.autoSplitKey.Value = value;
			}
		}

		public MultiLanguageValue CaptionML
		{
			get
			{
				return this.captionML.Value;
			}
		}

		public string CardPageID
		{
			get
			{
				return this.cardPageID.Value;
			}
			set
			{
				this.cardPageID.Value = value;
			}
		}

		public override System.Collections.Generic.IEnumerable<INode> ChildNodes
		{
			get
			{
				// FIXME: Verify order
				yield return captionML;
				yield return autoSplitKey;
				yield return actionList;
			}
		}
	}
}

