using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Property
{
        public class ObjectProperties : IProperties
    {
        private List<Implementation.Property> innerList = new List<Implementation.Property>();

        private NullableDateTimeProperty dateTime = new NullableDateTimeProperty("DateTime");
        private BooleanProperty modified = new BooleanProperty("Modified");
        private StringProperty versionList = new StringProperty("VersionList");

        internal ObjectProperties()
        {
            innerList.Add(dateTime);
            innerList.Add(modified);
            innerList.Add(versionList);
        }

        public Implementation.Property this[string name]
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

      public bool Modified
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

      public string VersionList
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

        public IEnumerator<Implementation.Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }
}
