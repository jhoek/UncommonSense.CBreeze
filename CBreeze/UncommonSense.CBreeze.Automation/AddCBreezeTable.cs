using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTable")]
    public class AddCBreezeTable : AddCBreezeObject
    {
        public string[] DataCaptionFields
        {
            get;
            set;
        }

        public bool? DataPerCompany
        {
            get;
            set;
        }

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

            table.AutoCaptionIf(AutoCaption);

            // ...

            this.WriteObjectIf(PassThru, table);
        }
    }
}
