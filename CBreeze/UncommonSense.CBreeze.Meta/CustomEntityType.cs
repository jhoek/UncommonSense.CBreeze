using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace UncommonSense.CBreeze.Meta
{
    public class CustomEntityType : EntityType
    {
        public CustomEntityType(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override IEnumerable<EntityTypeTable> Tables
        {
            get
            {
                yield return new EntityTypeTable(Name);
            }
        }

        public PrimaryKeyType PrimaryKeyType { get; set; } = PrimaryKeyType.Code;
        public Collection<CustomEntityTypeAttribute> CustomPrimaryKeyAttributes { get; } = new Collection<CustomEntityTypeAttribute>();
        public IEnumerable<CustomEntityTypeAttribute> PrimaryKeyAttributes => CustomPrimaryKeyAttributes.Any() ? CustomPrimaryKeyAttributes : DefaultPrimaryKeyAttributes;

        public IEnumerable<CustomEntityTypeAttribute> DefaultPrimaryKeyAttributes
        {
            get
            {
                switch (PrimaryKeyType)
                {
                    case PrimaryKeyType.Code:
                        yield return new CustomEntityTypeAttribute("Code");
                        break;
                }
            }
        }
    }
}
