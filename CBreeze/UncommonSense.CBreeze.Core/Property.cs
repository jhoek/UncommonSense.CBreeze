using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public abstract class Property
    {
        internal Property(string name)
        {
            Name = name;
        }

        public abstract bool HasValue
        {
            get;
        }

        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Returns an object containing the property value.
        /// For more type-safe operations, use the Value property instead
        /// </summary>
        /// <returns></returns>
        public abstract object GetValue();
    }
}