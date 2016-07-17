using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
		public class GroupPageControl : PageControl
	{
		public GroupPageControl(int id, int? indentationLevel)
			: base(id, indentationLevel)
		{
			Properties = new GroupPageControlProperties();

            // Cannot set ActionList.Page from here; Container has not been set yet.
            // Note that this applies only to GroupPageControls, since the other
            // page control types don't have their own action lists.
            // Properties.ActionList.Page = Container.Page;
		}

		public override PageControlType Type
		{
			get
			{
				return PageControlType.Group;
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

		public GroupPageControlProperties Properties
		{
			get;
			protected set;
		}

		public override Properties AllProperties
		{
			get
			{
				return Properties;
			}
		}

		public override string GetName()
		{
			return Properties.Name;
		}
	}
}
