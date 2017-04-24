using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class PartPageControl : PageControl
    {
        public PartPageControl(int id = 0, int? indentationLevel = null, PartType partType = PartType.Page)
            : base(id, indentationLevel)
        {
            Properties = new PartPageControlProperties(this);
            Properties.PartType = partType;
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

        public PartPageControlProperties Properties
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