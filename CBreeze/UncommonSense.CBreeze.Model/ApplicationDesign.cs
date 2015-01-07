using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
    public class ApplicationDesign : IEnumerable<EntityType>
    {
        private List<EntityType> innerList = new List<EntityType>();

        public SetupEntityType AddSetupEntityType(string name)
        {
            var setupEntityType = new SetupEntityType(this, name);
            innerList.Add(setupEntityType);
            return setupEntityType;
        }

        public MasterEntityType AddMasterEntityType(string name, SetupEntityType setupEntityType)
        {
            var masterEntityType = new MasterEntityType(this, name, setupEntityType);
            innerList.Add(masterEntityType);
            return masterEntityType;
        }

        public SupplementalEntityType AddSupplementalEntityType(string name, string pluralName)
        {
            var supplementalEntityType = new SupplementalEntityType(this, name, pluralName);
            innerList.Add(supplementalEntityType);
            return supplementalEntityType;
        }

        public SubsidiaryEntityType AddSubsidiaryEntityType(string name, string pluralName, params ISubsidiaryTo[] subsidiaryTo)
        {
            var subsidiaryEntityType = new SubsidiaryEntityType(this, name, pluralName, subsidiaryTo);
            innerList.Add(subsidiaryEntityType);
            return subsidiaryEntityType;
        }

        public DocumentEntityType AddDocumentEntityType(string baseName, SetupEntityType setupEntityType)
        {
            var documentEntityType = new DocumentEntityType(this, baseName, setupEntityType);
            innerList.Add(documentEntityType);
            return documentEntityType;
        }

        public LedgerEntityType AddLedgerEntityType(string name, string pluralName)
        {
            var ledgerEntityType = new LedgerEntityType(this, name, pluralName);
            innerList.Add(ledgerEntityType);
            return ledgerEntityType;
        }

        public RegisterEntityType AddRegisterEntityType(string name, params LedgerEntityType[] ledgerEntityTypes)
        {
            var registerEntityType = new RegisterEntityType(this, name, ledgerEntityTypes);
            innerList.Add(registerEntityType);
            return registerEntityType;
        }

        public JournalEntityType AddJournalEntityType(string baseName)
        {
            var journalEntityType = new JournalEntityType(this, baseName);
            innerList.Add(journalEntityType);
            return journalEntityType;
        }

        #region IEnumerable implementation

        public IEnumerator<EntityType> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        #endregion

    }
}
