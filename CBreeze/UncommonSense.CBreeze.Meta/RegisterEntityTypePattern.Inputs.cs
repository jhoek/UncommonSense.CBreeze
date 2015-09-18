using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Meta
{
    public partial class RegisterEntityTypePattern
    {
        public IEnumerable<Table> LedgerEntryTables
        {
            get
            {
                return this.ledgerEntryTables.AsEnumerable();
            }
        }

        public bool HasCreationDate
        {
            get;
            set;
        }

        public bool HasSourceCode
        {
            get;
            set;
        }

        public bool HasUserID
        {
            get;
            set;
        }

        public bool HasJournalBatchName
        {
            get;
            set;
        }
    }
}
