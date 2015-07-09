using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
    public class RegisterEntityType : EntityType
    {
        private List<LedgerEntityType> ledgerEntityTypes = new List<LedgerEntityType>();

        public RegisterEntityType(string name, params LedgerEntityType[] ledgerEntityTypes)
        {
            Name = name;
            HasCreationDateField = true;
            HasSourceCodeField = true;
            HasUserIDField = true;
            HasJournalBatchNameField = true;
            this.ledgerEntityTypes.AddRange(ledgerEntityTypes);
        }

        public string Name
        {
            get;
            internal set;
        }

        public bool HasCreationDateField
        {
            get;
            set;
        }

        public bool HasSourceCodeField
        {
            get;
            set;
        }

        public bool HasUserIDField
        {
            get;
            set;
        }

        public bool HasJournalBatchNameField
        {
            get;
            set;
        }

        public IEnumerable<LedgerEntityType> LedgerEntityTypes
        {
            get
            {
                foreach (var ledgerEntityType in ledgerEntityTypes)
                {
                    yield return ledgerEntityType;
                }
            }
        }
    }
}
