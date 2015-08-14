using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class SIFTLevelsProperty : Property
    {
        private SIFTLevels value = new SIFTLevels();

        internal SIFTLevelsProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public SIFTLevels Value
        {
            get
            {
                return this.value;
            }
        }
    }

}
