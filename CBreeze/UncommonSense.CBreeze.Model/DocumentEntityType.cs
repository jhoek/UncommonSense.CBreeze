using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
    public class DocumentEntityType : EntityType
    {
        public DocumentEntityType(string baseName, SetupEntityType setupEntityType)
        {
            BaseName = baseName;
            HeaderName = string.Format("{0} Header", BaseName);
            LineName = string.Format("{0} Line", BaseName);
            SetupEntityType = setupEntityType;
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

        public SetupEntityType SetupEntityType
        {
            get;
            internal set;
        }

        public string DocumentTypeOptions
        {
            get;
            set;
        }
    }
}
