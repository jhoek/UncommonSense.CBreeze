using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeMenuSuite", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(MenuSuite))]
    [Alias("MenuSuite")]
    public class NewCBreezeMenuSuite : NewCBreezeObject<MenuSuite>
    {
        protected override void AddItemToInputObject(MenuSuite item, Application inputObject)
        {
            inputObject.MenuSuites.Add(item);
        }

        protected override MenuSuite CreateItem()
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
    }
}