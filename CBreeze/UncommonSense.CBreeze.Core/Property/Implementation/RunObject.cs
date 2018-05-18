using UncommonSense.CBreeze.Core.Property.Type;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class RunObject
    {
        // Made public to allow RunObjectProperty to new up an instance
        public RunObject()
        {
        }

        public RunObjectType? Type
        {
            get;
            set;
        }

        public int? ID
        {
            get;
            set;
        }
    }
}
