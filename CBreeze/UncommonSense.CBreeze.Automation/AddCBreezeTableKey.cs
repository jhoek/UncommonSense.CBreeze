using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTableKey")]
    public class AddCBreezeTableKey : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Table[] Table
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

        [Parameter(Mandatory = true)]
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

        [Parameter()]
        public SwitchParameter PassThru
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            foreach (var table in Table)
            {
                var tableKey = table.Keys.Add(new TableKey(Fields));
                tableKey.Enabled = Enabled;
                tableKey.Properties.Clustered = Clustered;
                tableKey.Properties.KeyGroups = KeyGroups;
                tableKey.Properties.MaintainSIFTIndex = MaintainSIFTIndex;
                tableKey.Properties.MaintainSQLIndex = MaintainSQLIndex;
                tableKey.Properties.SQLIndex.AddRange(SQLIndex ?? new string[] { });
                tableKey.Properties.SumIndexFields.AddRange(SumIndexFields ?? new string[] { });

                if (PassThru)
                    WriteObject(tableKey);

            }
        }
    }
}
