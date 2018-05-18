using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Table.Field.Properties;

namespace UncommonSense.CBreeze.Core.Table.Field
{
#if NAV2017
    public class MediaTableField : TableField
    {
        public MediaTableField(int id, string name)
            : base(id, name)
        {
            Properties = new MediaTableFieldProperties(this);
        }

        public override TableFieldType Type => TableFieldType.Media;

        public override Property.Properties AllProperties => Properties;

        public override IEnumerable<INode> ChildNodes => new[] { Properties };

        public MediaTableFieldProperties Properties { get; }
    }
#endif
}
