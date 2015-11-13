using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
#if NAV2015
    [Serializable]
    public class AccessByPermission
    {
        public AccessByPermissionObjectType? ObjectType
        {
            get;
            set;
        }

        public int? ObjectID
        {
            get;
            set;
        }

        public bool Read
        {
            get;
            set;
        }

        public bool Insert
        {
            get;
            set;
        }

        public bool Modify
        {
            get;
            set;
        }

        public bool Delete
        {
            get;
            set;
        }

        public bool Execute
        {
            get;
            set;
        }
    }
#endif
}
