using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
    public class JournalEntityType : EntityType
    {
        private string baseName;
        private string basePluralName;
        private bool hasTestReportIDField = true;
        private bool hasPostingReportIDField = true;
        private bool hasSourceCodeField = true;
        private bool hasReasonCodeField = true;
        private bool hasPostingDateField = true;
        private MasterEntityType masterEntityType;

        public JournalEntityType(string baseName)
        {
            this.baseName = baseName;
        }

        public string BaseName
        {
            get
            {
                return this.baseName;
            }
        }

        public string BasePluralName
        {
            get
            {
                return this.basePluralName ?? string.Format("{0}s", BaseName);
            }
            set
            {
                this.basePluralName = value;
            }
        }

        public string TemplateName
        {
            get
            {
                return string.Format("{0} Template", BaseName);
            }
        }

        public string TemplatePluralName
        {
            get
            {
                return string.Format("{0} Templates", BaseName);
            }
        }

        public string BatchName
        {
            get
            {
                return string.Format("{0} Batch", BaseName);
            }
        }

        public string BatchPluralName
        {
            get
            {
                return string.Format("{0} Batches", BaseName);
            }
        }

        public string LineName
        {
            get
            {
                return string.Format("{0} Line", BaseName);
            }
        }

        public bool HasTestReportIDField
        {
            get
            {
                return hasTestReportIDField;
            }
            set
            {
                hasTestReportIDField = value;
            }
        }

        public bool HasPostingReportIDField
        {
            get
            {
                return hasPostingReportIDField;
            }
            set
            {
                hasPostingReportIDField = value;
            }
        }

        public bool HasSourceCodeField
        {
            get
            {
                return hasSourceCodeField;
            }
            set
            {
                hasSourceCodeField = value;
            }
        }

        public bool HasReasonCodeField
        {
            get
            {
                return hasReasonCodeField;
            }
            set
            {
                hasReasonCodeField = value;
            }
        }

        public bool HasPostingDateField
        {
            get
            {
                return this.hasPostingDateField;
            }
            set
            {
                this.hasPostingDateField = value;
            }
        }

        public MasterEntityType MasterEntityType
        {
            get
            {
                return this.masterEntityType;
            }
            set
            {
                this.masterEntityType = value;
            }
        }
    }
}
