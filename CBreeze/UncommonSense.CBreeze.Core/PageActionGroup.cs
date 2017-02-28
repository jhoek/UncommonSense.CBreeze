using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
		public class PageActionGroup : PageActionBase
	{
		public PageActionGroup(int id, int? indentationLevel)
			: base(id, indentationLevel)
		{
			Properties = new PageActionGroupProperties(this);
		}

		public override PageActionBaseType Type
		{
			get
			{
				return PageActionBaseType.ActionGroup;
			}
		}

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public PageActionGroupProperties Properties
		{
			get;
			protected set;
		}

		public override string GetName()
		{
			return Properties.Name;
		}

		public override Properties AllProperties
		{
			get
			{
				return Properties;
			}
		}
	}
}
