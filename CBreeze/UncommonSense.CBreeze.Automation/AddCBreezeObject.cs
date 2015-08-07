using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeObject")]
    public class AddCBreezeObject : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Application Application
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Table")]
        public SwitchParameter Table
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Page")]
        public SwitchParameter Page
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Report")]
        public SwitchParameter Report
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Codeunit")]
        public SwitchParameter Codeunit
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Query")]
        public SwitchParameter Query
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "XmlPort")]
        public SwitchParameter XmlPort
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "MenuSuite")]
        public SwitchParameter MenuSuite
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1)]
        public int ID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 2)]
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

        [Parameter(ParameterSetName = "Table")]
        [Parameter(ParameterSetName = "Page")]
        [Parameter(ParameterSetName = "Report")]
        [Parameter(ParameterSetName = "Query")]
        [Parameter(ParameterSetName = "XmlPort")]
        public SwitchParameter AutoCaption
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "Table")]
        [Parameter(ParameterSetName = "Page")]
        public string[] DataCaptionFields
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "Table")]
        public bool? DataPerCompany
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "Table")]
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

            table.Properties.DataCaptionFields.AddRange(DataCaptionFields ?? new string[] { });
            table.Properties.DataPerCompany = DataPerCompany;
            table.Properties.DrillDownPageID = DrillDownPageID;

            if (AutoCaption)
            {
                table.AutoCaption();
            }

            // ...

            WriteObject(table);
        }
    }
}
