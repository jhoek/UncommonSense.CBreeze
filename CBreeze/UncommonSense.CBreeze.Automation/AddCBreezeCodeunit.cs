using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

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

        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                var codeunit = Application.Codeunits.Add(ID, Name);

                codeunit.ObjectProperties.DateTime = DateTime;
                codeunit.ObjectProperties.Modified = Modified;
                codeunit.ObjectProperties.VersionList = VersionList;

                codeunit.Properties.CFRONTMayUsePermissions = CFrontMayUsePermissions;

                yield return codeunit;                
            }
        }
    }
}
