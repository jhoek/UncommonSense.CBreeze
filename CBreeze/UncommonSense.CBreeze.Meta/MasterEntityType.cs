using System.Collections.Generic;

namespace UncommonSense.CBreeze.Meta
{
    public class MasterEntityType : EntityType
    {
        public MasterEntityType(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
        }

        public override IEnumerable<EntityTypeTable> Tables
        {
            get
            {
                yield return new EntityTypeTable(Name) { DrillDownPageID = };
            }
        }


    }
}
