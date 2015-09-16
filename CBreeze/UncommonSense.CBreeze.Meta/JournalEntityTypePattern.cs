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
    }
}
