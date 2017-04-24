using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeMenuSuite", DefaultParameterSetName = NewWithoutID)]
    [OutputType(typeof(MenuSuite))]
    public class AddCBreezeMenuSuite : NewCBreezeObject
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = AddWithID)]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = AddWithoutID)]
        public Application Application { get; set; }

        [Parameter(ParameterSetName = AddWithID)]
        [Parameter(ParameterSetName = AddWithoutID)]
        public SwitchParameter PassThru { get; set; } = true;

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
            switch (ParameterSetName)
            {
                case NewWithoutID:
                case NewWithID:
                    WriteObject(CreateMenuSuite());
                    break;

                case AddWithoutID:
                case AddWithID:
                    Application.MenuSuites.Add(CreateMenuSuite()).DoIf(PassThru, m => WriteObject(m));
                    break;
            }
        }
    }
}