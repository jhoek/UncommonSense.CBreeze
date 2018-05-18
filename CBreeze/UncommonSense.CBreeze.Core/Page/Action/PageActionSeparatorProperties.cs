using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Page.Action
{
        public class PageActionSeparatorProperties : Properties
    {
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private NullableBooleanProperty isHeader = new NullableBooleanProperty("IsHeader");

        internal PageActionSeparatorProperties(PageActionSeparator pageActionSeparator)
        {
            PageActionSeparator = pageActionSeparator;

            innerList.Add(captionML);
            innerList.Add(isHeader);
        }

        public PageActionSeparator PageActionSeparator { get; protected set; }

        public override INode ParentNode => PageActionSeparator;

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public bool? IsHeader
        {
            get
            {
                return this.isHeader.Value;
            }
            set
            {
                this.isHeader.Value = value;
            }
        }
    }
}
