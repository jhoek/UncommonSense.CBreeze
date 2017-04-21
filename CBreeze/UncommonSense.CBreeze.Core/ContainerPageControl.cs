using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class ContainerPageControl : PageControl
    {
        public ContainerPageControl(int id = 0, int? indentationLevel = null, ContainerType containerType = ContainerType.ContentArea) : base(id, indentationLevel)
        {
            Properties = new ContainerPageControlProperties(this);
            Properties.ContainerType = containerType;
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public ContainerPageControlProperties Properties
        {
            get;
            protected set;
        }

        public override PageControlType Type
        {
            get
            {
                return PageControlType.Container;
            }
        }

        public GroupPageControl GetGroupByCaption(string caption, Position position)
        {
            var groupPageControl = ChildPageControls.OfType<GroupPageControl>().FirstOrDefault(c => c.Properties.CaptionML["ENU"] == caption);

            if (groupPageControl == null)
            {
                groupPageControl = new GroupPageControl(indentationLevel: 1);
                groupPageControl.Properties.CaptionML.Set("ENU", caption);
                this.AddChildPageControl(groupPageControl, position);
            }

            return groupPageControl;
        }

        public GroupPageControl GetGroupByType(GroupType type, Position position)
        {
            var groupPageControl = ChildPageControls.OfType<GroupPageControl>().FirstOrDefault(g => g.Properties.GroupType == type);

            if (groupPageControl == null)
            {
                groupPageControl = new GroupPageControl(indentationLevel: 1);
                groupPageControl.Properties.GroupType = type;
                AddChildPageControl(groupPageControl, position);
            }

            return groupPageControl;
        }

        public override string GetName()
        {
            return Properties.Name;
        }
    }
}