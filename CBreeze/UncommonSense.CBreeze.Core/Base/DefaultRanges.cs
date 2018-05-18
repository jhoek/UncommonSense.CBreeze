using System.Collections.Generic;
using System.Linq;

namespace UncommonSense.CBreeze.Core.Base
{
    public static class DefaultRanges
    {
        static DefaultRanges()
        {
            ID = Enumerable.Range(50000, 1000);
            UID = Enumerable.Range(1000000000, 1000);
        }

        public static IEnumerable<int> ID { get; set; }
        public static IEnumerable<int> UID { get; set; }
    }
}