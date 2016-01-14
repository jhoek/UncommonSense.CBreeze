using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class XmlPortRequestPage : IPage
    {
        internal XmlPortRequestPage(XmlPort xmlPort)
        {
            XmlPort = xmlPort;
            Properties = new XmlPortRequestPageProperties();
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
    }
}
