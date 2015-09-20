using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Meta
{
    public class JournalEntityTypePattern : EntityTypePattern
    {
        private string templateName;
        private string templatePluralName;
        private string batchName;
        private string batchPluralName;
        private string lineName;

        public JournalEntityTypePattern(Application application, IEnumerable<int> range, string name)
            : base(application, range, name)
        {
        }

        public Table MasterEntityTypeTable
        {
            get;
            set;
        }

        public string TemplateName
        {
            get
            {
                return templateName ?? string.Format("{0} Template", Name);
            }
            set
            {
                templateName = value;
            }
        }

        public string TemplatePluralName
        {
            get
            {
                return templatePluralName ?? string.Format("{0}s", TemplateName);
            }
            set
            {
                templatePluralName = value;
            }
        }

        public string BatchName
        {
            get
            {
                return batchName ?? string.Format("{0} Batch", Name);
            }
            set
            {
                batchName = value;
            }
        }

        public string BatchPluralName
        {
            get
            {
                return batchPluralName ?? string.Format("{0}es", BatchName);
            }
            set
            {
                batchPluralName = value;
            }
        }

        public string LineName
        {
            get
            {
                return lineName ?? string.Format("{0} Line", Name);
            }
            set
            {
                lineName = value;
            }
        }

        public bool HasTestReportID
        {
            get;
            set;
        }

        public bool HasPostingReportID
        {
            get;
            set;
        }

        public bool HasSourceCode
        {
            get;
            set;
        }

        public bool HasReasonCode
        {
            get;
            set;
        }

        public bool HasPostingDate
        {
            get;
            set;
        }

        public Table TemplateTable
        {
            get;
            protected set;
        }

        public CodeTableField TemplateTableNameField
        {
            get;
            protected set;
        }

        public TextTableField TemplateTableDescriptionField
        {
            get;
            protected set;
        }

        public IntegerTableField TemplateTableTestReportIDField
        {
            get;
            protected set;
        }

        public TextTableField TemplateTableTestReportCaptionField
        {
            get;
            protected set;
        }

        public IntegerTableField TemplateTablePageIDField
        {
            get;
            protected set;
        }

        public TextTableField TemplateTablePageCaptionField
        {
            get;
            protected set;
        }

        public IntegerTableField TemplateTablePostingReportIDField
        {
            get;
            protected set;
        }

        public TextTableField TemplateTablePostingReportCaptionField
        {
            get;
            protected set;
        }

        public BooleanTableField TemplateTableForcePostingReportField
        {
            get;
            protected set;
        }

        public CodeTableField TemplateTableSourceCodeField
        {
            get;
            protected set;
        }

        public CodeTableField TemplateTableReasonCodeField
        {
            get;
            protected set;
        }

        public BooleanTableField TemplateTableRecurringField
        {
            get;
            protected set;
        }

        public CodeTableField TemplateTableNoSeriesField
        {
            get;
            protected set;
        }

        public CodeTableField TemplateTablePostingNoSeriesField
        {
            get;
            protected set;
        }

        public Page TemplatesPage
        {
            get;
            protected set;
        }

        public Page TemplateListPage
        {
            get;
            protected set;
        }

        public Table BatchTable
        {
            get;
            protected set;
        }
            
        public CodeTableField BatchTableJournalTemplateNameField
        {
            get;
            protected set;
        }

        public CodeTableField BatchTableNameField
        {
            get;
            protected set;
        }

        public TextTableField  BatchTableDescriptionField
        {
            get;
            protected set;
        }

        public CodeTableField BatchTableReasonCodeField
        {
            get;
            protected set;
        }

        public CodeTableField BatchTableNoSeriesField
        {
            get;
            protected set;
        }

        public CodeTableField BatchTablePostingNoSeriesField
        {
            get;
            protected set;
        }

        public BooleanTableField BatchTableRecurringField
        {
            get;
            protected set;
        }

        public Function BatchTableSetupNewBatchFunction
        {
            get;
            protected set;
        }

        public Page BatchesPage
        {
            get;
            protected set;
        }

        public Table LineTable
        {
            get;
            protected set;
        }

        public CodeTableField LineTableJournalTemplateNameField
        {
            get;
            protected set;
        }

        public CodeTableField LineTableJournalBatchNameField
        {
            get;
            protected set;
        }

        public IntegerTableField LineTableLineNoField
        {
            get;
            protected set;
        }

        public DateTableField LineTablePostingDateField
        {
            get;
            protected set;
        }

        public CodeTableField LineTableMasterEntityTypeField
        {
            get;
            protected set;
        }

        public TextTableField  LineTableDescriptionField
        {
            get;
            protected set;
        }

        public CodeTableField  LineTableSourceCodeField
        {
            get;
            protected set;
        }

        public CodeTableField LineTableReasonCodeField
        {
            get;
            protected set;
        }

        public DateTableField LineTableDocumentDateField
        {
            get;
            protected set;
        }

        public Page JournalPage
        {
            get;
            protected set;
        }

        public Page RecurringJournalPage 
        {
            get;
            protected set;
        }

        public Codeunit JournalMgtCodeunit
        {
            get;
            protected set;
        }

        public Function OpenJnlFunction
        {
            get;
            protected set;
        }

        public Function TemplateSelectionFunction
        {
            get;
            protected set;
        }

        public Function CheckTemplateNameFunction
        {
            get;
            protected set;
        }

        public Function LookupNameFunction
        {
            get;
            protected set;
        }

        public Function SetNameFunction
        {
            get;
            protected set;
        }

        public Function ChechNameFunction
        {
            get;
            protected set;
        }

        public Function TemplateSelectionFromBatchFunction
        {
            get;
            protected set;
        }

        public Function OpenJnlBatchFunction
        {
            get;
            protected set;
        }

        public BooleanVariable OpenFromBatchVariable
        {
            get;
            protected set;
        }
    }
}
