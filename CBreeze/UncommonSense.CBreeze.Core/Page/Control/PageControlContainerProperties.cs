using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Page.Control
{
        public class PageControlContainerProperties : Properties
    {
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private PageControlContainerTypeProperty containerType = new PageControlContainerTypeProperty("ContainerType");
        private StringProperty description = new StringProperty("Description");
        private StringProperty name = new StringProperty("Name");

        internal PageControlContainerProperties(PageControlContainer containerPageControl)
        {
            ContainerPageControl = containerPageControl;

            innerList.Add(name);
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(containerType);
        }

        public PageControlContainer ContainerPageControl { get; protected set; }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

        public PageControlContainerType? ContainerType
        {
            get
            {
                return this.containerType.Value;
            }
            set
            {
                this.containerType.Value = value;
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

      public string Name
        {
            get
            {
                return this.name.Value;
            }
            set
            {
                this.name.Value = value;
            }
        }

        public override INode ParentNode => ContainerPageControl;
    }
}
