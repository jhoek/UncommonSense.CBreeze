using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
    public class ReferenceProperty<T> : Property where T : new()
    {
        private T value = new T();

        internal ReferenceProperty(string name)
            :
            base(name)
        {
        }

        public override string ToString()
        {
            return string.Format("{0}={1}", Name, Value);
        }

        public T Value
        {
            get
            {
                return this.value;
            }
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield break;
            }
        }
    }
}

