using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class SIFTLevel
    {
        private SIFTLevelComponents components = new SIFTLevelComponents();

        internal SIFTLevel()
        {
        }

        public SIFTLevelComponents Components
        {
            get
            {
                return this.components;
            }
        }

    }
}
