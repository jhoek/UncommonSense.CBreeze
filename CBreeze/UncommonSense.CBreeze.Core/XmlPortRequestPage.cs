using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class XmlPortRequestPage : IPage, INode
    {
        internal XmlPortRequestPage(XmlPort xmlPort)
        {
            XmlPort = xmlPort;

            Properties = new XmlPortRequestPageProperties(this);
            Properties.ActionList.Page = this;

            Controls = new PageControls(this);
        }

        public PageControls Controls
        {
            get;
            protected set;
        }

        public XmlPortRequestPageProperties Properties
        {
            get;
            protected set;
        }

        public XmlPort XmlPort
        {
            get;
            protected set;
        }


        public ActionList Actions
        {
            get
            {
                return Properties.ActionList;
            }
        }

        public int ObjectID
        {
            get
            {
                return XmlPort.ID;
            }
        }

        public INode ParentNode => XmlPort;

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
                yield return Controls;
            }
        }
    }
}
