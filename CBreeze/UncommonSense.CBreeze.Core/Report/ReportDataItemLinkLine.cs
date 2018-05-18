namespace UncommonSense.CBreeze.Core.Report
{
        public class ReportDataItemLinkLine
    {
        public ReportDataItemLinkLine(string fieldName, string referenceFieldName)
        {
            FieldName = fieldName;
            ReferenceFieldName = referenceFieldName;
        }

        public string FieldName
        {
            get;
            protected set;
        }

        public string ReferenceFieldName
        {
            get;
            protected set;
        }
    }
}
