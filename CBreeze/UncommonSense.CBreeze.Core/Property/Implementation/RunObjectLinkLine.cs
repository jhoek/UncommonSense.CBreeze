using UncommonSense.CBreeze.Core.Table.Field;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class RunObjectLinkLine
    {
        public RunObjectLinkLine(string fieldName, TableFilterType type, string value)
        {
            FieldName = fieldName;
            Type = type;
            Value = value;
        }

        public string FieldName
        {
            get;
            protected set;
        }

        public bool OnlyMaxLimit
        {
            get;
            set;
        }

        public TableFilterType? Type
        {
            get;
            protected set;
        }

        public string Value
        {
            get;
            protected set;
        }

        public bool ValueIsFilter
        {
            get;
            set;
        }
    }
}
