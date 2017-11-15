using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class FieldPageControl : PageControlBase
    {
        public FieldPageControl(string sourceExpr, int id = 0, int? indentationLevel = null) : base(id, indentationLevel)
        {
            Properties = new FieldPageControlProperties(this);
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

        public FieldPageControlProperties Properties
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