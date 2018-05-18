using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Table.Field.Properties;

namespace UncommonSense.CBreeze.Core.Table.Field
{
#if NAV2017

    public class MediaSetTableField : TableField
    {
        public MediaSetTableField(int id, string name)
            : base(id, name)
        {
            Properties = new MediaSetTableFieldProperties(this);
        }

        public override TableFieldType Type => TableFieldType.MediaSet;

        public override Property.Properties AllProperties => Properties;

        public override IEnumerable<INode> ChildNodes => new[] { Properties };

        public MediaSetTableFieldProperties Properties { get; }
    }

#endif
}