using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class PageControlExtensionMethods
    {
        public static IEnumerable<PageControl> GetChildPageControls(this PageControl pageControl, Page page)
        {
            return
                page.Controls.
                Skip(page.Controls.IndexOf(pageControl) + 1).
                TakeWhile(c => c.IndentationLevel > pageControl.IndentationLevel).
                Where(c => c.IndentationLevel == pageControl.IndentationLevel + 1);
        }

        public static ContainerPageControl GetContentAreaControl(this Page page)
        {
            return page.Controls.OfType<ContainerPageControl>().FirstOrDefault(c => c.Properties.ContainerType == ContainerType.ContentArea);
        }

        public static ContainerPageControl GetOrCreateContentAreaControl(this Page page, IEnumerable<int> range, int index )
        {
            var result = GetContentAreaControl(page) ?? page.Controls.Insert(index, new ContainerPageControl(range.GetNextPageControlID(page), 0));
            result.Properties.ContainerType = ContainerType.ContentArea;
            return result;
        }

        public static GroupPageControl GetGeneralGroupControl(this Page page)
        {
            var contentArea = GetContentAreaControl(page);

            if (contentArea == null)
                return null;

            return contentArea.GetChildPageControls(page).OfType<GroupPageControl>().FirstOrDefault(c => c.Properties.CaptionML["ENU"] == "General");
        }

        public static GroupPageControl GetOrCreateGeneralGroupControl(this Page page,IEnumerable<int> range, int index )
        {
            var groupPageControl = GetGeneralGroupControl(page);

            if (groupPageControl == null)
            {
                groupPageControl = page.Controls.Insert(index, new GroupPageControl(range.GetNextPageControlID(page), 1));
                groupPageControl.Properties.CaptionML.Set("ENU", "General");
                GetOrCreateContentAreaControl(page, range, index);
            }

            return groupPageControl;
        }

        public static GroupPageControl GetNumeringGroupControl(this Page page)
        {
            var contentArea = GetContentAreaControl(page);

            if (contentArea == null)
                return null;

            return contentArea.GetChildPageControls(page).OfType<GroupPageControl>().FirstOrDefault(c => c.Properties.CaptionML["ENU"] == "Numbering");
        }

        public static GroupPageControl GetOrCreateNumberingGroupControl(this Page page, IEnumerable<int> range, int index)
        {
            var groupPageControl = GetNumeringGroupControl(page);

            if (groupPageControl == null)
            {
                groupPageControl = page.Controls.Insert(index, new GroupPageControl(range.GetNextPageControlID(page), 1));
                groupPageControl.Properties.CaptionML.Set("ENU", "Numbering");
                GetOrCreateContentAreaControl(page, range, index);
            }

            return groupPageControl;
        }
    }
}
