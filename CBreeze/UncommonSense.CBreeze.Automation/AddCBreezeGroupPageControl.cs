using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeGroupPageControl")]
    public class AddCBreezeGroupPageControl : AddCBreezePageControl
    {
        [Parameter(Mandatory = true,ValueFromPipeline=true)]
        public PageControl To
        {
            get;
            set;
        }

        [Parameter()]
        public Position As
        {
            get;
            set;
        }

        [Parameter()]
        public GroupType? Type
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
        public string Editable
        {
            get;
            set;
        }

        [Parameter()]
        public string Enabled
        {
            get;
            set;
        }

        [Parameter()]
        public string FreezeColumn
        {
            get;
            set;
        }

        [Parameter()]
        public string IndentationColumn
        {
            get;
            set;
        }

        [Parameter()]
        public string[] IndentationControls
        {
            get;
            set;
        }

        [Parameter()]
        public GroupPageControlLayout? Layout
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

        [Parameter()]
        public bool? ShowAsTree
        {
            get;
            set;
        }

        [Parameter()]
        public string Visible
        {
            get;
            set;
        }

        public AddCBreezeGroupPageControl()
        {
            As = Position.LastWithinContainer;
        }

        protected override void ProcessRecord()
        {
            if (!Type.HasValue)
            {
                switch (GetPage().Properties.PageType)
                {
                    case PageType.Card:
                        Type = GroupType.Group;
                        break;
                    case PageType.List:
                        Type = GroupType.Repeater;
                        break;
                }
            }

            var control = new GroupPageControl(GetPageControlID(), To.IndentationLevel + 1);

            control.Properties.GroupType = Type;
            control.Properties.Description = Description;
            control.Properties.Editable = Editable;
            control.Properties.Enabled = Enabled;
            control.Properties.FreezeColumnID = FreezeColumn;
            control.Properties.IndentationColumnName = IndentationColumn;
            control.Properties.IndentationControls.AddRange(IndentationControls ?? new string[] { });
            control.Properties.Layout = Layout;
            control.Properties.Name = Name;
            control.Properties.ShowAsTree = ShowAsTree;
            control.Properties.Visible = Visible;

            To.AddChildPageControl(control, As);

            if (PassThru)
                WriteObject(control);
        }

        protected override Page GetPage()
        {
            return To.Container.Page;
        }
    }
}
