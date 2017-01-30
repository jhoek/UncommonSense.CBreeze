using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeMenuSuite")]
    [OutputType(typeof(MenuSuite))]
    public class NewCBreezeMenuSuite : NewCBreezeObject
    {
        protected MenuSuite CreateMenuSuite()
        {
            var menusuite = new MenuSuite(ID, Name);
            SetObjectProperties(menusuite);

            SubObjects?
                .Invoke()
                .Select(o => o.BaseObject)
                .Cast<MenuSuiteNode>()
                .ForEach(n => menusuite.Nodes.Add(n));

            return menusuite;
        }

        protected override void ProcessRecord()
        {
            WriteObject(CreateMenuSuite());
        }
    }
}
