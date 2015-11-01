using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Set, "CBreezeMLValue")]
    public class SetCBreezeMLValue : Cmdlet
    {
        [Parameter(Mandatory=true,ValueFromPipeline=true)]
        public dynamic InputObject
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 0)]
        [ValidateSet("CaptionML", "OptionCaptionML", "ReqFilterHeadingML", "ToolTipML", "InstructionalTextML", "PromotedActionCategoriesML")] 
        public string Property
        {
            get;
            set;
        }

        [Parameter(Mandatory=true,Position=1)]
        public string LanguageName
        {
            get;
            set;
        }

        [Parameter(Mandatory=true,Position=2)]
        public string Value
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter PassThru
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            InputObject.Properties[Property].Value.Set(LanguageName, Value);

            if (PassThru)
                WriteObject(InputObject);
        }
    }
}
