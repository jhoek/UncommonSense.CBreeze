using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class PageControlGroup : PageControlBase
    {
        public PageControlGroup(int id = 0, int? indentationLevel = null, PageControlGroupType? groupType = null) : base(id, indentationLevel)
        {
            Properties = new PageControlGroupProperties(this);
            Properties.GroupType = groupType;

            // Cannot set ActionList.Page from here; Container has not been set yet. Note that this
            // applies only to GroupPageControls, since the other page control types don't have their
            // own action lists. Properties.ActionList.Page = Container.Page;
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

        public override PageControls Container
        {
            get
            {
                return base.Container;
            }
            internal set
            {
                base.Container = value;
                Properties.ActionList.Page = Container == null ? null : Container.Page;
            }
        }

        public PageControlGroupProperties Properties
        {
            get;
            protected set;
        }

        public override PageControlType Type
        {
            get
            {
                return PageControlType.Group;
            }
        }

        public override string GetName()
        {
            return Properties.Name;
        }
    }
}