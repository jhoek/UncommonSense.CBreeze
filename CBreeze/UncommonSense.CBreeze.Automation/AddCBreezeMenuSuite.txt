using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeMenuSuite")]
    public class AddCBreezeMenuSuite : AddCBreezeObject
    {
        protected override void ProcessRecord()
        {
            foreach (var application in Application)
            {
                var menuSuite = application.MenuSuites.Add(new MenuSuite(GetObjectID(application), Name));

                menuSuite.ObjectProperties.DateTime = DateTime;
                menuSuite.ObjectProperties.Modified = Modified;
                menuSuite.ObjectProperties.VersionList = VersionList;

                if (PassThru)
                    WriteObject(menuSuite);
            }
        }

        protected override IEnumerable<int> GetExistingObjectIDs(Core.Application application)
        {
            return application.MenuSuites.Select(m => m.ID);
        }
    }
}
