using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public abstract partial class MenuSuiteNode
    {
        private Guid id;

        internal MenuSuiteNode(Guid id)
        {
            this.id = id;
        }

        public abstract MenuSuiteNodeType Type
        {
            get;
        }

        public Guid ID
        {
            get
            {
                return this.id;
            }
        }

    }
}
