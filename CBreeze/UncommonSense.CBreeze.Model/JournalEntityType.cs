using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
    public class JournalEntityType : EntityType
    {
        public JournalEntityType(string baseName)
        {
            BaseName = baseName;
            BasePluralName = string.Format("{0}s", BaseName);
            TemplateName = string.Format("{0} Template", BaseName);
            TemplatePluralName = string.Format("{0} Templates", BaseName);
            BatchName = string.Format("{0} Batch", BaseName);
            BatchPluralName = string.Format("{0} Batches", BaseName);
            LineName = string.Format("{0} Line", BaseName);
            HasTestReportIDField = true;
            HasPostingReportIDField = true;
            HasSourceCodeField = true;
            HasReasonCodeField = true;
            HasPostingDateField = true;
        }

        public string BaseName
        {
            get;
            internal set;
        }

        public string BasePluralName
        {
            get;
            set;
        }

        public string TemplateName
        {
            get;
            set;
        }

        public string TemplatePluralName
        {
            get;
            set;
        }

        public string BatchName
        {
            get;
            set;
        }

        public string BatchPluralName
        {
            get;
            set;
        }

        public string LineName
        {
            get;
            set;
        }

        public bool HasTestReportIDField
        {
            get;
            set;
        }

        public bool HasPostingReportIDField
        {
            get;set;
        }

        public bool HasSourceCodeField
        {
            get;
            set;
        }

        public bool HasReasonCodeField
        {
            get;set;
        }

        public bool HasPostingDateField
        {
            get;set;
        }

        public MasterEntityType MasterEntityType
        {
            get;
            set;
        }
    }
}
