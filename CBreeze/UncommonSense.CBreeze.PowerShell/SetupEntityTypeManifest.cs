using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.PowerShell
{
    public class SetupEntityTypeManifest : CBreezePSManifest
    {
        public SetupEntityTypeManifest(Application application)
            : base(application)
        {
        }

        public Table SetupTable
        {
            get;
            set;
        }

        public CodeTableField SetupTablePrimaryKeyField
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
