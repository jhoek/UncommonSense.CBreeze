// --------------------------------------------------------------------------------
// <auto-generated>
//      This code was generated by a tool.
//
//      Changes to this file may cause incorrect behaviour and will be lost if
//      the code is regenerated.
// </auto-generated>
// --------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class MenuSuite : Object
    {
        private MenuSuiteProperties properties = new MenuSuiteProperties();
        private MenuSuiteNodes nodes = new MenuSuiteNodes();

        internal MenuSuite(Int32 id, String name) : base(id, name)
        {
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
            get
            {
                return this.properties;
            }
        }

        public MenuSuiteNodes Nodes
        {
            get
            {
                return this.nodes;
            }
        }

    }
}