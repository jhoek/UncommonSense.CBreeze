using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class PageActionSeparator : PageActionBase
    {
        public PageActionSeparator(int id = 0, int? indentationLevel = null)
            : base(id, indentationLevel)
        {
            Properties = new PageActionSeparatorProperties(this);
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

        public PageActionSeparatorProperties Properties
        {
            get;
            protected set;
        }

        public override PageActionType Type
        {
            get
            {
                return PageActionType.Separator;
            }
        }

        public override string GetName()
        {
            return null;
        }
    }
}