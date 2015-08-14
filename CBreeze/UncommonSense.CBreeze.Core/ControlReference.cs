using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class ControlReference
    {
        private String controlName;

        internal ControlReference(String controlName)
        {
            this.controlName = controlName;
        }

        public String ControlName
        {
            get
            {
                return this.controlName;
            }
        }

    }
}
