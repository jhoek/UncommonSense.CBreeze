using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class MenuSuite : Object
    {
        public MenuSuite(int id, string name)
            : base(id, name)
        {
            Properties = new MenuSuiteProperties();
            Nodes = new MenuSuiteNodes();
        }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.MenuSuite;
            }
        }

        public MenuSuiteProperties Properties
        {
            get;
            protected set;
        }

        public MenuSuiteNodes Nodes
        {
            get;
            protected set;
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
