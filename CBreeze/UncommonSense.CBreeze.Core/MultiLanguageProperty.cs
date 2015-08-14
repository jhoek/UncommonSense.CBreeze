using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class MultiLanguageProperty : Property
    {
        private MultiLanguageValue value = new MultiLanguageValue();

        internal MultiLanguageProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public MultiLanguageValue Value
        {
            get
            {
                return this.value;
            }
        }
    }

}
