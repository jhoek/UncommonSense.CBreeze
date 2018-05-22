using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Report
{
        public class ReportLabelProperties : Properties
    {
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");

        internal ReportLabelProperties(ReportLabel reportLabel)
        {
            ReportLabel = reportLabel;

            innerList.Add(captionML);
            innerList.Add(description);
        }

        public ReportLabel ReportLabel { get; protected set; }

        public override INode ParentNode => ReportLabel;

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
    }
}
