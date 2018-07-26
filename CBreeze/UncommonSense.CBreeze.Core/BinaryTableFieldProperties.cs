using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class BinaryTableFieldProperties : Properties
    {
#if NAV2015
        private AccessByPermissionProperty accessByPermission = new AccessByPermissionProperty("AccessByPermission");
#endif
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
#if NAV2018
        private ObsoleteStateProperty obsoleteState = new ObsoleteStateProperty("ObsoleteState");
#endif
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");

        internal BinaryTableFieldProperties(BinaryTableField field)
        {
            Field = field;

            innerList.Add(onValidate);
            innerList.Add(onLookup);
#if NAV2015
            innerList.Add(accessByPermission);
#endif
#if NAV2018
            innerList.Add(obsoleteState);
#endif
            innerList.Add(captionML);
            innerList.Add(description);
        }

        public BinaryTableField Field { get; }

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
    }
}