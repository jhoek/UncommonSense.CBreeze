using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class MenuSuiteRootNodeProperties : Properties
    {
        private NullableGuidProperty firstChild = new NullableGuidProperty("FirstChild");

        internal MenuSuiteRootNodeProperties()
        {
            innerList.Add(firstChild);
        }

        public System.Guid? FirstChild
        {
            get
            {
                return this.firstChild.Value;
            }
            set
            {
                this.firstChild.Value = value;
            }
        }
    }
}
