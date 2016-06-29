using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class XmlPortTextElement : XmlPortNode
    {
        public XmlPortTextElement(Guid id, string nodeName, int? indentationLevel)
            : base(id, nodeName, indentationLevel)
        {
            Properties = new XmlPortTextElementProperties();
        }

        public override XmlPortNodeAndSourceType Type
        {
            get
            {
                return XmlPortNodeAndSourceType.XmlPortTextElement;
            }
        }

        public XmlPortTextElementProperties Properties
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
