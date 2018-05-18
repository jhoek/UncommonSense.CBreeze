using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
#if NAV2016
    public class ObjectReference 
    {
        public ObjectType? Type
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
#endif
}
