using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.MenuSuite
{
    public class MenuSuiteDeltaNodeProperties : Properties
    {
        private NullableBooleanProperty deleted = new NullableBooleanProperty("Deleted");
        private NullableGuidProperty nextNodeID = new NullableGuidProperty("NextNodeID");

        internal MenuSuiteDeltaNodeProperties(DeltaNode node)
        {
            Node = node;

            innerList.Add(deleted);
            innerList.Add(nextNodeID);
        }

        public DeltaNode Node { get; protected set; }

        public override INode ParentNode => Node;

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
