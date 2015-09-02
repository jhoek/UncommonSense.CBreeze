using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class PageControlExtensionMethods
    {
        /// <summary>
        /// Returns an IEnumerable of PageControls indented exactly one level relative to <paramref name="parent"/>.
        /// </summary>
        public static IEnumerable<PageControl> GetChildPageControls(this PageControl parent)
        {
            var controls = parent.Parent;

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
            return pageControl.Parent.IndexOf(pageControl);
        }

        /// <summary>
        /// Inserts PageControl <paramref name="child"/> directly after PageControl <paramref name="parent"/>.
        /// </summary>
        public static T InsertFirstChildPageControl<T>(this PageControl parent, T child) where T : PageControl
        {
            var controls = parent.Parent;
            var parentIndex = controls.IndexOf(parent);
            controls.Insert(parentIndex + 1, child);
            return child;
        }

        /// <summary>
        /// Inserts PageControl <paramref name="child"/> as the last child of PageControl <paramref name="parent"/>.
        /// </summary>
        public static T AppendLastChildPageControl<T>(this PageControl parent, T child) where T : PageControl
        {
            var controls = parent.Parent;
            var childControls = parent.GetChildPageControls();
            var lastIndex = childControls.Any() ? childControls.Last().Index() : parent.Index();
            controls.Insert(lastIndex + 1, child);
            return child;
        }

        /// <summary>
        /// Returns the first/only ContentArea container page control.
        /// </summary>
        public static ContainerPageControl GetContentAreaControl(this Page page)
        {
            return page.Controls.OfType<ContainerPageControl>().FirstOrDefault(c => c.Properties.ContainerType == ContainerType.ContentArea);
        }

        public static ContainerPageControl GetOrCreateContentAreaControl(this Page page, IEnumerable<int> range)
        {
            var result = GetContentAreaControl(page) ?? page.Controls.Insert(0, new ContainerPageControl(range.GetNextPageControlID(page), 0));
            result.Properties.ContainerType = ContainerType.ContentArea;
            return result;
        }

        public static GroupPageControl GetGroupControlByCaption(this Page page, string caption)
        {
            var contentArea = GetContentAreaControl(page);

            if (contentArea == null)
                return null;

            return contentArea.GetChildPageControls().OfType<GroupPageControl>().FirstOrDefault(c => c.Properties.CaptionML["ENU"] == caption);
        }

        public static GroupPageControl GetOrCreateGroupControlByCaption(this Page page, string caption, IEnumerable<int> range, int index )
        {
            var groupPageControl = GetGroupControlByCaption(page, caption);

            if (groupPageControl == null)
            {
                groupPageControl = page.Controls.Insert(index, new GroupPageControl(range.GetNextPageControlID(page), 1));
                groupPageControl.Properties.CaptionML.Set("ENU", caption);
                GetOrCreateContentAreaControl(page, range, index);
            }

            return groupPageControl;
        }
    }
}
