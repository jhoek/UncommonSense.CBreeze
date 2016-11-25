using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeMenuSuite", DefaultParameterSetName = "ManualObjectProperties")]
    public class NewCBreezeMenuSuite : NewCBreezeObject
    {
        protected MenuSuite CreateMenuSuite()
        {
            var menusuite = new MenuSuite(ID.GetID(null, 0), Name);
            SetObjectProperties(menusuite);
            return menusuite;
        }

        protected override void ProcessRecord()
        {
            WriteObject(CreateMenuSuite());
        }
    }
}
