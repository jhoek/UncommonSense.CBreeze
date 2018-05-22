using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Table.Key
{
        public class TableKeyProperties : Properties
    {

        private NullableBooleanProperty clustered = new NullableBooleanProperty("Clustered");
        private StringProperty keyGroups = new StringProperty("KeyGroups");
        private NullableBooleanProperty maintainSIFTIndex = new NullableBooleanProperty("MaintainSIFTIndex");
        private NullableBooleanProperty maintainSQLIndex = new NullableBooleanProperty("MaintainSQLIndex");
        private SIFTLevelsProperty siftLevelsToMaintain = new SIFTLevelsProperty("SIFTLevelsToMaintain");
        private FieldListProperty sqlIndex = new FieldListProperty("SQLIndex");
        private FieldListProperty sumIndexFields = new FieldListProperty("SumIndexFields");

        internal TableKeyProperties(TableKey tableKey )
        {
            TableKey = tableKey;

            innerList.Add(sumIndexFields);
            innerList.Add(keyGroups);
            innerList.Add(maintainSQLIndex);
            innerList.Add(maintainSIFTIndex);
            innerList.Add(sqlIndex);
            innerList.Add(siftLevelsToMaintain);
            innerList.Add(clustered);
        }

        public TableKey TableKey { get; protected set; }

        public override INode ParentNode => TableKey;

        public bool? Clustered
        {
            get
            {
                return this.clustered.Value;
            }
            set
            {
                this.clustered.Value = value;
            }
        }

        public string KeyGroups
        {
            get
            {
                return this.keyGroups.Value;
            }
            set
            {
                this.keyGroups.Value = value;
            }
        }

        public bool? MaintainSIFTIndex
        {
            get
            {
                return this.maintainSIFTIndex.Value;
            }
            set
            {
                this.maintainSIFTIndex.Value = value;
            }
        }

        public bool? MaintainSQLIndex
        {
            get
            {
                return this.maintainSQLIndex.Value;
            }
            set
            {
                this.maintainSQLIndex.Value = value;
            }
        }

        public SIFTLevels SIFTLevelsToMaintain
        {
            get
            {
                return this.siftLevelsToMaintain.Value;
            }
        }

        public FieldList SQLIndex
        {
            get
            {
                return this.sqlIndex.Value;
            }
        }

        public FieldList SumIndexFields
        {
            get
            {
                return this.sumIndexFields.Value;
            }
        }
    }
}
