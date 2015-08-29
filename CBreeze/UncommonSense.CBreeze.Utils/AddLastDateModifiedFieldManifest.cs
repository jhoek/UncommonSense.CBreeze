using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public class AddLastDateModifiedFieldManifest
    {
        internal AddLastDateModifiedFieldManifest()
        {
        }

        public DateTableField LastDateModifiedField
        {
            get;
            internal set;
        }
    }
}
