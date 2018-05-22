using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class Permissions : IEnumerable<Permission>
    {
        private Dictionary<int, Permission> innerList = new Dictionary<int, Permission>();

        // Ctor made public to allow PermissionProperty to new up an instance
        public Permissions()
        {
        }

        public IEnumerator<Permission> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        public void Reset()
        {
            innerList.Clear();
        }

        public void Set(int tableID, bool readPermission, bool insertPermission, bool modifyPermission, bool deletePermission)
        {
            Unset(tableID);
            innerList.Add(tableID, new Permission(tableID, readPermission, insertPermission, modifyPermission, deletePermission));
        }

        public void Set(Permission[] permissions)
        {
            if (permissions == null)
                return;

            innerList.Clear();

            foreach (var permission in permissions)
            {
                innerList.Add(permission.TableID, permission);
            }
        }

        public bool Unset(int tableID)
        {
            return innerList.Remove(tableID);
        }
    }
}