using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeMLValue")]
    public class AddCBreezeMLValue : Cmdlet
    {
        [Parameter(Mandatory=true,ValueFromPipeline=true)]
        public dynamic InputObject
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 0)]
        [ValidateSet("CaptionML", "OptionCaptionML", "ReqFilterHeadingML", "TooltipML", "InstructionalTextML", "PromotedActionCategoriesML")] 
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

        protected override void ProcessRecord()
        {
            InputObject.Properties[Property].Value.Add(LanguageName, Value);
        }
    }
}
