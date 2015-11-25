using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class IDManagementExtensionMethods
    {
        #region Objects
        public static int GetNextTableID(this IEnumerable<int> range, Application application)
        {
            return range.Except(application.Tables.Select(t => t.ID)).First();
        }

        public static int GetNextPageID(this IEnumerable<int> range, Application application)
        {
            return range.Except(application.Pages.Select(p => p.ID)).First();
        }

        public static int GetNextReportID(this IEnumerable<int> range, Application application)
        {
            return range.Except(application.Reports.Select(r => r.ID)).First();
        }

        public static int GetNextCodeunitID(this IEnumerable<int> range, Application application)
        {
            return range.Except(application.Codeunits.Select(c => c.ID)).First();
        }

        public static int GetNextQueryID(this IEnumerable<int> range, Application application)
        {
            return range.Except(application.Queries.Select(q => q.ID)).First();
        }

        public static int GetNextXmlPortID(this IEnumerable<int> range, Application application)
        {
            return range.Except(application.XmlPorts.Select(x => x.ID)).First();
        }

        public static int GetNextMenuSuiteID(this IEnumerable<int> range, Application application)
        {
            return range.Except(application.MenuSuites.Select(m => m.ID)).First();
        }
        #endregion

        #region Subobjects
        public static int GetNextTableFieldNo(this IEnumerable<int> range, Table table, int offset = 0)
        {
            // Skip first 10 field IDs for primary key
            const int nonKeyFieldsOffset = 10;

            if (range.Contains(table.ID))
                range = nonKeyFieldsOffset.To(int.MaxValue);

            return range.Skip(offset).Except(table.Fields.Select(f => f.ID)).First();
        }

        public static int GetNextPrimaryKeyFieldNo(this IEnumerable<int> range, Table table)
        {
            return Enumerable.Range(1, 10).Except(table.Fields.Select(f => f.ID)).First();
        }

        public static int GetNextPageControlID(this IEnumerable<int> range, Page page)
        {
            if (range.Contains(page.ID))
                range = 1.To(int.MaxValue);

            var pageControlIDs = page.Controls.Select(c => c.ID);
            var pageActionIDs = page.Properties.ActionList.Select(a => a.ID);

            return range.Except(pageControlIDs).Except(pageActionIDs).First();
        }
        #endregion

        #region Code
        public static int GetNextFunctionID<T>(this IEnumerable<int> range, T hasCode) where T : Object, IHasCode
        {
            if (range.Contains(hasCode.ID))
                range = 1.To(int.MaxValue);

            return range.Except(hasCode.Code.Functions.Select(f => f.ID)).First();
        }

        public static int GetNextVariableID<T>(this IEnumerable<int> range, T hasCode) where T : Object, IHasCode
        {
            // Note: The first 1000 global variable IDs are reserved for C/SIDE
            if (range.Contains(hasCode.ID))
                range = 1000.To(int.MaxValue);

            return range.Except(hasCode.Code.Variables.Select(v => v.ID)).First();
        }

        public static int GetNextVariableID(this IEnumerable<int> range, Trigger trigger)
        {
            // Note: You'd need access to the object ID to know whether to use 
            // existing range, or to start from 1.
            return range.Except(trigger.Variables.Select(v => v.ID)).First();
        }

        public static int GetNextParameterID(this IEnumerable<int> range, Function function)
        {
            if (range.Contains(function.ID))
                range = 1.To(int.MaxValue);

            return range.Except(function.Parameters.Select(p => p.ID)).First();
        }

        public static int GetNextVariableID(this IEnumerable<int> range, Function function)
        {
            if (range.Contains(function.ID))
                range = 1.To(int.MaxValue);

            return range.Except(function.Variables.Select(v => v.ID)).First();
        }
        #endregion

        public static IEnumerable<int> To(this int from, int to)
        {
            return Enumerable.Range(from, to - from + 1);
        }
    }
}