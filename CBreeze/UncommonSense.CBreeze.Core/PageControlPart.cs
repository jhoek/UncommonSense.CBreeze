using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class PageControlPart : PageControlBase
    {
        public PageControlPart(int id = 0, int? indentationLevel = null)
            : base(id, indentationLevel)
        {
            Properties = new PageControlPartProperties(this);
        }

        public override string ToString() => $"{Type} {ID} ({Properties.PartType})";

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