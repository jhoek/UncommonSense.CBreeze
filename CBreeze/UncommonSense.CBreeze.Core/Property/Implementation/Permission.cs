namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class Permission
    {
        public Permission(int tableID, bool readPermission, bool insertPermission, bool modifyPermission, bool deletePermission)
        {
            TableID = tableID;
            ReadPermission = readPermission;
            InsertPermission = insertPermission;
            ModifyPermission = modifyPermission;
            DeletePermission = deletePermission;
        }

        public bool DeletePermission
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

        public bool ReadPermission
        {
            get;
            protected set;
        }

        public int TableID
        {
            get;
            protected set;
        }
    }
}