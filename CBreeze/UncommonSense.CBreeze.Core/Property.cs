using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public abstract class Property
    {
        private string name;

        internal Property(string name)
        {
            this.name = name;
        }

        public abstract bool HasValue
        {
            get;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }
    }
}
