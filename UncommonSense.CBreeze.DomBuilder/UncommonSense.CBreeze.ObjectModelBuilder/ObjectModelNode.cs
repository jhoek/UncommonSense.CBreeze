﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
    public abstract class ObjectModelNode
    {
        public ObjectModelNode ParentNode
        {
            get;
            internal set;
        }
    }
}
