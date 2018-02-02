using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Meta.PageDefinitions;

namespace UncommonSense.CBreeze.Meta.EntityTypes
{
    public class MasterEntityType : EntityType
    {
        public MasterEntityType(string name) : base(name)
        {
        }

        public override IEnumerable<PageDefinition> DefaultPages
        {
            get
            {
                yield return new CardPageDefinition();
                yield return new ListPageDefinition();
            }
        }

        public override IEnumerable<Core.Object> Render()
        {
            yield return new Table(Name);

            foreach (var pageDefinition in Pages)
            {
                yield return pageDefinition.Render(this);
            }
        }
    }
}
