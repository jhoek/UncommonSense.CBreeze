using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Meta
{
    public abstract class EntityType
    {
        public abstract IEnumerable<EntityTypeTable> Tables { get; }
        public abstract IEnumerable<EntityTypePage> Pages { get; }
    }
}
