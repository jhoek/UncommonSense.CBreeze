using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.Page.Control
{
    public class PageControl : PageControlBase
    {
        public PageControl(string sourceExpr, int id = 0, int? indentationLevel = null) : base(id, indentationLevel)
        {
            Properties = new PageControlProperties(this);
            Properties.SourceExpr = sourceExpr;
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
            get { yield return Properties; }
        }

        public PageControlProperties Properties
        {
            get;
            protected set;
        }

        public override PageControlType Type
        {
            get
            {
                return PageControlType.Field;
            }
        }

        public override string GetName()
        {
            return Properties.Name;
        }
    }
}