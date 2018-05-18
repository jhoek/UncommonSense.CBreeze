using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.Page.Control
{
    public class PageControlPart : PageControlBase
    {
        public PageControlPart(int id = 0, int? indentationLevel = null)
            : base(id, indentationLevel)
        {
            Properties = new PageControlPartProperties(this);
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

        public PageControlPartProperties Properties
        {
            get;
            protected set;
        }

        public override PageControlType Type
        {
            get
            {
                return PageControlType.Part;
            }
        }

        public override string GetName()
        {
            return Properties.Name;
        }
    }
}