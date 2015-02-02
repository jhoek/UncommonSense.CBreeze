using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.PowerShell
{
    public abstract class CBreezePSCmdlet : PSCmdlet
    {
        private Application application;

        [Parameter(ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public Application Application
        {
            get
            {
                if (this.application == null)
                {
                    this.application = new Application();
                }

                return this.application;
            }
            set
            {
                this.application = value;
            }
        }
    }
}
