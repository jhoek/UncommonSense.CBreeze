using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class IDManagementExtensionMethods
    {
        public static int GetNextPageControlID(this IEnumerable<int> range, IPage page)
        {
            if (range.Contains(page.ObjectID))
                range = 1.To(int.MaxValue);

            var pageControlIDs = page.Controls.Select(c => c.ID);
            var pageActionIDs = page.Actions.Select(a => a.ID);

            return range.Except(pageControlIDs).Except(pageActionIDs).First();
        }

        public static IEnumerable<int> To(this int from, int to)
        {
            return Enumerable.Range(from, to - from + 1);
        }
    }
}