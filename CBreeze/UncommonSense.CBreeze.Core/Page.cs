using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
        public class Page : Object, IHasCode, IPage
    {
        public Page(int id, string name)
            : base(id, name)
        {
            Properties = new PageProperties();
            Controls = new PageControls(this);
            Code = new Code(this);
        }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.Page;
            }
        }

        public PageProperties Properties
        {
            get;
            protected set;
        }

        public PageControls Controls
        {
            get;
            protected set;
        }

        public Code Code
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
                return ID;
            }
        }
    }
}
