using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class LinkFieldsProperty : Property
    {
        private LinkFields value = new LinkFields();

        internal LinkFieldsProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public LinkFields Value
        {
            get
            {
                return this.value;
            }
        }
    }

}
