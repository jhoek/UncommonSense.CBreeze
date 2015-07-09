using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
    public class LedgerEntityType : EntityType
    {
        public LedgerEntityType(string name, string pluralName)
        {
            Name = name;
            PluralName = pluralName;
            HasPostingDateField = true;
        }

        public string Name
        {
            get;
            internal set;
        }

        public string PluralName
        {
            get;
            internal set;
        }

        public bool HasPostingDateField
        {
            get;set;
        }

        public MasterEntityType MasterEntityType
        {
            get;set;
        }
    }
}
