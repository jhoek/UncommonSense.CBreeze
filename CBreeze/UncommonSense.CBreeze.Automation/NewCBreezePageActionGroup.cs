using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezePageActionGroup")]
    [OutputType(typeof(PageActionGroup))]
    public class NewCBreezePageActionGroup : NewCBreezePageActionBase
    {
        [Parameter(Position = 1)]
        public string Caption
        {
            get; set;
        }

        [Parameter(Position = 2)]
        public ScriptBlock ChildActions
        {
            get; set;
        }

        [Parameter()]
        public string Description
        {
            get; set;
        }

        [Parameter()]
        public string Enabled
        {
            get; set;
        }

        [Parameter()]
        public string Image
        {
            get; set;
        }

        [Parameter()]
        public string Name
        {
            get; set;
        }

        [Parameter()]
        public string Visible
        {
            get; set;
        }

        protected PageActionGroup CreatePageActionGroup()
        {
            var pageActionGroup = new PageActionGroup(GetID(), GetIndentation());

            pageActionGroup.Properties.CaptionML.Set("ENU", Caption);
            pageActionGroup.Properties.Description = Description;
            pageActionGroup.Properties.Enabled = Enabled;
            pageActionGroup.Properties.Image = Image;
            pageActionGroup.Properties.Name = Name;
            pageActionGroup.Properties.Visible = Visible;

            return pageActionGroup;
        }

        protected override void ProcessRecord()
        {
            WriteObject(CreatePageActionGroup());

            if (ChildActions != null)
            {
                var variables = new List<PSVariable>() { new PSVariable("Indentation", GetIndentation() + 1) };
                WriteObject(ChildActions.InvokeWithContext(null, variables), true);
            }
        }
    }
}
