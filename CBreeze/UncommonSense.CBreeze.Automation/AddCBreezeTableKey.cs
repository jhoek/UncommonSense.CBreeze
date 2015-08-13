using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTableKey")]
    public class AddCBreezeTableKey : AddCmdlet
    {
        [Parameter(Mandatory=true, ValueFromPipeline=true)]
        public Table Table
        {
            get;
            set;
        }

        [Parameter()]
        public bool? Clustered
        {
            get;
            set;
        }

        [Parameter()]
        public bool? Enabled
        {
            get;
            set;
        }

        [Parameter(Mandatory=true)]
        public string[] Fields
        {
            get;
            set;
        }

        [Parameter()]
        public string KeyGroups
        {
            get;
            set;
        }

        [Parameter()]
        public bool? MaintainSIFTIndex
        {
            get;
            set;
        }

        [Parameter()]
        public bool? MaintainSQLIndex
        {
            get;
            set;
        }

        [Parameter()]
        public string[] SQLIndex
        {
            get;
            set;
        }

        [Parameter()]
        public string[] SumIndexFields
        {
            get;
            set;
        }

        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                var tableKey = Table.Keys.Add();
                tableKey.Enabled = Enabled;
                tableKey.Fields.AddRange(Fields);
                tableKey.Properties.Clustered = Clustered;
                tableKey.Properties.KeyGroups = KeyGroups;
                tableKey.Properties.MaintainSIFTIndex = MaintainSIFTIndex;
                tableKey.Properties.MaintainSQLIndex = MaintainSQLIndex;
                // FIXME: tableKey.Properties.SIFTLevelsToMaintain = ...
                tableKey.Properties.SQLIndex.AddRange(SQLIndex ?? new string[] {});
                tableKey.Properties.SumIndexFields.AddRange(SumIndexFields ?? new string[] {});

                yield return tableKey;
            }
        }
    }
}
