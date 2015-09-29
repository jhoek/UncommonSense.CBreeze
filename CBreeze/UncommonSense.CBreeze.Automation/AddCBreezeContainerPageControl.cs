using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeContainerPageControl")]
    public class AddCBreezeContainerPageControl : AddCBreezePageControl
    {
        [Parameter(Mandatory = true)]
        public ContainerType Type
        {
            get;
            set;
        }

        [Parameter()]
        public string Description
        {
            get;
            set;
        }

        [Parameter()]
        public string Name
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            var control = new ContainerPageControl(GetPageControlID(), 0);
            control.Properties.ContainerType = Type;
            control.Properties.Description = Description;
            control.Properties.Name = Name;

            switch (Type)
            {
                case ContainerType.ContentArea:
                    Page.Controls.Insert(0, control);
                    break;
                case ContainerType.FactBoxArea:
                    Page.Controls.Add(control);
                    break;
                case ContainerType.RoleCenterArea:
                    Page.Controls.Insert(0, control);
                    break;
            }

            if (PassThru)
                WriteObject(control);
        }

    }
}
