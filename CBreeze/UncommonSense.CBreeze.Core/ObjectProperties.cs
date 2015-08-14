using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class ObjectProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private NullableDateTimeProperty dateTime = new NullableDateTimeProperty("DateTime");
        private BooleanProperty modified = new BooleanProperty("Modified");
        private StringProperty versionList = new StringProperty("VersionList");

        internal ObjectProperties()
        {
            innerList.Add(dateTime);
            innerList.Add(modified);
            innerList.Add(versionList);
        }

        public Property this[string name]
        {
            get
            {
                return innerList.FirstOrDefault(p => p.Name == name);
            }
        }

      public System.DateTime? DateTime
        {
            get
            {
                return this.dateTime.Value;
            }
            set
            {
                this.dateTime.Value = value;
            }
        }

      public System.Boolean Modified
        {
            get
            {
                return this.modified.Value;
            }
            set
            {
                this.modified.Value = value;
            }
        }

      public System.String VersionList
        {
            get
            {
                return this.versionList.Value;
            }
            set
            {
                this.versionList.Value = value;
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
