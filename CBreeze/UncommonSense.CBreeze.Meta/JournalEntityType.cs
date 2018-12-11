using System.Collections.Generic;

namespace UncommonSense.CBreeze.Meta
{
    public class JournalEntityType : EntityType
    {
        public JournalEntityType(string name)
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
                yield return new EntityTypeTable($"{Name} Journal Template") 
                {
                    PrimaryKeyType = PrimaryKeyType.Code
                };

                yield return new EntityTypeTable($"{Name} Journal Batch");
                yield return new EntityTypeTable($"{Name} Journal Line");
            }
        }

        public override IEnumerable<EntityTypePage> Pages
        {
            get
            {
                yield break;
            }
        }
    }
}
