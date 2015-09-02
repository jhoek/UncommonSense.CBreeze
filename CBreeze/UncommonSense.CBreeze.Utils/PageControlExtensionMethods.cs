using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class PageControlExtensionMethods
    {
        public static IEnumerable<PageControl> ChildPageControls(this PageControl pageControl, Page page)
        {
            return 
                page.Controls.
                Skip(page.Controls.IndexOf(pageControl) + 1).
                TakeWhile(c => c.IndentationLevel > pageControl.IndentationLevel).
                Where(c => c.IndentationLevel == pageControl.IndentationLevel + 1);
        }
    }
}
