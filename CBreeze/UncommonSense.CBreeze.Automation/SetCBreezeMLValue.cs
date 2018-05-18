using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Set, "CBreezeMLValue")]
    [Alias("MLValue")]
    public class SetCBreezeMLValue : Cmdlet
    {
        public SetCBreezeMLValue()
        {
            Property = "CaptionML";
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject InputObject
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1)]
        public string LanguageName
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

        [Parameter(Position = 0)]
        [ValidateNotNullOrEmpty()]
        [ValidateSet("CaptionML", "OptionCaptionML", "ReqFilterHeadingML", "ToolTipML", "InstructionalTextML", "PromotedActionCategoriesML")]
        public string Property
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 2)]
        public string Value
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            if (InputObject.BaseObject is TextConstant)
                (InputObject.BaseObject as TextConstant).Values.Set(LanguageName, Value);
            else if (InputObject.BaseObject is IHasProperties)
                (InputObject.BaseObject as IHasProperties).AllProperties.ByName<MultiLanguageProperty>(Property).Value.Set(LanguageName, Value);
            else
                throw new ArgumentOutOfRangeException("Cannot add a multi-language value to this object.");

            if (PassThru)
                WriteObject(InputObject);
        }
    }
}