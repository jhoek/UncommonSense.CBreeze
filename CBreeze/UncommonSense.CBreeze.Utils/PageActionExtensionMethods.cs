using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class PageActionExtensionMethods
    {
        public static PageActionContainer GetPageActionContainer(this Page page, IEnumerable<int> range, ActionContainerType type)
        {
            var result = page.Properties.ActionList.OfType<PageActionContainer>().FirstOrDefault(c => c.Properties.ActionContainerType == type) ?? page.Properties.ActionList.Insert(0, new PageActionContainer(range.GetNextPageControlID(page), 0));
            result.Properties.ActionContainerType = type;
            return result;
        }

        public static PageActionGroup GetGroupByCaption(this PageActionContainer container, Page page, string caption, IEnumerable<int> range, Position position)
        {
            var pageActionGroup = container.ChildPageActions.OfType<PageActionGroup>().FirstOrDefault(a => a.Properties.CaptionML["ENU"] == caption);

            if (pageActionGroup == null)
            {
                pageActionGroup = new PageActionGroup(range.GetNextPageControlID(page), 1);
                pageActionGroup.Properties.CaptionML.Set("ENU", caption);
                container.AddChildPageAction(pageActionGroup, position);
            }

            return pageActionGroup;
        }

    }
}
