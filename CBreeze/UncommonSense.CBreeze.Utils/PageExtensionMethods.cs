using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class PageExtensionMethods
    {
        private static ContainerPageControl GetContentArea(this Page page)
        {
            return page.Controls.OfType<ContainerPageControl>().FirstOrDefault(c => c.Properties.ContainerType == ContainerType.ContentArea);
        }

        public static ContainerPageControl GetContentArea(this Page page, IEnumerable<int> range)
        {
            var result = GetContentArea(page) ?? page.Controls.Insert(0, new ContainerPageControl(range.GetNextPageControlID(page), 0));
            result.Properties.ContainerType = ContainerType.ContentArea;
            return result;
        }

        private static ContainerPageControl GetFactBoxArea(this Page page)
        {
            return page.Controls.OfType<ContainerPageControl>().FirstOrDefault(c => c.Properties.ContainerType == ContainerType.FactBoxArea);
        }

        public static ContainerPageControl GetFactboxArea(this Page page, IEnumerable<int> range)
        {
            var result = GetFactBoxArea(page) ?? page.Controls.Add(new ContainerPageControl(range.GetNextPageControlID(page), 0));
            result.Properties.ContainerType = ContainerType.FactBoxArea;
            return result;
        }
    }
}
