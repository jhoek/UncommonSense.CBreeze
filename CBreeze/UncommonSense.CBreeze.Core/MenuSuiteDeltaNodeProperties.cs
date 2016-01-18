using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class MenuSuiteDeltaNodeProperties : Properties
    {
        private NullableBooleanProperty deleted = new NullableBooleanProperty("Deleted");
        private NullableGuidProperty nextNodeID = new NullableGuidProperty("NextNodeID");

        internal MenuSuiteDeltaNodeProperties()
        {
            innerList.Add(deleted);
            innerList.Add(nextNodeID);
        }

        public bool? Deleted
        {
            get
            {
                return this.deleted.Value;
            }
            set
            {
                this.deleted.Value = value;
            }
        }

        public System.Guid? NextNodeID
        {
            get
            {
                return this.nextNodeID.Value;
            }
            set
            {
                this.nextNodeID.Value = value;
            }
        }
    }
}
