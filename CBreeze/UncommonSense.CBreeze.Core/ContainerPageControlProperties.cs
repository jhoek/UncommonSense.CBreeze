using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class ContainerPageControlProperties : Properties
    {
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private ContainerTypeProperty containerType = new ContainerTypeProperty("ContainerType");
        private StringProperty description = new StringProperty("Description");
        private StringProperty name = new StringProperty("Name");

        internal ContainerPageControlProperties()
        {
            innerList.Add(name);
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(containerType);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

        public ContainerType? ContainerType
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
    }
}
