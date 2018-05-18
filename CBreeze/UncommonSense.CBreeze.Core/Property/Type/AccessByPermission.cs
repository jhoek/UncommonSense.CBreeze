using System.Text;
using UncommonSense.CBreeze.Core.Property.Enumeration;

#if NAV2015

namespace UncommonSense.CBreeze.Core.Property.Type
{
    public class AccessByPermission
    {
        public bool Delete { get; set; }
        public bool Execute { get; set; }
        public bool Insert { get; set; }
        public bool Modify { get; set; }
        public int? ObjectID { get; set; }
        public AccessByPermissionObjectType? ObjectType { get; set; }
        public bool Read { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder(5);

            if (Read) stringBuilder.Append('R');
            if (Insert) stringBuilder.Append('I');
            if (Modify) stringBuilder.Append('M');
            if (Delete) stringBuilder.Append('D');
            if (Execute) stringBuilder.Append('X');

            return stringBuilder.ToString();
        }

        public void Set(AccessByPermission accessByPermission)
        {
            if (accessByPermission != null)
            {
                ObjectType = accessByPermission.ObjectType;
                ObjectID = accessByPermission.ObjectID;
                Read = accessByPermission.Read;
                Insert = accessByPermission.Insert;
                Modify = accessByPermission.Modify;
                Delete = accessByPermission.Delete;
                Execute = accessByPermission.Execute;
            }
        }
    }
}

#endif