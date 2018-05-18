using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class SIFTLevel
    {
        public SIFTLevel()
        {
            Components = new SIFTLevelComponents();
        }

        public SIFTLevelComponents Components
        {
            get;
            protected set;
        }
    }
}
