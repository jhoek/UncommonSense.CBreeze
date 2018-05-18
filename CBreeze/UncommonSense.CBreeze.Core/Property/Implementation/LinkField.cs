namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class LinkField
    {
        public LinkField(int field, int referenceField)
        {
            Field = field;
            ReferenceField = referenceField;
        }

        public int Field
        {
            get;
            protected set;
        }

        public int ReferenceField
        {
            get;
            protected set;
        }
    }
}
