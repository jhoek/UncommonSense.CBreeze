using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public enum Position
    {
        FirstWithinContainer,
        LastWithinContainer
    }

    public static class PageControlExtensionMethods
    {
        /// <summary>
        /// Returns an IEnumerable of PageControls indented exactly one level relative to <paramref name="parent"/>.
        /// </summary>
        public static IEnumerable<PageControl> GetChildPageControls(this PageControl parent)
        {
            return parent.GetDescendantPageControls().Where(c => c.IndentationLevel == parent.IndentationLevel + 1);                
        }

        public static IEnumerable<PageControl> GetDescendantPageControls(this PageControl parent)
        {
            var controls = parent.Container;

            return controls.
                Skip(parent.Index() + 1).
                TakeWhile(c => c.IndentationLevel > parent.IndentationLevel);                
        }

        /// <summary>
        /// Returns the index of PageControl <paramref name="pageControl"/> within the PageControls collection.
        /// </summary>
        public static int Index(this PageControl pageControl)
        {
            return pageControl.Container.IndexOf(pageControl);
        }

        /// <summary>
        /// Inserts PageControl <paramref name="child"/> directly after PageControl <paramref name="parent"/>.
        /// </summary>
        public static T AddChildPageControl<T>(this PageControl parent, T child, Position position) where T : PageControl
        {
            var controls = parent.Container;

            switch(position)
            {
                case Position.FirstWithinContainer:
                    controls.Insert(parent.Index() + 1, child);
                    break;
                case Position.LastWithinContainer:
                    var childControls = parent.GetDescendantPageControls();
                    var lastIndex = childControls.Any()? childControls.Last().Index() : parent.Index();
                    controls.Insert(lastIndex+ 1, child);
                    break;
            }

            return child;
        }

        public static GroupPageControl GetGroupByCaption(this ContainerPageControl container, string caption)
        {
            return container.GetChildPageControls().OfType<GroupPageControl>().FirstOrDefault(c => c.Properties.CaptionML["ENU"] == caption);
        }

        public static GroupPageControl GetGroupByCaption(this ContainerPageControl container, string caption, IEnumerable<int> range, Position position)
        {
            var groupPageControl = container.GetGroupByCaption(caption);

            if (groupPageControl == null)
            {
                groupPageControl = new GroupPageControl(range.GetNextPageControlID(container.Container.Page), 1);
                groupPageControl.Properties.CaptionML.Set("ENU", caption);
                container.AddChildPageControl(groupPageControl, position);
            }

            return groupPageControl;
        }

        public static GroupPageControl GetGroupByType(this ContainerPageControl container, GroupType type)
        {
            return container.GetChildPageControls().OfType<GroupPageControl>().FirstOrDefault(g => g.Properties.GroupType == type);
        }

        public static GroupPageControl GetGroupByType(this ContainerPageControl container, GroupType type, IEnumerable<int> range, Position position)
        {
            var groupPageControl = container.GetGroupByType(type);

            if (groupPageControl == null)
            {
                groupPageControl = new GroupPageControl(range.GetNextPageControlID(container.Container.Page), 1);
                groupPageControl.Properties.GroupType = type;
                container.AddChildPageControl(groupPageControl, position);
            }
            
            return groupPageControl;
        }
    }
}
