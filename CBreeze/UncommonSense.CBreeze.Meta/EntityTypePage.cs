using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Meta
{
    public class EntityTypePage
    {
        public PageType? PageType { get; set; }
        public bool Editable { get; set; } = true;
        public EntityTypeTable SourceTable { get; set; }
    }
}
