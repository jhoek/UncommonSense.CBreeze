using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
    public class DocumentHistoryEntityType : EntityType
    {
        public DocumentHistoryEntityType(string baseName)
        {
            BaseName = baseName;
            HeaderName = string.Format("{0} Header", BaseName);
            LineName = string.Format("{0} Line", BaseName);
        }

        public string BaseName
        {
            get;
            internal set;
        }

        public string HeaderName
        {
            get;
            set;
        }

        public string LineName
        {
            get;
            set;
        }
    }
}
