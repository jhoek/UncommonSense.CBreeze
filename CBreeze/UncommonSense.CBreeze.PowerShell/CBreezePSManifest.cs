using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.PowerShell
{
    public abstract class CBreezePSManifest
    {
        private Application application;

        public CBreezePSManifest(Application application)
        {
            this.application = application;
        }

        public Application Application
        {
            get
            {
                return this.application;
            }
        }
    }
}
