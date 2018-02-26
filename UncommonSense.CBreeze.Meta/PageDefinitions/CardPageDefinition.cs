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
    public class CardPageDefinition : PageDefinition
    {
        public override Page Render(EntityType entityType)
        {
            var page = new Page(Name ?? entityType.Name);
            page.Properties.PageType = PageType.Card;
            // FIXME: page.Properties.CaptionML.Set()

                return page;
        }
    }
}
