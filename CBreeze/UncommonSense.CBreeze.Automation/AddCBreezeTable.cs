using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTable")]
    public class AddCBreezeTable : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public Application Application
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position=0)]
        public int ID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position=1)]
        [ValidateLength(1, 30)]
        public string Name
        {
            get;
            set;
        }

        [Parameter()]
        public DateTime? DateTime
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter Modified
        {
            get;
            set;
        }

        [Parameter()]
        public string VersionList
        {
            get;
            set;
        }

        [Parameter()]
        public bool? DataPerCompany
        {
            get;
            set;
        }

        [Parameter()]
        public int? DrillDownPageID
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            var table = Application.Tables.Add(ID, Name);

            table.ObjectProperties.DateTime = DateTime;
            table.ObjectProperties.Modified = Modified;
            table.ObjectProperties.VersionList = VersionList;

            table.Properties.DataPerCompany = DataPerCompany;
            table.Properties.DrillDownPageID = DrillDownPageID;

            // ...

            WriteObject(table);
        }
    }
}
