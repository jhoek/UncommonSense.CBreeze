using UncommonSense.CBreeze.Core.Table.Field;

namespace UncommonSense.CBreeze.Core.Table.Relation
{
    public class TableRelationTableFilterLine
    {
        public TableRelationTableFilterLine(string fieldName, TableFilterType type, string value)
        {
            FieldName = fieldName;
            Type = type;
            Value = value;
        }

        public override string ToString() => $"{FieldName}={Type}({Value})";

        public string FieldName
        {
            get;
            protected set;
        }

        public TableFilterType Type
        {
            get;
            protected set;
        }

        public string Value
        {
            get;
            protected set;
        }
    }
}
