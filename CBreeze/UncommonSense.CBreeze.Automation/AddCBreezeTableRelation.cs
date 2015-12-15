using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTableRelation")]
    public class AddCBreezeTableRelation : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject InputObject
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 0)]
        public string TableName
        {
            get;
            set;
        }

        [Parameter(Position = 1)]
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
            var tableRelationLine = new TableRelationLine(TableName);
            tableRelationLine.FieldName = FieldName;

            if (InputObject.BaseObject is TableField)
            {
                var tableField = (InputObject.BaseObject as TableField);
                var tableRelationProperty = (tableField.AllProperties["TableRelation"] as TableRelationProperty);

                tableRelationProperty.Value.Add(tableRelationLine);
            }
            else if (InputObject.BaseObject is FieldPageControl)
            {
                var fieldPageControl = (InputObject.BaseObject as FieldPageControl);
                fieldPageControl.Properties.TableRelation.Add(tableRelationLine);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Don't know how to add a table relation to this InputObject.");
            }

            if (PassThru)
                WriteObject(tableRelationLine);
        }
    }
}
