using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
		public class PageActionContainer : PageActionBase
	{
		public PageActionContainer(int id, int? indentationLevel)
			: base(id, indentationLevel)
		{
			Properties = new PageActionContainerProperties(this);
		}

		public override PageActionBaseType Type
		{
			get
			{
				return PageActionBaseType.ActionContainer;
			}
		}

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
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
				pageActionGroup = new PageActionGroup(range.GetNextPageControlOrActionID(page), 1);
				pageActionGroup.Properties.CaptionML.Set("ENU", caption);
				AddChildPageAction(pageActionGroup, position);
			}

			return pageActionGroup;
		}
	}
}
