using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public class AddNoFromNoSeriesFieldManifest
    {
        internal AddNoFromNoSeriesFieldManifest()
        {
        }

        public CodeTableField NoField
        {
            get;
            internal set;
        }

        public CodeTableField NoSeriesField
        {
            get;
            internal set;
        }
    }
}
