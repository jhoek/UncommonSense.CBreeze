using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class MenuSuiteRootNodeProperties : Properties
    {
        private NullableGuidProperty firstChild = new NullableGuidProperty("FirstChild");

        internal MenuSuiteRootNodeProperties(RootNode node)
        {
            Node = node;
            innerList.Add(firstChild);
        }

        public RootNode Node { get; protected set; }

        public override INode ParentNode => Node;

        public System.Guid? FirstChild
        {
            get
            {
                return this.firstChild.Value;
            }
            set
            {
                this.firstChild.Value = value;
            }
        }
    }
}
