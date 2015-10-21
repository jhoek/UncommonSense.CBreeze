using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeCondition")]
    public class AddCBreezeCondition : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public TableRelationLine InputObject
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 0)]
        public string FieldName
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "Const")]
        public SwitchParameter Const
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "Filter")]
        public SwitchParameter Filter
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 2)]
        [AllowEmptyString]
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
            InputObject.Conditions.Add(FieldName, SimpleTableFilterType, Value);

            if (PassThru)
                WriteObject(InputObject);
        }

        protected SimpleTableFilterType SimpleTableFilterType
        {
            get
            {
                if (Const.IsPresent)
                    return Core.SimpleTableFilterType.Const;
                if (Filter.IsPresent)
                    return Core.SimpleTableFilterType.Filter;

                throw new ArgumentOutOfRangeException("SimpleTableFilterType");
            }
        }
     }
}
