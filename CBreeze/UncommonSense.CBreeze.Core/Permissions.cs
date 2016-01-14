using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class Permissions : IEnumerable<Permission>
    {
        private Dictionary<int,Permission> innerList = new Dictionary<int,Permission>();

        // Ctor made public to allow PermissionProperty to new up an instance
        public Permissions()
        {
        }

        public void Set(int tableID, bool readPermission, bool insertPermission, bool modifyPermission, bool deletePermission)
        {
            Unset(tableID);
            innerList.Add(tableID, new Permission(tableID, readPermission, insertPermission, modifyPermission, deletePermission));
        }

        public void Reset()
        {
            innerList.Clear();
        }

        public bool Unset(int tableID)
        {
            return innerList.Remove(tableID);
        }

        public IEnumerator<Permission> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }
}
