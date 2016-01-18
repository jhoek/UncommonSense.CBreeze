using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class BlobTableFieldProperties : Properties
    {
#if NAV2015
        private AccessByPermissionProperty accessByPermission = new AccessByPermissionProperty("AccessByPermission");
#endif
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private NullableBooleanProperty compressed = new NullableBooleanProperty("Compressed");
        private StringProperty description = new StringProperty("Description");
#if NAV2016
        private ExternalAccessProperty externalAccess = new ExternalAccessProperty("ExternalAccess");
        private StringProperty externalName = new StringProperty("ExternalName");
        private StringProperty externalType = new StringProperty("ExternalType");
#endif
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private StringProperty owner = new StringProperty("Owner");
        private BlobSubTypeProperty subType = new BlobSubTypeProperty("SubType");
        private NullableBooleanProperty @volatile = new NullableBooleanProperty("Volatile");

        internal BlobTableFieldProperties()
        {
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(compressed);
            innerList.Add(@volatile);
#if NAV2015
            innerList.Add(accessByPermission);
#endif
#if NAV2016
            innerList.Add(externalName);
            innerList.Add(externalType);
            innerList.Add(externalAccess);
#endif
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(owner);
            innerList.Add(subType);
        }

#if NAV2015
        public AccessByPermission AccessByPermission
        {
            get
            {
                return accessByPermission.Value;
            }
        }
#endif

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public bool? Compressed
        {
            get
            {
                return this.compressed.Value;
            }
            set
            {
                this.compressed.Value = value;
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

#if NAV2016
      public ExternalAccess? ExternalAccess
      {
          get
          {
              return this.externalAccess.Value;
          }
          set
          {
              this.externalAccess.Value = value;
          }
      }

      public string ExternalName
      {
          get
          {
              return this.externalName.Value;
          }
          set
          {
              this.externalName.Value = value;
          }
      }

      public string ExternalType
      {
          get
          {
              return this.externalType.Value;
          }
          set
          {
              this.externalType.Value = value;
          }
      }
#endif

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

      public string Owner
        {
            get
            {
                return this.owner.Value;
            }
            set
            {
                this.owner.Value = value;
            }
        }

        public BlobSubType? SubType
        {
            get
            {
                return this.subType.Value;
            }
            set
            {
                this.subType.Value = value;
            }
        }

      public bool? Volatile
        {
            get
            {
                return this.@volatile.Value;
            }
            set
            {
                this.@volatile.Value = value;
            }
        }
    }
}
