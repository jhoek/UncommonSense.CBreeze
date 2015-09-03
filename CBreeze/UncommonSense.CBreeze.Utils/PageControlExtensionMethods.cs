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
            var controls = parent.Container;

            return controls.
                Skip(parent.Index() + 1).
                TakeWhile(c => c.IndentationLevel > parent.IndentationLevel).
                Where(c => c.IndentationLevel == parent.IndentationLevel + 1);
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
        public static T InsertFirstChildPageControl<T>(this PageControl parent, T child) where T : PageControl
        {
            var controls = parent.Container;
            var parentIndex = controls.IndexOf(parent);
            controls.Insert(parentIndex + 1, child);
            return child;
        }

        /// <summary>
        /// Inserts PageControl <paramref name="child"/> as the last child of PageControl <paramref name="parent"/>.
        /// </summary>
        public static T AppendLastChildPageControl<T>(this PageControl parent, T child) where T : PageControl
        {
            var controls = parent.Container;
            var childControls = parent.GetChildPageControls();
            var lastIndex = childControls.Any() ? childControls.Last().Index() : parent.Index();
            controls.Insert(lastIndex + 1, child);
            return child;
        }

        /// <summary>
        /// Returns the first/only ContentArea container page control.
        /// </summary>
        public static ContainerPageControl GetContentArea(this Page page)
        {
            return page.Controls.OfType<ContainerPageControl>().FirstOrDefault(c => c.Properties.ContainerType == ContainerType.ContentArea);
        }

        public static ContainerPageControl GetContentArea(this Page page, IEnumerable<int> range)
        {
            var result = GetContentArea(page) ?? page.Controls.Insert(0, new ContainerPageControl(range.GetNextPageControlID(page), 0));
            result.Properties.ContainerType = ContainerType.ContentArea;
            return result;
        }

        public static GroupPageControl GetGroup(this ContainerPageControl container, string caption)
        {
            return container.GetChildPageControls().OfType<GroupPageControl>().FirstOrDefault(c => c.Properties.CaptionML["ENU"] == caption);
        }

        public static GroupPageControl GetGroup(this ContainerPageControl container, string caption, IEnumerable<int> range, Position position)
        {
            var groupPageControl = GetGroup(container, caption);

            if (groupPageControl == null)
            {
                groupPageControl = new GroupPageControl(range.GetNextPageControlID(container.Container.Page), 1);
                groupPageControl.Properties.CaptionML.Set("ENU", caption);

                switch (position)
                {
                    case Position.FirstWithinContainer:
                        container.InsertFirstChildPageControl(groupPageControl);
                        break;
                    case Position.LastWithinContainer:
                        container.AppendLastChildPageControl(groupPageControl);
                        break;
                }
            }

            return groupPageControl;
        }
    }
}
