using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class PageActionContainerProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private ActionContainerTypeProperty actionContainerType = new ActionContainerTypeProperty("ActionContainerType");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private StringProperty name = new StringProperty("Name");

        internal PageActionContainerProperties()
        {
            innerList.Add(name);
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(actionContainerType);
        }

        public Property this[string name]
        {
            get
            {
                return innerList.FirstOrDefault(p => p.Name == name);
            }
        }

        public ActionContainerType? ActionContainerType
        {
            get
            {
                return this.actionContainerType.Value;
            }
            set
            {
                this.actionContainerType.Value = value;
            }
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public System.String Description
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

      public System.String Name
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }
}
