namespace UncommonSense.CBreeze.Core.Query
{
        public class QueryDataItemLinkLine
    {
        public QueryDataItemLinkLine(string field, string referenceTable, string referenceField)
        {
            Field = field;
            ReferenceTable = referenceTable;
            ReferenceField = referenceField;
        }

        public string Field
        {
            get;
            protected set;
        }

        public string ReferenceTable
        {
            get;
            protected set;
        }

        public string ReferenceField
        {
            get;
            protected set;
        }
    }
}
