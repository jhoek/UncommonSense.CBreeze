﻿using System;
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

            public IEnumerable<int> IDs
            {
                get
                {
                    return Enumerable.Range(From, To - From + 1);
                }
            }
        }

        public static int NextFieldNo(this Table table)
        {
            return NextFieldNo(table, 1);
        }

        public static int NextFieldNo(this Table table, int from)
        {
            return NextFieldNo(table, from, int.MaxValue);
        }

        public static int NextFieldNo(this Table table, int from, int to)
        {
            return NextFieldNo(table, new IDRange(from, to));
        }

        public static int NextFieldNo(this Table table, params IDRange[] ranges)
        {
            foreach (var range in ranges)
            {
                foreach (var id in range.IDs)
                {
                    if (!table.Fields.Any(f=>f.ID == id))
                        return id;
                }
            }

            throw new ApplicationException(string.Format("Could not find an available field no. in table {0}.", table.Name));
        }

        /*
        public static IEnumerable<int> FindAvailableFieldNos(this Table table, int noOfFields, int interval = 1, params IDRange[] ranges)
        {
            throw new NotImplementedException();
        }

        public static bool TryFindAvailableFieldNo(this Table table, out int fieldNo, params IDRange[] ranges)
        {
            try
            {
                fieldNo = FindAvailableFieldNo(table, ranges);
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
                fieldNos = FindAvailableFieldNos(table, noOfFields, interval, ranges);
                return true;
            }
            catch
            {
                fieldNos = Enumerable.Empty<int>();
                return false;
            }
        }
         */
    }
}
