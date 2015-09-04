using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class PageExtensionMethods
    {
        /// <summary>
        /// Returns the (first/only) ContentArea container page control.
        /// </summary>
        public static ContainerPageControl GetContentArea(this Page page)
        {
            return page.Controls.OfType<ContainerPageControl>().FirstOrDefault(c => c.Properties.ContainerType == ContainerType.ContentArea);
        }

        /// <summary>
        /// Returns the (first/only) ContentArea container page control. If it didn't exist before,
        /// it will be created with an ID from <paramref name="range"/>, and inserted as the first 
        /// control.
        /// </summary>
        public static ContainerPageControl GetContentArea(this Page page, IEnumerable<int> range)
        {
            var result = GetContentArea(page) ?? page.Controls.Insert(0, new ContainerPageControl(range.GetNextPageControlID(page), 0));
            result.Properties.ContainerType = ContainerType.ContentArea;
            return result;
        }
    }
}
