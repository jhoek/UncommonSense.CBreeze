using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class FindAvailableFieldNoExtensionMethods
    {
        public class IDRange
        {
            public IDRange(int from, int to)
            {
                From = from;
                To = to;
            }

            public int From
            {
                get;
                private set;
            }

            public int To
            {
                get;
                private set;
            }
        }

        public static int FindAvailableID(this Table table, params IDRange[] ranges)
        {


            throw new NotImplementedException();
        }

        public static IEnumerable<int> FindAvailableIDs(this Table table, int noOfFields, int interval = 1, params IDRange[] ranges)
        {
            throw new NotImplementedException();
        }

        public static bool TryFindAvailableFieldNo(this Table table, out int fieldNo, params IDRange[] ranges)
        {
            try
            {
                fieldNo = FindAvailableID(table, ranges);
                return true;
            }
            catch
            {
                fieldNo = 0;
                return false;
            }
        }

        public static bool TryFindAvailableFieldNos(this Table table, out IEnumerable<int> fieldNos, int noOfFields, int interval = 1, params IDRange[] ranges)
        {
            try
            {
                fieldNos = FindAvailableIDs(table, noOfFields, interval, ranges);
                return true;
            }
            catch
            {
                fieldNos = Enumerable.Empty<int>();
                return false;
            }
        }
    }
}
