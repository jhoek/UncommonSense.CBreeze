using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class SourceField
    {
        public string FieldName
        {
            get;set;
        }

        public string TableVariableName
        {
            get;set;
        }

    }
}
