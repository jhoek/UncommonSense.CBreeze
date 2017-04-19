using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezePage", DefaultParameterSetName = "ManualObjectProperties")]
    public class AddCBreezePage : NewCBreezePage
    {
        public AddCBreezePage()
        {
            PassThru = true;
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Application Application
        {
            get; set;
        }

        [Parameter()]
        public SwitchParameter PassThru
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            var page = CreatePage();
            Application.Pages.Add(page);

            if (PassThru)
            {
                WriteObject(page);
            }
        }
    }
}
