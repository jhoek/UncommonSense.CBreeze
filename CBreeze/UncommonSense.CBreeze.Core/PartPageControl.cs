using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class PartPageControl : PageControl
    {
        public PartPageControl(int id, int? indentationLevel)
            : base(id, indentationLevel)
        {
            Properties = new PartPageControlProperties(this);
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public override PageControlType Type
        {
            get
            {
                return PageControlType.Part;
            }
        }

        public PartPageControlProperties Properties
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
