using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeCodeunit")]
    public class AddCBreezeCodeunit : AddCBreezeObject
    {
        [Parameter()]
        public bool? CFrontMayUsePermissions
        {
            get;
            set;
        }

        [Parameter()]
        public bool? SingleInstance
        {
            get;
            set;
        }

        [Parameter()]
        public CodeunitSubType? SubType
        {
            get;
            set;
        }

        [Parameter()]
        public int? TableNo
        {
            get;
            set;
        }

        [Parameter()]
        public TestIsolation? TestIsolation
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            foreach (var application in Application)
            {
                var codeunit = application.Codeunits.Add(new Codeunit(GetObjectID(application), Name));

                codeunit.ObjectProperties.DateTime = DateTime;
                codeunit.ObjectProperties.Modified = Modified;
                codeunit.ObjectProperties.VersionList = VersionList;

                codeunit.Properties.CFRONTMayUsePermissions = CFrontMayUsePermissions;
                codeunit.Properties.SingleInstance = SingleInstance;
                codeunit.Properties.Subtype = SubType;
                codeunit.Properties.TableNo = TableNo;
                codeunit.Properties.TestIsolation = TestIsolation;

                if (PassThru)
                    WriteObject(codeunit);
            }   
        }

        protected override IEnumerable<int> GetExistingObjectIDs(Application application)
        {
            return application.Codeunits.Select(c => c.ID);
        }
    }
}
