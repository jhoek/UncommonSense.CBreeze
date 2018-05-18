using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Table.Field.Properties
{
        public class TableFieldGroupProperties : Property.Properties
    {
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");

        internal TableFieldGroupProperties(TableFieldGroup tableFieldGroup)
        {
            TableFieldGroup = tableFieldGroup;

            innerList.Add(captionML);
        }

        public TableFieldGroup TableFieldGroup { get; protected set; }

        public override INode ParentNode => TableFieldGroup;

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }
    }
}
