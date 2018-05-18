using UncommonSense.CBreeze.Core.Table.Field.Properties;

namespace UncommonSense.CBreeze.Core.Table.Relation
{
    public class TableRelationCondition
    {
        public TableRelationCondition(string fieldName, SimpleTableFilterType type, string value)
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

        public SimpleTableFilterType Type
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
