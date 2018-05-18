using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class RootNode : MenuSuiteNode
    {
        public RootNode(Guid id)
            : base(id)
        {
            Properties = new MenuSuiteRootNodeProperties(this);
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public override MenuSuiteNodeType Type
        {
            get
            {
                return MenuSuiteNodeType.Root;
            }
        }

        public MenuSuiteRootNodeProperties Properties
        {
            get;
            protected set;
        }

        public override string GetName()
        {
            return null;
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
