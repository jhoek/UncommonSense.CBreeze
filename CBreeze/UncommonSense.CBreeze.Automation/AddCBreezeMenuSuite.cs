using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeMenuSuite")]
    public class AddCBreezeMenuSuite : AddCBreezeObject
    {
        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                var menuSuite = Application.MenuSuites.Add(ID, Name);

                menuSuite.ObjectProperties.DateTime = DateTime;
                menuSuite.ObjectProperties.Modified = Modified;
                menuSuite.ObjectProperties.VersionList = VersionList;

                yield return menuSuite;
            }
        }
    }
}
