using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Meta
{
    public class DocumentEntityTypePattern : EntityTypePattern
    {
        private string headerName;
        private string lineName;

        public DocumentEntityTypePattern(Application application, IEnumerable<int> range, string name)
            : base(application, range, name)
        {
        }

        public string DocumentTypeOptions
        {
            get;
            set;
        }

        public string HeaderName
        {
            get
            {
                return this.headerName ?? string.Format("{0} Header", Name);
            }
            set
            {
                this.headerName = value;
            }
        }

        public string LineName
        {
            get
            {
                return this.lineName ?? string.Format("{0} Line", Name);
            }
            set
            {
                this.lineName = value;
            }
        }

        public Table SetupTable
        {
            get;
            set;
        }

        public Page SetupPage
        {
            get;
            set;
        }
    }
}
