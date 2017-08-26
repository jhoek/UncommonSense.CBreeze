using System.Text;

#if NAV2015

namespace UncommonSense.CBreeze.Core
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
    }
}

#endif