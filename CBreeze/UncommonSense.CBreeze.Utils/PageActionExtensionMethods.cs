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

        public static IEnumerable<PageActionBase> GetDescendantPageActions(this PageActionBase parent)
        {
            var actions = parent.Container;

            return actions.
                Skip(parent.Index() + 1).
                TakeWhile(a => a.IndentationLevel > parent.IndentationLevel);
        }

        public static IEnumerable<PageActionBase> GetChildPageActions(this PageActionBase parent)
        {
            return parent.GetDescendantPageActions().Where(a => a.IndentationLevel == parent.IndentationLevel + 1);
        }

        public static int Index(this PageActionBase pageAction)
        {
            return pageAction.Container.IndexOf(pageAction);
        }

        private static PageActionGroup GetGroupByCaption(this PageActionContainer container, string caption)
        {
            return container.GetChildPageActions().OfType<PageActionGroup>().FirstOrDefault(a => a.Properties.CaptionML["ENU"] == caption);
        }

        public static PageActionGroup GetGroupByCaption(this PageActionContainer container, Page page, string caption, IEnumerable<int> range, Position position)
        {
            var pageActionGroup = container.GetGroupByCaption(caption);

            if (pageActionGroup == null)
            {
                pageActionGroup = new PageActionGroup(range.GetNextPageControlID(page), 1);
                pageActionGroup.Properties.CaptionML.Set("ENU", caption);
                container.AddChildPageAction(pageActionGroup, position);
            }

            return pageActionGroup;
        }

        public static T AddChildPageAction<T>(this PageActionBase parent, T child, Position position) where T : PageActionBase
        {
            var controls = parent.Container;

            switch (position)
            {
                case Position.FirstWithinContainer:
                    controls.Insert(parent.Index() + 1, child);
                    break;
                case Position.LastWithinContainer:
                    var childControls = parent.GetDescendantPageActions();
                    var lastIndex = childControls.Any() ? childControls.Last().Index() : parent.Index();
                    controls.Insert(lastIndex + 1, child);
                    break;
            }

            return child;
        }

        public static PageAction AddPageAction(this PageActionBase parent, int id, Position position, string captionML, string image)
        {
            var childPageAction = AddChildPageAction(parent, new PageAction(id, parent.IndentationLevel + 1), position);
            childPageAction.Properties.CaptionML.Set("ENU", captionML);
            childPageAction.Properties.Image = image;
            return childPageAction;
        }

        public static PageAction Promote(this PageAction action, bool promotedIsBig, PromotedCategory promotedCategory)
        {
            action.Properties.Promoted = true;
            action.Properties.PromotedIsBig = promotedIsBig;
            action.Properties.PromotedCategory = promotedCategory;

            return action;
        }
    }
}
