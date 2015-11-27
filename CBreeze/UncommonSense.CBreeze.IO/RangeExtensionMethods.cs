using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.IO
{
    public static class RangeExtensionMethods
    {
        public static string Summarize(this IEnumerable<int> ids)
        {
            var groups = ids.Select((n, i) => new
            {
                ID = n,
                Group = n - i
            }).GroupBy(n => n.Group);

            var ranges = groups.Select(g => g.Count() >= 3 ? string.Format("{0}..{1}", g.First().ID, g.Last().ID) : string.Join("|", g.Select(x => x.ID)));

            return string.Join("|", ranges);
        }
    }
}
