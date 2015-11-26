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
    public abstract partial class XmlPortNode : KeyedItem<Guid>, IHasProperties
    {
        private String nodeName;
        private Int32? indentationLevel;

        internal XmlPortNode(Guid id, String nodeName, Int32? indentationLevel)
        {
            ID = id;
            this.indentationLevel = indentationLevel;
            this.nodeName = nodeName;
        }

        public abstract XmlPortNodeType Type
        {
            get;
        }

        public String NodeName
        {
            get
            {
                return this.nodeName;
            }
        }

        public XmlPortNodes Container
        {
            get;
            internal set;
        }

        public Int32? IndentationLevel
        {
            get
            {
                return this.indentationLevel;
            }
        }

        public abstract Properties AllProperties
        {
            get;
        }
    }
}
