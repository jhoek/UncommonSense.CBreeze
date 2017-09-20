using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
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

        public override Properties AllProperties => Properties;

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public MediaTableFieldProperties Properties { get; }
    }
#endif
}
