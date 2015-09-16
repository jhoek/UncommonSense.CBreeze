using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Meta
{
    public class DocumentHistoryEntityTypePattern : EntityTypePattern
    {
        private string headerName;
        private string lineName;

        public DocumentHistoryEntityTypePattern(Application application, IEnumerable<int> range, string name)
            : base(application, range, name)
        {
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
    }
}
