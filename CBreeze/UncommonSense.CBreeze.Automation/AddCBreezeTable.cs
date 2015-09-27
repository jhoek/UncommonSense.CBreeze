using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTable")]
    public class AddCBreezeTable : AddCBreezeObject
    {
        [Parameter()]
        public string[] DataCaptionFields
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
        public string Description
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

        [Parameter()]
        public bool? LinkedInTransaction
        {
            get;
            set;
        }

        [Parameter()]
        public bool? LinkedObject
        {
            get;
            set;
        }

        [Parameter()]
        public int? LookupPageID
        {
            get;
            set;
        }

        [Parameter()]
        public bool? PasteIsValid
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            foreach (var application in Application)
            {
                var table = application.Tables.Add(new Table(GetObjectID(application), Name));

                table.ObjectProperties.DateTime = DateTime;
                table.ObjectProperties.Modified = Modified;
                table.ObjectProperties.VersionList = VersionList;

                table.Properties.DataCaptionFields.AddRange(DataCaptionFields ?? new string[] { });
                table.Properties.DataPerCompany = DataPerCompany;
                table.Properties.Description = Description;
                table.Properties.DrillDownPageID = DrillDownPageID;
                table.Properties.LinkedInTransaction = LinkedInTransaction;
                table.Properties.LookupPageID = LookupPageID;
                table.Properties.LinkedObject = LinkedObject;
                table.Properties.PasteIsValid = PasteIsValid;

                if (AutoCaption)
                    table.AutoCaption();

                if (PassThru)
                    WriteObject(table);
            }
        }

        protected override IEnumerable<int> GetExistingObjectIDs(Application application)
        {
            return application.Tables.Select(t => t.ID);
        }
    }
}
