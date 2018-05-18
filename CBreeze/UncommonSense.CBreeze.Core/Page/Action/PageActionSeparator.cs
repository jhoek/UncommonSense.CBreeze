using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.Page.Action
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