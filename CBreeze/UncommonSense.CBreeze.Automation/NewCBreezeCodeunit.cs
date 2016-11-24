using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeCodeunit")]
    public class NewCBreezeCodeunit : NewCBreezeObject
    {
        [Parameter(Mandatory = true, Position = 0)]
        [Alias("Range")]
        public PSObject ID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1)]
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
        public bool Modified
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

#if !NAV2016
        [Parameter()]
        public bool? CFrontMayUsePermissions
        {
            get; set;
        }
#endif

#if NAV2016
        [Parameter()]
        public EventSubscriberInstance? EventSubscriberInstance
        {
            get;
            set;
        }
#endif

        [Parameter()]
        public bool? SingleInstance
        {
            get;
            set;
        }

        [Parameter()]
        public CodeunitSubType? SubType
        {
            get; set;
        }

        [Parameter()]
        [ValidateRange(1, int.MaxValue)]
        public int? TableNo
        {
            get; set;
        }

        [Parameter()]
        public TestIsolation? TestIsolation
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            var codeunit = new Codeunit(ID.GetID(null, 0), Name);

            codeunit.ObjectProperties.DateTime = DateTime;
            codeunit.ObjectProperties.Modified = Modified;
            codeunit.ObjectProperties.VersionList = VersionList;

#if !NAV2016
            codeunit.Properties.CFRONTMayUsePermissions = CFrontMayUsePermissions;
#endif
#if NAV2016
            codeunit.Properties.EventSubscriberInstance = EventSubscriberInstance;
#endif
            codeunit.Properties.SingleInstance = SingleInstance;
            codeunit.Properties.Subtype = SubType;
            codeunit.Properties.TableNo = TableNo;
            codeunit.Properties.TestIsolation = TestIsolation;

            WriteObject(codeunit);
        }
    }
}

