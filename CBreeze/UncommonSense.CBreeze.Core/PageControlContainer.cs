using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class PageControlContainer : PageControlBase
    {
        public PageControlContainer(int id = 0, int? indentationLevel = null, PageControlContainerType containerType = PageControlContainerType.ContentArea) : base(id, indentationLevel)
        {
            Properties = new PageControlContainerProperties(this);
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

        public PageControlContainerProperties Properties
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

        public PageControlGroup GetGroupByCaption(string caption, Position position)
        {
            var groupPageControl = Children.OfType<PageControlGroup>().FirstOrDefault(c => c.Properties.CaptionML["ENU"] == caption);

            if (groupPageControl == null)
            {
                groupPageControl = new PageControlGroup(indentationLevel: 1);
                groupPageControl.Properties.CaptionML.Set("ENU", caption);
                this.AddChildPageControl(groupPageControl, position);
            }

            return groupPageControl;
        }

        public PageControlGroup GetGroupByType(PageControlGroupType type, Position position)
        {
            var groupPageControl = Children.OfType<PageControlGroup>().FirstOrDefault(g => g.Properties.GroupType == type);

            if (groupPageControl == null)
            {
                groupPageControl = new PageControlGroup(indentationLevel: 1);
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