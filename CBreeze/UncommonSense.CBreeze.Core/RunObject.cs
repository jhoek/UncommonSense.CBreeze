using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class RunObject
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
