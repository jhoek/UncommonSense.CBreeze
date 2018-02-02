using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Meta.EntityTypes;

namespace UncommonSense.CBreeze.Meta.PageDefinitions
{
    public abstract class PageDefinition
    {
        public string Name { get; set; }
        public Hashtable CaptionML { get; set; }
        public abstract Page Render(EntityType entityType);
    }
}
