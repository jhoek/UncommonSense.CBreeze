using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class PermissionsProperty : Property
    {
        private Permissions value = new Permissions();

        internal PermissionsProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public Permissions Value
        {
            get
            {
                return this.value;
            }
        }
    }

}
