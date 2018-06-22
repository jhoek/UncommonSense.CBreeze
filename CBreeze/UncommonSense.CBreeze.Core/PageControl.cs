using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class PageControl : PageControlBase
    {
        public PageControl(string sourceExpr, int id = 0, int? indentationLevel = null) : base(id, indentationLevel)
        {
            Properties = new PageControlProperties(this);
            Properties.SourceExpr = sourceExpr;
        }

        public override string ToString() => $"{Type} {ID} ({Properties.SourceExpr})";

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