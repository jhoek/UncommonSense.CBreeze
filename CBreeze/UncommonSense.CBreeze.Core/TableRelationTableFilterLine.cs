// --------------------------------------------------------------------------------
// <auto-generated>
//      This code was generated by a tool.
//
//      Changes to this file may cause incorrect behaviour and will be lost if
//      the code is regenerated.
// </auto-generated>
// --------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class TableRelationTableFilterLine
    {
        private string fieldName;
        private TableFilterType? type;
        private string value;

        public TableRelationTableFilterLine(string fieldName, TableFilterType type, string value)
        {
            this.fieldName = fieldName;
            this.type = type;
            this.value = value;
        }

        public string FieldName
        {
            get
            {
                return this.fieldName;
            }
        }

        public TableFilterType? Type
        {
            get
            {
                return this.type;
            }
        }

        public string Value
        {
            get
            {
                return this.value;
            }
        }

    }
}
