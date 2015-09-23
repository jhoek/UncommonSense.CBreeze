using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Meta
{
    public partial class JournalEntityTypePattern
    {
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

        public TextTableField BatchTableDescriptionField
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

        public TextTableField LineTableDescriptionField
        {
            get;
            protected set;
        }

        public CodeTableField LineTableSourceCodeField
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

        public Function JournalMgtCodeunitOpenJnlFunction
        {
            get;
            protected set;
        }

        public Function JournalMgtCodeunitTemplateSelectionFunction
        {
            get;
            protected set;
        }

        public Function JournalMgtCodeunitCheckTemplateNameFunction
        {
            get;
            protected set;
        }

        public Function JournalMgtCodeunitLookupNameFunction
        {
            get;
            protected set;
        }

        public Function JournalMgtCodeunitSetNameFunction
        {
            get;
            protected set;
        }

        public Function JournalMgtCodeunitCheckNameFunction
        {
            get;
            protected set;
        }

        public Function JournalMgtCodeunitTemplateSelectionFromBatchFunction
        {
            get;
            protected set;
        }

        public Function JournalMgtCodeunitOpenJnlBatchFunction
        {
            get;
            protected set;
        }

        public BooleanVariable JournalMgtCodeunitOpenFromBatchVariable
        {
            get;
            protected set;
        }
    }
}
