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

        protected Codeunit CreateCodeunit()
        {
            var codeunit = new Codeunit(ID, Name);
            SetObjectProperties(codeunit);

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

            if (SubObjects != null)
            {
                var subObjects = SubObjects.Invoke().Select(o => o.BaseObject);

                subObjects.OfType<Function>().ToList().ForEach(f => codeunit.Code.Functions.Add(f));
                subObjects.OfType<Variable>().ToList().ForEach(v => codeunit.Code.Variables.Add(v));
            }

            return codeunit;
        }

        protected override void ProcessRecord()
        {

            WriteObject(CreateCodeunit());
        }
    }
}

