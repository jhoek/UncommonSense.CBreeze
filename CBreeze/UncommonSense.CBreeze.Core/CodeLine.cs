using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class CodeLine
    {
        private String text;

        internal CodeLine(String text)
        {
            this.text = text;
        }

        public String Text
        {
            get
            {
                return this.text;
            }
        }

    }
}
