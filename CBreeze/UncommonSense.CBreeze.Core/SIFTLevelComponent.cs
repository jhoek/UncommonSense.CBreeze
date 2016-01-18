using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class SIFTLevelComponent
    {
        public SIFTLevelComponent(string fieldName, string aspect)
        {
            Aspect = aspect;
            FieldName = fieldName;
        }

        public string FieldName
        {
            get;
            protected set;
        }

        public string Aspect
        {
            get;
            protected set;
        }
    }
}
