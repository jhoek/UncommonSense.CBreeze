using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
    public class ApplicationDesign : IEnumerable<EntityType>
    {
        private List<EntityType> innerList = new List<EntityType>();

        public T Add<T>(T entityType) where T : EntityType
        {
            entityType.ApplicationDesign = this;
            innerList.Add(entityType);
            return entityType;
        }

        public bool Remove(EntityType entityType)
        {
            return innerList.Remove(entityType);
        }

        public IEnumerator<EntityType> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
}
