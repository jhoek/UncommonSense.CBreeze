namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class FieldList : Generic.Collection<string>
    {
        // Made ctor public so that FieldListProperty can new up an instance
        public FieldList() { }
        public FieldList(params string[] fieldNames) { AddRange(fieldNames); }

        protected override void InsertItem(int index, string item)
        {
            base.InsertItem(index, item);
        }
    }
}