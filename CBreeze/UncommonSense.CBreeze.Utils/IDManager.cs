using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class IDManager
    {
        private class IDRange
        {
            private IDRange(int from, int to)
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

            public bool Contains(int ID)
            {
                return IDs.Contains(ID);
            }

            public IEnumerable<int> IDs
            {
                get
                {
                    return Enumerable.Range(From, To - From + 1);
                }
            }
        }

        static IDManager()
        {
            ObjectIDRanges = new List<IDRange>();
            FieldNoRanges = new List<IDRange>();
        }

        public static int NextTableID(this Application application)
        {
            return NextID(ObjectIDRanges, application.Tables.Select(t => t.ID));
        }

        public static int NextFieldNo(this Table table)
        {
            if (IsBaseAppObjectID(table.ID))
                return NextID(FieldNoRanges, table.Fields.Select(f => f.ID));

            return NextID(AllIDs, table.Fields.Select(f => f.ID));
        }

        private static int NextID(IEnumerable<IDRange> idRanges, IEnumerable<int> inUse)
        {
            foreach (var idRange in idRanges)
            {
                foreach (var id in idRange.IDs.Except(inUse))
                {
                    return id;
                }
            }

            throw new ApplicationException("Could not find available ID.");
        }

        private static bool IsBaseAppObjectID(int id)
        {
            foreach (var idRange in ObjectIDRanges)
            {
                if (idRange.Contains(id))
                    return false;
            }

            return true;
        }

        public static List<IDRange> ObjectIDRanges
        {
            get;
            private set;
        }

        public static List<IDRange> FieldNoRanges
        {
            get;
            private set;
        }

        public static IEnumerable<IDRange> AllIDs
        {
            get
            {
                yield return new IDRange(1, int.MaxValue);
            }
        }
    }
}
