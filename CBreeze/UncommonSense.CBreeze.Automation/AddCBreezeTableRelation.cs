using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTableRelation")]
    public class AddCBreezeTableRelation : Cmdlet 
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public dynamic InputObject
        {
            get;
            set;
        }

        [Parameter(Mandatory=true)]
        public string TableName
        {
            get;
            set;
        }

        [Parameter()]
        public string FieldName
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
            var tableRelationLine = InputObject.Properties.TableRelation.Add(TableName);
            tableRelationLine.FieldName = FieldName;

            if (PassThru)
                WriteObject(tableRelationLine);
        }
    }
}
