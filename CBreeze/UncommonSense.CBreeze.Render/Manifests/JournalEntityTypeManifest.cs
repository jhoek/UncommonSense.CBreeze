using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Render
{
    public class JournalEntityTypeManifest : RenderingManifest
    {
        internal JournalEntityTypeManifest()
        {
        }

        public Table TemplateTable
        {
            get;
            internal set;
        }

        public Table BatchTable
        {
            get;
            internal set;
        }

        public Table LineTable
        {
            get;
            internal set;
        }

        public TableKey TemplateTablePrimaryKey
        {
            get;
            internal set;
        }

        public TableKey BatchTablePrimaryKey
        {
            get;
            internal set;
        }

        public TableKey LineTablePrimaryKey
        {
            get;
            internal set;
        }

        public CodeTableField TemplateTableNameField
        {
            get;
            internal set;
        }

        public TextTableField TemplateTableDescriptionField
        {
            get;
            internal set;
        }

        public IntegerTableField TemplateTableTestReportIDField
        {
            get;
            internal set;
        }

        public TextTableField TemplateTableTestReportCaptionField
        {
            get;
            internal set;
        }

        public IntegerTableField TemplateTablePageIDField
        {
            get;
            internal set;
        }

        public TextTableField TemplateTablePageCaptionField
        {
            get;
            internal set;
        }

        public IntegerTableField TemplateTablePostingReportIDField
        {
            get;
            internal set;
        }

        public TextTableField TemplateTablePostingReportCaptionField
        {
            get;
            internal set;
        }

        public BooleanTableField TemplateTableForcePostingReportField
        {
            get;
            internal set;
        }

        public CodeTableField TemplateTableSourceCodeField
        {
            get;
            internal set;
        }

        public CodeTableField TemplateTableReasonCodeField
        {
            get;
            internal set;
        }

        public BooleanTableField TemplateTableRecurringField
        {
            get;
            internal set;
        }

        public CodeTableField TemplateTableNoSeriesField
        {
            get;
            internal set;
        }

        public CodeTableField TemplateTablePostingNoSeriesField
        {
            get;
            internal set;
        }

        public TextConstant TemplateTableText000
        {
            get;
            internal set;
        }

        public TextConstant TemplateTableText001
        {
            get;
            internal set;
        }

        public CodeTableField BatchTableJournalTemplateNameField
        {
            get;
            internal set;
        }

        public CodeTableField BatchTableNameField
        {
            get;
            internal set;
        }

        public TextTableField BatchTableDescriptionField
        {
            get;
            internal set;
        }

        public CodeTableField BatchTableReasonCodeField
        {
            get;
            internal set;
        }

        public CodeTableField BatchTableNoSeriesField
        {
            get;
            internal set;
        }

        public CodeTableField BatchTablePostingNoSeriesField
        {
            get;
            internal set;
        }

        public BooleanTableField BatchTableRecurringField
        {
            get;
            internal set;
        }

        public Function BatchTableSetupNewBatchFunction
        {
            get;
            internal set;
        }

        public TextConstant BatchTableText000
        {
            get;
            internal set;
        }

        public CodeTableField LineTableJournalTemplateNameField
        {
            get;
            internal set;
        }

        public CodeTableField LineTableJournalBatchNameField
        {
            get;
            internal set;
        }

        public IntegerTableField LineTableLineNoField
        {
            get;
            internal set;
        }

        public DateTableField LineTablePostingDateField
        {
            get;
            internal set;
        }

        public CodeTableField LineTableMasterEntityTypeField
        {
            get;
            internal set;
        }

        public TextTableField LineTableDescriptionField
        {
            get;
            internal set;
        }

        public CodeTableField LineTableSourceCodeField
        {
            get;
            internal set;
        }

        public CodeTableField LineTableReasonCodeField
        {
            get;
            internal set;
        }

        public DateTableField LineTableDocumentDateField
        {
            get;
            internal set;
        }

        public Page TemplatesPage
        {
            get;
            internal set;
        }

        public Page TemplateListPage
        {
            get;
            internal set;
        }

        public Page BatchesPage
        {
            get;
            internal set;
        }

        public Page JournalPage
        {
            get;
            internal set;
        }

        public Page RecurringJournalPage
        {
            get;
            internal set;
        }

        public Codeunit JournalMgtCodeunit
        {
            get;
            internal set;
        }

        public Function OpenJnlFunction
        {
            get;
            internal set;
        }

        public Function TemplateSelectionFunction
        {
            get;
            internal set;
        }

        public Function CheckTemplateNameFunction
        {
            get;
            internal set;
        }

        public Function LookupNameFunction
        {
            get;
            internal set;
        }

        public Function SetNameFunction
        {
            get;
            internal set;
        }

        public Function CheckNameFunction
        {
            get;
            internal set;
        }

        public Function TemplateSelectionFromBatchFunction
        {
            get;
            internal set;
        }

        public Function OpenJnlBatchFunction
        {
            get;
            internal set;
        }

        public BooleanVariable OpenFromBatchVariable
        {
            get;
            internal set;
        }

        public TextConstant JournalMgtCodeunitText000
        {
            get;
            internal set;
        }

        public TextConstant JournalMgtCodeunitText001
        {
            get;
            internal set;
        }

        public TextConstant JournalMgtCodeunitText002
        {
            get;
            internal set;
        }

        public TextConstant JournalMgtCodeunitText003
        {
            get;
            internal set;
        }

        public TextConstant JournalMgtCodeunitText004
        {
            get;
            internal set;
        }

        public TextConstant JournalMgtCodeunitText005
        {
            get;
            internal set;
        }
    }
}
