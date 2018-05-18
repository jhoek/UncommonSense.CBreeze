using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class PageActionGroup : PageActionBase
    {
        public PageActionGroup(int id = 0, int? indentationLevel = null, string caption = null)
            : base(id, indentationLevel)
        {
            Properties = new PageActionGroupProperties(this);
            Properties.CaptionML.Set("ENU", caption);
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

        public PageActionGroupProperties Properties
        {
            get;
            protected set;
        }

        public override PageActionType Type
        {
            get
            {
                return PageActionType.ActionGroup;
            }
        }

        public override string GetName()
        {
            return Properties.Name;
        }
    }
}