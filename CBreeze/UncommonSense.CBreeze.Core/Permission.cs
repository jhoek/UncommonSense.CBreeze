using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class Permission
    {
        internal Permission(int tableID, bool readPermission, bool insertPermission, bool modifyPermission, bool deletePermission)
        {
            TableID = tableID;
            ReadPermission = readPermission;
            InsertPermission = insertPermission;
            ModifyPermission = modifyPermission;
            DeletePermission = deletePermission;
        }

        public int TableID
        {
            get;
            protected set;
        }

        public bool ReadPermission
        {
            get;
            protected set;
        }

        public bool InsertPermission
        {
            get;
            protected set;
        }

        public bool ModifyPermission
        {
            get;
            protected set;
        }

        public bool DeletePermission
        {
            get;
            protected set;
        }
    }
}
