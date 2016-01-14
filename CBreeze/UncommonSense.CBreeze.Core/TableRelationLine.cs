using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class TableRelationLine
    {
        public TableRelationLine(string tableName)
        {
            TableName = tableName;
            Conditions = new TableRelationConditions();
            TableFilter = new TableRelationTableFilter();
        }

        public string TableName
        {
            get;
            protected set;
        }

        public string FieldName
        {
            get;
            set;
        }

        public TableRelationConditions Conditions
        {
            get;
            protected set;
        }

        public TableRelationTableFilter TableFilter
        {
            get;
            protected set;
        }
    }
}
