using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class TableRelationLine
    {
        private TableRelationConditions conditions = new TableRelationConditions();
        private String fieldName;
        private TableRelationTableFilter tableFilter = new TableRelationTableFilter();
        private String tableName;

        internal TableRelationLine(String tableName)
        {
            this.tableName = tableName;
        }

        public TableRelationConditions Conditions
        {
            get
            {
                return this.conditions;
            }
        }

        public String FieldName
        {
            get
            {
                return this.fieldName;
            }
            set
            {
                this.fieldName = value;
            }
        }

        public TableRelationTableFilter TableFilter
        {
            get
            {
                return this.tableFilter;
            }
        }

        public String TableName
        {
            get
            {
                return this.tableName;
            }
        }

    }
}
