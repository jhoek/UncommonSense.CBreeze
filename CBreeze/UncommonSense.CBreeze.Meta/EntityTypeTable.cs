using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Meta
{
    public class EntityTypeTable
    {
        public EntityTypeTable(string name)
        {
            Name = name;
        }

        public string Name { get;  }
        public EntityTypePage LookupPageID { get; set; }
        public EntityTypePage DrillDownPageID { get; set; }
        public Collection<EntityTypeTableField> Fields { get; } = new Collection<EntityTypeTableField>();
    }
}
