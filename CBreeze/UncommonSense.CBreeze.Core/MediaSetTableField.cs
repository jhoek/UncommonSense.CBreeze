using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
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

        public override Properties AllProperties => Properties;

        public override IEnumerable<INode> ChildNodes => new[] { Properties };

        public MediaSetTableFieldProperties Properties { get; }
    }

#endif
}