using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
		public class PageActionContainer : PageActionBase
	{
		public PageActionContainer(int id, int? indentationLevel)
			: base(id, indentationLevel)
		{
			Properties = new PageActionContainerProperties();
		}

		public override PageActionBaseType Type
		{
			get
			{
				return PageActionBaseType.ActionContainer;
			}
		}

		public PageActionContainerProperties Properties
		{
			get;
			protected set;
		}

		public override string GetName()
		{
			return Properties.Name;
		}

		public override Properties AllProperties
		{
			get
			{
				return Properties;
			}
		}

		public PageActionGroup GetGroupByCaption(IPage page, string caption, IEnumerable<int> range, Position position)
		{
			var pageActionGroup = ChildPageActions.OfType<PageActionGroup>().FirstOrDefault(a => a.Properties.CaptionML ["ENU"] == caption);

			if (pageActionGroup == null)
			{
				pageActionGroup = new PageActionGroup(range.GetNextPageControlID(page), 1);
				pageActionGroup.Properties.CaptionML.Set("ENU", caption);
				AddChildPageAction(pageActionGroup, position);
			}

			return pageActionGroup;
		}
	}
}
