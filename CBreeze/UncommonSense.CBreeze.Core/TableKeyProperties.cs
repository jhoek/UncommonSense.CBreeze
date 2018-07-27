using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class TableKeyProperties : Properties
    {
        private NullableBooleanProperty clustered = new NullableBooleanProperty("Clustered");
        private StringProperty keyGroups = new StringProperty("KeyGroups");
        private NullableBooleanProperty maintainSIFTIndex = new NullableBooleanProperty("MaintainSIFTIndex");
        private NullableBooleanProperty maintainSQLIndex = new NullableBooleanProperty("MaintainSQLIndex");
#if NAV2018
        private ObsoleteStateProperty obsoleteState = new ObsoleteStateProperty("ObsoleteState");
        private StringProperty obsoleteReason = new StringProperty("ObsoleteReason");
#endif
        private SIFTLevelsProperty siftLevelsToMaintain = new SIFTLevelsProperty("SIFTLevelsToMaintain");
        private FieldListProperty sqlIndex = new FieldListProperty("SQLIndex");
        private FieldListProperty sumIndexFields = new FieldListProperty("SumIndexFields");

        internal TableKeyProperties(TableKey tableKey)
        {
            TableKey = tableKey;

            innerList.Add(sumIndexFields);
            innerList.Add(keyGroups);
            innerList.Add(maintainSQLIndex);
            innerList.Add(maintainSIFTIndex);
            innerList.Add(clustered);
            innerList.Add(sqlIndex);
#if NAV2018
            innerList.Add(obsoleteState);
            innerList.Add(obsoleteReason);
#endif
            innerList.Add(siftLevelsToMaintain);
        }

        public TableKey TableKey { get; protected set; }

        public override INode ParentNode => TableKey;

#if NAV2018

        public ObsoleteState? ObsoleteState
        {
            get => obsoleteState.Value;
            set => obsoleteState.Value = value;
        }

        public string ObsoleteReason
        {
            get => obsoleteReason.Value;
            set => obsoleteReason.Value = value;
        }

#endif

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