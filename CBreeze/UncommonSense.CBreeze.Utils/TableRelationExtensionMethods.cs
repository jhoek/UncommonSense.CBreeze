using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class TableRelationExtensionMethods
    {
        public static TableRelationLine Set(this TableRelationLines tableRelation, string tableName , string fieldName = null)
        {
            var tableRelationLine = tableRelation.Add(tableName);
            tableRelationLine.FieldName = fieldName;

            return tableRelationLine;
        }
    }
}
