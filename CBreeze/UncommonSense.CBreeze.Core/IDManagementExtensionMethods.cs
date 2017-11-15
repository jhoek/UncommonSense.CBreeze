using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Core
{
    public static class IDManagementExtensionMethods
    {
        public static IEnumerable<int> GetPageUIDsInUse(this IPage page)
        {
            var pageControlIDs = page.Controls.Select(c => c.ID);
            var pageActionIDs = page.Actions.Select(a => a.ID);
            var controlActionIDs = page.Controls.OfType<PageControlGroup>().SelectMany(g => g.Properties.ActionList).Select(c => c.ID);

            return pageControlIDs.Union(pageActionIDs).Union(controlActionIDs);
        }

        public static int GetNextPageControlOrActionID(this IEnumerable<int> range, IPage page)
        {
            if (range.Contains(page.ObjectID))
                range = 1.To(int.MaxValue);

            return range.Except(GetPageUIDsInUse(page)).First();
        }

        public static IEnumerable<int> To(this int from, int to)
        {
            return Enumerable.Range(from, to - from + 1);
        }
    }
}