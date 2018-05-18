using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Property.Type;

namespace UncommonSense.CBreeze.Core.Table.Field.Properties
{
        public class BinaryTableFieldProperties : Property.Properties
    {
#if NAV2015
        private AccessByPermissionProperty accessByPermission = new AccessByPermissionProperty("AccessByPermission");
#endif
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
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
            innerList.Add(captionML);
            innerList.Add(description);
        }

        public BinaryTableField Field { get;  }

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
