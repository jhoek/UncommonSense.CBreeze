using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
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
