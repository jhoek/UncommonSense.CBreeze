using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Meta.EntityTypes;

namespace UncommonSense.CBreeze.Meta.PageDefinitions
{
    public class ListPageDefinition : PageDefinition
    {
        public override Page Render(EntityType entityType)
        {
            var page = new Page(Name ?? entityType.PluralName);
            page.

            return page;
        }
    }
}
