using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class Permission
    {
        private Int32 tableID;
        private Boolean readPermission;
        private Boolean insertPermission;
        private Boolean modifyPermission;
        private Boolean deletePermission;

        internal Permission(Int32 tableID, Boolean readPermission, Boolean insertPermission, Boolean modifyPermission, Boolean deletePermission)
        {
            this.deletePermission = deletePermission;
            this.insertPermission = insertPermission;
            this.modifyPermission = modifyPermission;
            this.readPermission = readPermission;
            this.tableID = tableID;
        }

        public Int32 TableID
        {
            get
            {
                return this.tableID;
            }
        }

        public Boolean ReadPermission
        {
            get
            {
                return this.readPermission;
            }
        }

        public Boolean InsertPermission
        {
            get
            {
                return this.insertPermission;
            }
        }

        public Boolean ModifyPermission
        {
            get
            {
                return this.modifyPermission;
            }
        }

        public Boolean DeletePermission
        {
            get
            {
                return this.deletePermission;
            }
        }

    }
}
