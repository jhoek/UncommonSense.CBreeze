using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezePageActionContainer")]
    [OutputType(typeof(PageActionContainer))]
    [Alias("ActionContainer")]
    public class NewCBreezePageActionContainer : NewCBreezePageActionBase
    {
        protected PageActionContainer CreatePageActionContainer()
        {
            var pageActionContainer = new PageActionContainer(0, GetID(), ContainerType);
            pageActionContainer.Properties.Description = Description;
            pageActionContainer.Properties.Name = Name;

            return pageActionContainer;
        }

        protected override void ProcessRecord()
        {
            WriteObject(CreatePageActionContainer());

            if (ChildActions != null)
            {
                var variables = new List<PSVariable>() { new PSVariable("Indentation", GetIndentation() + 1) };
                WriteObject(ChildActions.InvokeWithContext(null, variables), true);
            }
        }

        [Parameter(Position = 2)]
        public ScriptBlock ChildActions
        {
            get; set;
        }

        [Parameter(Mandatory = true, Position = 1)]
        public ActionContainerType ContainerType
        {
            get; set;
        }

        [Parameter()]
        public string Description
        {
            get; set;
        }

        [Parameter()]
        public string Name
        {
            get; set;
        }
    }
}