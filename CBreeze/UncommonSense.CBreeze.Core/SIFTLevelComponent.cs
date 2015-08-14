using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class SIFTLevelComponent
    {
        private String fieldName;
        private String aspect;

        internal SIFTLevelComponent(String fieldName, String aspect)
        {
            this.aspect = aspect;
            this.fieldName = fieldName;
        }

        public String FieldName
        {
            get
            {
                return this.fieldName;
            }
        }

        public String Aspect
        {
            get
            {
                return this.aspect;
            }
        }

    }
}
