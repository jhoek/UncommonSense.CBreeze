namespace UncommonSense.CBreeze.Core.Table.Key
{
        public class SIFTLevelComponent
    {
        public SIFTLevelComponent(string fieldName, string aspect)
        {
            Aspect = aspect;
            FieldName = fieldName;
        }

        public string FieldName
        {
            get;
            protected set;
        }

        public string Aspect
        {
            get;
            protected set;
        }
    }
}
