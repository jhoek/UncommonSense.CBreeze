using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class TableFilterTableFieldProperties : Properties
    {
#if NAV2015
        private AccessByPermissionProperty accessByPermission = new AccessByPermissionProperty("AccessByPermission");
#endif
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
#if NAV2018
        private DataClassificationProperty dataClassification = new DataClassificationProperty("DataClassification");
#endif
        private StringProperty description = new StringProperty("Description");
#if NAV2018
        private ObsoleteStateProperty obsoleteState = new ObsoleteStateProperty("ObsoleteState");
        private StringProperty obsoleteReason = new StringProperty("ObsoleteReason");
#endif
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private StringProperty tableIDExpr = new StringProperty("TableIDExpr");

        internal TableFilterTableFieldProperties(TableFilterTableField field)
        {
            Field = field;

            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(tableIDExpr);
#if NAV2015
            innerList.Add(accessByPermission);
#endif
#if NAV2018
            innerList.Add(obsoleteState);
            innerList.Add(obsoleteReason);
            innerList.Add(dataClassification);
#endif
            innerList.Add(captionML);
            innerList.Add(description);
        }

        public TableFilterTableField Field { get; protected set; }

        public override INode ParentNode => Field;

#if NAV2015

        public AccessByPermission AccessByPermission
        {
            get
            {
                return accessByPermission.Value;
            }
        }

#endif

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

        public DataClassification? DataClassification
        {
            get => dataClassification.Value;
            set => dataClassification.Value = value;
        }

#endif

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

        public string Description
        {
            get
            {
                return this.description.Value;
            }
            set
            {
                this.description.Value = value;
            }
        }

        public Trigger OnLookup
        {
            get
            {
                return this.onLookup.Value;
            }
        }

        public Trigger OnValidate
        {
            get
            {
                return this.onValidate.Value;
            }
        }

        public string TableIDExpr
        {
            get
            {
                return this.tableIDExpr.Value;
            }
            set
            {
                this.tableIDExpr.Value = value;
            }
        }
    }
}