using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public class AddCommunicationFieldsManifest
    {
        internal AddCommunicationFieldsManifest()
        {
        }

        public TextTableField ContactField
        {
            get;
            internal set;
        }

        public TextTableField PhoneNoField
        {
            get;
            internal set;
        }

        public TextTableField TelexNoField
        {
            get;
            internal set;
        }

        public TextTableField TelexAnswerBackField
        {
            get;
            internal set;
        }

        public TextTableField FaxNoField
        {
            get;
            internal set;
        }

        public TextTableField EMailField
        {
            get;
            internal set;
        }

        public TextTableField HomePageField
        {
            get;
            internal set;
        }
    }
}
